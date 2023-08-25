using Mapster;
using MapsterMapper;
using System.Reflection;
using WebLibrary.BLL.Services.UserServices;
using WebLibrary.BLL.Services.BookServices;
using Microsoft.Extensions.DependencyInjection;
using WebLibrary.BLL.Services.IdentityServices;

namespace WebLibrary.BLL
{
    public static class DI
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            RegisterMapster(services);

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }

        private static void RegisterMapster(IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            var applicationAssembly = Assembly.GetExecutingAssembly();
            typeAdapterConfig.Scan(applicationAssembly);

            services.AddSingleton(typeAdapterConfig);
            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
