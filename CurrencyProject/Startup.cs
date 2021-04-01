using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyProject.HttpClients;
using CurrencyProject.Services.CurrencyService;
using CurrencyProject.Services.DataService;
using CurrencyProject.Services.MathFinanceService;
using CurrencyProject.Services.SerializeService;
using CurrencyProject.Services.Validaton;
using CurrencyProject.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CurrencyProject
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
            services.Configure<NbpExternalServiceSettings>(options => Configuration.GetSection("NbpExternalServiceSettings").Bind(options));

            services.AddScoped<IDataService, NbpCurrencyService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IMathFinanceService, MathFinanceService>();
            services.AddScoped<IDeserializationService, JsonService>();
            services.AddScoped<IValidation, InputParametersValidator>();

            services.AddScoped<HttpCurrencyClient>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
