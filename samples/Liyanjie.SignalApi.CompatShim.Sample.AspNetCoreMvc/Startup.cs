using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Liyanjie.SignalApi.CompatShim.Sample.AspNetCoreMvc
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
            services.AddLogging();
            services.AddControllers();
            services.AddSignalR()
                .AddJsonProtocol();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("default", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Api",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/default/swagger.json", "default");
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<CompatShim.AspNetCoreMvc.ApiHub>("/api-gateway");
                endpoints.MapSwagger();
            });
        }
    }
}
