using Microsoft.OpenApi.Models;

namespace WebLibrary.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("LibraryAPI v1.0", new OpenApiInfo { Title = "LibraryAPI", Version = "v1.0." });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JSON Web Token based security"
                };

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
