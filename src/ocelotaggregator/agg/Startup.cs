using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agg.HttpApis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using WebApiClient;

namespace agg
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
            services.AddHttpContextAccessor();
            string gatewayUrl = Configuration.GetValue<string>("GatewayUrl");
            services.AddScoped<IBillService>(sp => {
                var httpContext = sp.GetRequiredService<IHttpContextAccessor>();
                httpContext.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues values);
                var bearer = values.FirstOrDefault();
                if(string.IsNullOrWhiteSpace(bearer))
                {
                    throw new Exception("Need Authorization Bearer Token in Header!");
                }

                var apiConfig = new HttpApiConfig { HttpHost = new Uri(gatewayUrl) };
                apiConfig.HttpClient.DefaultRequestHeaders.Clear();
                apiConfig.HttpClient.DefaultRequestHeaders.Add("Authorization", bearer);
                var billApi = HttpApi.Create<IBillService>(apiConfig);
                return billApi;

                //
                //HttpApi.Register<IBillService>().ConfigureHttpApiConfig(c =>
                //{
                //    c.HttpHost = new Uri(gatewayUrl);
                //    c.HttpClient.DefaultRequestHeaders.Clear();
                //    c.HttpClient.DefaultRequestHeaders.Add("Authorization", bearer);
                //});
                //return HttpApi.Resolve<IBillService>();
            });
            //HttpApi.Register<IBillService>().ConfigureHttpApiConfig(c =>
            //{
            //    c.HttpHost = new Uri(gatewayUrl);

            //    c.HttpClient.DefaultRequestHeaders =
            // });
            //HttpApi.Register<IUserService>().ConfigureHttpApiConfig(c =>
            //{
            //    c.HttpHost = new Uri(gatewayUrl);
            //});


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
