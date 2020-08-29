﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using WhyNotEarth.Meredith.BrowTricks.Jobs;
using WhyNotEarth.Meredith.Exceptions;
using WhyNotEarth.Meredith.HelloSign;
using WhyNotEarth.Meredith.Identity;
using WhyNotEarth.Meredith.Public;
using WhyNotEarth.Meredith.Tenant;
using WhyNotEarth.Meredith.Twilio;

namespace WhyNotEarth.Meredith.BrowTricks
{
    internal class PmuService : IPmuService
    {
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IDbContext _dbContext;
        private readonly IPmuPdfService _pmuPdfService;
        private readonly PmuNotifications _pmuNotifications;
        private readonly TenantService _tenantService;
        private readonly IUserService _userService;

        public PmuService(IUserService userService, IDbContext dbContext, TenantService tenantService,
            IPmuPdfService pmuPdfService, PmuNotifications pmuNotifications,
            IBackgroundJobClient backgroundJobClient)
        {
            _userService = userService;
            _dbContext = dbContext;
            _tenantService = tenantService;
            _pmuPdfService = pmuPdfService;
            _pmuNotifications = pmuNotifications;
            _backgroundJobClient = backgroundJobClient;
        }

        public async Task<byte[]> GetPdfAsync(int clientId, User user)
        {
            var client = await ValidateOwnerOrSelf(clientId, user);

            if (client.PmuStatus != PmuStatusType.Incomplete)
            {
                throw new InvalidActionException("This client is already signed their PMU form");
            }

            var disclosures = await _dbContext.Disclosures.Where(item => item.TenantId == client.TenantId).ToListAsync();

            return await _pmuPdfService.GetPdfAsync(disclosures);
        }

        public async Task SignAsync(int clientId, User user)
        {
            var client = await ValidateOwnerOrSelf(clientId, user);

            client.PmuStatus = PmuStatusType.Saving;
            client.SignedAt = DateTime.UtcNow;

            _backgroundJobClient.Enqueue<IClientSaveSignatureJob>(service =>
                service.SaveSignature(clientId));

            _dbContext.Clients.Update(client);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SendConsentNotificationAsync(int clientId, User user, string callbackUrl)
        {
            var client = await _dbContext.Clients
                .Include(item => item.User)
                .Include(item => item.Tenant)
                .FirstOrDefaultAsync(item => item.Id == clientId);

            if (client is null)
            {
                throw new RecordNotFoundException($"client {clientId} not found");
            }

            await _tenantService.CheckOwnerAsync(user, client.TenantId);

            if (client.PmuStatus != PmuStatusType.Incomplete)
            {
                throw new InvalidActionException("This client is already signed their PMU form");
            }

            var formUrl = await GetFormUrlAsync(callbackUrl, client.User);

            var shortMessage = _pmuNotifications.GetConsentNotification(client.Tenant, client.User, formUrl);

            _dbContext.ShortMessages.Add(shortMessage);
            await _dbContext.SaveChangesAsync();

            _backgroundJobClient.Enqueue<ITwilioService>(service =>
                service.SendAsync(shortMessage.Id));
        }

        private async Task<string> GetFormUrlAsync(string callbackUrl, User user)
        {
            var jwtToken = await _userService.GenerateJwtTokenAsync(user);

            var finalUrl = UrlHelper.AddQueryString(callbackUrl, new Dictionary<string, string>
            {
                {"token", jwtToken}
            });

            return finalUrl;
        }

        private async Task<Client> ValidateOwnerOrSelf(int clientId, User user)
        {
            var client = await _dbContext.Clients
                .Include(item => item.User)
                .Include(item => item.Tenant)
                .FirstOrDefaultAsync(item => item.Id == clientId);

            if (client is null)
            {
                throw new RecordNotFoundException($"client {clientId} not found");
            }

            if (client.UserId == user.Id)
            {
                // It's the user itself
                return client;
            }

            var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(item => item.Id == client.TenantId);

            if (tenant.OwnerId == user.Id)
            {
                // It's the owner
                return client;
            }

            throw new ForbiddenException();
        }
    }
}