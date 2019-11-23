using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiClient;
using api1.Services;

namespace api1
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
            services.AddControllers();
            string doubleUrl = Configuration.GetValue<string>("GatewayUrl");
            string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6Im05ZGVfdWotNHNLNFJoa3h5ZmpSa1EiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1NzQ1MTMwMTYsImV4cCI6MTg4OTg3MzAxNiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDEwIiwiYXVkIjoiYXBpMSIsImNsaWVudF9pZCI6ImNsaWVudCIsInNjb3BlIjpbImFwaTEiXX0.UvLzjZaWy-agu-vf3NWGYIlJOIAaayJwV3ms9jxV9A3DKtNBnCYcgJJl3P36kQuXg4jl-JqLvYjnXnCbAUYoRMxqMludRPk75JF7ngiIZmOKAJjLpAQDdjf1BbzvUynabGCXR0cJ2DIHMU1UasFXYXOav_-jc7_Alo11rR6XpkaJeeJg3LyRIGaS7ubfjQnH7wAN8MGK4ErKvtj77IMKFKoc-3Tjfp-sOc9K3x5xL0ouF8kD_jbdNmQixq9Z0Gp3oPrVJhqe_FcO9_E6nBSKlkV390bw5xPBE_ukCit1xZPFasyT0w1r3qRusEzMXv-6G1uVJt_ZOuSWNzeUl33IDQ";
            HttpApi.Register<ICallService>().ConfigureHttpApiConfig(c =>
            {
                c.HttpHost = new Uri(doubleUrl);
                //c.FormatOptions.DateTimeFormat = DateTimeFormats.ISO8601_WithMillisecond;
                c.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
