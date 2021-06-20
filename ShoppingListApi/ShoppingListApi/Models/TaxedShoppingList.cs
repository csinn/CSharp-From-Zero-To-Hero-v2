using System.Collections.Generic;

namespace ShoppingListApi.Models
{
    public class TaxedShoppingList : ShoppingList
    {
        public IEnumerable<ITaxPolicy> TaxPolicies { get; }

        public TaxedShoppingList(IEnumerable<ITaxPolicy> taxPolicies)
        {
            TaxPolicies = taxPolicies;
        }

        public override decimal CalculateTotalCost()
        {
            var pureCost = base.CalculateTotalCost();
            if (TaxPolicies == null) return pureCost;

            var actualCost = pureCost;
            foreach (var taxPolicy in TaxPolicies)
            {
                actualCost = taxPolicy.Apply(actualCost);
            }

            return actualCost;
        }
    }
}