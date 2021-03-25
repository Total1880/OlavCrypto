using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OlavCrypto.Api.Repositories;
using OlavCrypto.Api.Services;
using OlavCrypto.Api.Services.Interfaces;
using OlavCrypto.Models;

namespace OlavCrypto.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IRepository<Wallet>, WalletRepository>();

            services.AddScoped<ICryptocurrencyService, CryptocurrencyService>();
            services.AddScoped<IRepository<Cryptocurrency>, CryptocurrencyRepository>();

            services.AddScoped<ICryptocurrencyWalletService, CryptocurrencyWalletService>();
            services.AddScoped<IRepository<CryptocurrencyWallet>, CryptocurrencyWalletRepository>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OlavCrypto API", Version = "v1" });
            });

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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OlavCrypto API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
