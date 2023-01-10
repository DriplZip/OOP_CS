using System.Security.Claims;
using BusinessLogic.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Presentation.Constants;

namespace Presentation.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCookiesAuthentication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromHours(8);
            options.SlidingExpiration = true;

            options.LoginPath = "/api/Account/error";

            options.AccessDeniedPath = "/api/Account/error";
        });

        return serviceCollection;
    }

    public static IServiceCollection AddRoles(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            options.AddPolicy(PolicyName.EmployeePolicy, policyBuilder =>
            {
                AccountRole[] allowedRoles = { AccountRole.Admin, AccountRole.Employee };
                policyBuilder.RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString())).Build();
            });
            options.AddPolicy(PolicyName.DirectorPolicy, policyBuilder =>
            {
                AccountRole[] allowedRoles = { AccountRole.Admin, AccountRole.Director };
                policyBuilder.RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString())).Build();
            });
        });
    }
}