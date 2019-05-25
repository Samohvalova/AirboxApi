using System;
using Airbox.API.Services;
using Airbox.Infrastructure;
using Airbox.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airbox.API
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
            services.AddMvc();
            RegisterServices(services);

            //Register the Swagger services
            services.AddSwaggerDocument(document =>
            {
                document.Version = "1.0.0";
                document.Title = "Airbox API";
                document.Description = "API to retrieve and update user location";
                document.DocumentName = "Airbox.API";
            });

            //Add hard-coded data (should be removed when DB is implemented)
            services.AddSingleton<Data>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi3();
        }

        private IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
