using AutoMapper;
using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Application.Main.Main;
using JAC.MusicVideoList.Domain.Core.Core;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces;
using JAC.MusicVideoList.Infrastructure.Main.Services;
using JAC.MusicVideoList.Transversal.Common.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddSingleton<IPasswordService, PasswordService>();
            services.AddSingleton<ILoginDomain, LoginDomain>();
            services.AddScoped<ILoginApplication, LoginApplication>();

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
