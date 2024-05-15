using ElectronicGovernment.API.Models;
using ElectronicGovernment.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ElectronicGovernment.Helpers;

/// <summary>
/// See here to get more information: https://metanit.com/sharp/aspnet6/13.2.php
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddMyAuth(this IServiceCollection service)
    {
        service.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", 
                policy =>
                {
                    policy.RequireRole(nameof(RoleType.Admin));
                    policy.RequireRole(nameof(RoleType.CEO));
                });

            options.AddPolicy("OperatorOnly",
                policy =>
                {
                    policy.RequireRole(nameof(RoleType.Operator));
                    policy.RequireRole(nameof(RoleType.GlobalOperator));
                });
            options.AddPolicy("LeadOnly", policy => policy.RequireRole(nameof(RoleType.Lead)));
        });

        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,

                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                };
            });
    }
}
