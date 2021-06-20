using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShoppingListApi.Bootstrap;
using ShoppingListApi.Db;
using ShoppingListApi.Services;

namespace ShoppingListApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Register dependencies
        // IServicesCollection is an Inversion of Control containers.
        // It inverts the place when the objects get created.
        // They get created (configured) here
        public void ConfigureServices(IServiceCollection services)
        {
            // Composition root- a place where you register all the dependencies.

            services.AddControllers();
            // Add dependency of IItemsGenerator
            // Lifetimes:
            // Transient- gets created for every time referenced
            // Scoped- gets created per request
            // Singleton- created one
            services.AddSingleton<IShoppingListService, ShoppingListService>();
            services.AddSingleton<IItemsGenerator, ItemsGenerator>();

            services.AddTaxPolicies();

            services.AddDbContext<ShoppingContext>();
        }

        // Configure middleware
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
