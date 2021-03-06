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
using IdentityModel.Client;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using WebApiClient.Extensions.HttpClientFactory;

namespace api1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //static async Task<TokenResponse> RequestTokenAsync(string idsUrl)
        //{
        //    var client = new HttpClient();

        //    //var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest {Address = idsUrl,Policy = new DiscoveryPolicy {RequireHttps = false } });
        //    //if (disco.IsError) throw new Exception(disco.Error);
        //    //string tokenUrl = disco.TokenEndpoint;
        //    string tokenUrl = $"{idsUrl}/connect/token";
        //    var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        //    {
        //        Address = tokenUrl,

        //        ClientId = "client",
        //        ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
        //        //Scope = "IdentityServerApi"
        //    });

        //    if (response.IsError) throw new Exception(response.Error);
        //    return response;
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            string gatewayUrl = Configuration.GetValue<string>("GatewayUrl");
            services.AddHttpContextAccessor();
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpApiTypedClient<ICallService>(
                c =>
            {
                c.HttpHost = new Uri(gatewayUrl);
                //c.FormatOptions.DateTimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            }).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            //IHttpClientBuilder httpClientBuilder = services.AddHttpApiTypedClient<ICallService>(//)
            //         (p, client) =>
            //        {
            //            var httpApiConfig = new HttpApiConfig(client)
            //            {
            //                HttpHost = new Uri(gatewayUrl),
            //                LoggerFactory = p.GetRequiredService<ILoggerFactory>()
            //            };

            //            return HttpApi.Create<ICallService>(httpApiConfig);
            //        })
            //        //token����
            //       
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
