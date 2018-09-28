using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Person.API.Extensions;
using Person.Application.Extensions;
using Person.Infrastructure.Extensions;
using Person.Presentation.Extensions;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Person.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                       new Info
                       {
                           Title = "Person - API",
                           Version = "v1",
                           Description = "Person API example of DDD",
                           Contact = new Contact
                           {
                               Name = "Marvin Thomaz"
                           }
                       });

                var appPath = PlatformServices.Default.Application.ApplicationBasePath;
                var appName = PlatformServices.Default.Application.ApplicationName;
                var xmlPath = Path.Combine(appPath, $"{appName}.xml");

                options.OperationFilter<ExamplesOperationFilter>();
                options.IncludeXmlComments(xmlPath);
            });

            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPresentation();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseException();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - Product - v1"));
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
