using System.Collections.Generic;

namespace ShoppingListApi
{
    public class TaxedShoppingList : ShoppingList
    {
        private readonly IList<ITaxPolicy> _taxPolicies;

        public TaxedShoppingList()
        {
            _taxPolicies = new ITaxPolicy[]
            {
                new FixedTaxPolicy(1.01m),
                new ProgressiveTaxedPolicy()
            };
        }

        public override decimal CalculateTotalCost()
        {
            var pureCost = base.CalculateTotalCost();
            var actualCost = pureCost;
            foreach (var taxPolicy in _taxPolicies)
            {
                actualCost = taxPolicy.Apply(actualCost);
            }

            return actualCost;
        }
    }
}