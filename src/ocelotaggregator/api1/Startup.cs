using IdentityModel.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

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
