﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WhyNotEarth.Meredith.BrowTricks.Models;
using WhyNotEarth.Meredith.Public;

namespace WhyNotEarth.Meredith.BrowTricks.Services
{
    public interface IFormTemplateService
    {
        Task CreateDefaultsAsync(string tenantSlug, User user);

        Task<int> CreateAsync(string tenantSlug, FormTemplateModel model, User user);

        Task EditAsync(string tenantSlug, int formTemplateId, FormTemplateModel model, User user);

        Task<List<FormTemplate>> GetListAsync(string tenantSlug, User user);

        Task DeleteAsync(int formTemplateId, User user);

        Task<FormTemplate> GetAsync(int formTemplateId, User user);

        Task<FormTemplate> GetAsync(int formTemplateId);
    }
}