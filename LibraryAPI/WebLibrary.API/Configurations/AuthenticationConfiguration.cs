using System.Text;
using WebLibrary.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebLibrary.API.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var authConfigSection = configuration.GetSection("Auth");

            var authSettings = new AuthSettings();
            configuration.Bind(nameof(authSettings), authSettings);
            services.AddSingleton(authSettings);

            services.Configure<AuthSettings>(authConfigSection);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true
                    };
                });
            services.AddAuthorization();

            return services;
        }
    }
}
