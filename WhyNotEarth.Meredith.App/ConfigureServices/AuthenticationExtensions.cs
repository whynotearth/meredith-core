﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WhyNotEarth.Meredith.App.Configuration;
using WhyNotEarth.Meredith.Data.Entity;
using WhyNotEarth.Meredith.Data.Entity.Models;
using WhyNotEarth.Meredith.Identity;

namespace WhyNotEarth.Meredith.App.ConfigureServices
{
    public static class AuthenticationExtensions
    {
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services
                .AddIdentity<User, Role>()
                .AddUserManager<UserManager>()
                .AddEntityFrameworkStores<MeredithDbContext>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication()
                .AddJwtBearer("jwt", config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                })
                .AddGoogle(options =>
                {
                    var config = configuration.GetSection("Authentication:Google");
                    options.ClientId = config["ClientId"];
                    options.ClientSecret = config["ClientSecret"];
                    options.Events.OnRemoteFailure = HandleOnRemoteFailure;
                })
                .AddFacebook(options =>
                {
                    var config = configuration.GetSection("Authentication:Facebook");
                    options.ClientId = config["ClientId"];
                    options.ClientSecret = config["ClientSecret"];
                    options.Events.OnRemoteFailure = HandleOnRemoteFailure;
                })
                .Services
                .ConfigureApplicationCookie(options =>
                {
                    options.Cookie.Name = "auth";
                    options.Cookie.HttpOnly = false;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.LoginPath = null;
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = redirectContext =>
                        {
                            redirectContext.HttpContext.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        }
                    };
                });
        }

        private static Task HandleOnRemoteFailure(RemoteFailureContext context)
        {
            context.Response.Redirect(context.Properties.RedirectUri);
            context.HandleResponse();

            return Task.FromResult(0);
        }
    }
}