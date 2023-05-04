using IIG.Core.Framework.Email.Business.Application;
using IIG.Core.Framework.Email.Business.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        const string rule = "MyCorsRule";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //options.AddPolicy(rule, policy => policy.AllowAnyOrigin());
                options.AddPolicy(name: rule,
                     policy =>
                     {
                         policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                     });
            });
            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IIG.Core.Framework.Auth", Version = "v1" });
            });

            services.AddScoped<IApplicationHandler, ApplicationHandler>();
            services.AddScoped<IEmailHandler, EmailHandler>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IIG.Core.Framework.Auth v1"));
            }

            app.UseRouting();
            app.UseCors(rule);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
