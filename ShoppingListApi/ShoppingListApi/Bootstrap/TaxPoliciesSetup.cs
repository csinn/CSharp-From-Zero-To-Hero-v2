using Microsoft.Extensions.DependencyInjection;
using ShoppingListApi.Services;

namespace ShoppingListApi.Bootstrap
{
    public static class TaxPoliciesSetup
    {
        public static void AddTaxPolicies(this IServiceCollection services)
        {
            services.AddSingleton<ITaxedShoppingListConverter, TaxedShoppingListConverter>();
            services.AddSingleton<ITaxPolicy, ProgressiveTaxedPolicy>();
            services.AddSingleton<ITaxPolicy, FixedTaxPolicy>(_ => new FixedTaxPolicy(1.01m));
        }
    }
}
