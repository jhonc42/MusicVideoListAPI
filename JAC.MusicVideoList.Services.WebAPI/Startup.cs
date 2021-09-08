using FluentValidation.AspNetCore;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using JAC.MusicVideoList.Infrastructure.Main;
using JAC.MusicVideoList.Infrastructure.Main.Filters;
using JAC.MusicVideoList.Infrastructure.Main.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Services.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<MongoSettings>(options => 
            //{
            //    options.ConnectionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
            //    options.DataBase = Configuration.GetSection("MongoDB:DataBase").Value;
            //});
            //services.AddSingleton<MongoSettings>();
            services.Configure<MongoSettings>(Configuration.GetSection("MongoDb"));

            services.AddSingleton<IMongoSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);

            services.Configure<PasswordOptions>(options => Configuration.GetSection("PasswordOptions").Bind(options));
            services.AddMapper();
            services.AddCors(opt =>
            {
                opt.AddPolicy("Default_CorsPolicy", o =>
                {
                    o.AllowAnyHeader();
                    o.AllowAnyMethod();
                    o.AllowAnyOrigin();
                });
            });
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.AddServices();
            services.AddControllers();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };

            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JAC.MusicVideoList.Services.WebAPI", Version = "v1" });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // string appNameURI = Configuration.GetValue<string>("AppNameURI")?.Trim() ?? "/";
            // appNameURI = (!appNameURI.StartsWith("/") ? ("/" + appNameURI) : appNameURI);
            // appNameURI = (!appNameURI.EndsWith("/") ? (appNameURI + "/") : appNameURI);

            // string swaggerEndPoint = $"{appNameURI}swagger/v1/swagger.json";
            app.UseCors("Default_CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JAC.MusicVideoList.Services.WebAPI v1"));
            // app.UseSwaggerUI(s =>
            //{
            //    s.RoutePrefix = "api";
            //    s.SwaggerEndpoint(swaggerEndPoint, "JAC.MusicVideoList.Services.WebAPI v1");
            //});
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
