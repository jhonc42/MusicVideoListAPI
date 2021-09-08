using AutoMapper;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Application.Main.Main;
using JAC.MusicVideoList.Domain.Core.Core;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Infrastructure.Main.External;
using JAC.MusicVideoList.Infrastructure.Main.Mapper;
using JAC.MusicVideoList.Infrastructure.Main.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JAC.MusicVideoList.Infrastructure.Main
{
    public static class ServiceCollectionExtension
    {
        //public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

        //    return services;
        //}
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddScoped<ILoginDomain, LoginDomain>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<ILoginApplication, LoginApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddTransient<ISecurityService, SecurityService>();
            services.AddScoped<ISearchApplication, SearchApplication>();
            services.AddScoped<ISearchDomain, SearchDomain>();
            services.AddScoped<IExternalServices, ExternalServices>();
            services.AddScoped<IPlayListItemApplication, PlayListItemApplication>();
            services.AddScoped<IPlayListItemDomain, PlayListItemDomain>();

            // services.AddScoped<IMongoContext, MongoContext>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddTransient<IUserContext, UserContext>();
            //services.AddTransient<IUserRepository, UserRepository>();



            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
