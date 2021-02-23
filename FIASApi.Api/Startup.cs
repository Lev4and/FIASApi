using FIASApi.Api.Service;
using FIASApi.Model;
using FIASApi.Model.Repositories.Abstract;
using FIASApi.Model.Repositories.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FIASApi.Api
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
            Configuration.Bind("ConfigDb", new ConfigDb());

            services.AddTransient<IAddrobRepository, EFAddrobRepository>();
            services.AddTransient<DataManager>();

            services.AddDbContext<FIASContext>((options) =>
            {
                options.UseSqlServer(ConfigDb.ConnectionStringDb);
            });

            services.AddControllers();
        }

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
