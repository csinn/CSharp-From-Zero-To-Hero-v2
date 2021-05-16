using System.Collections.Generic;

namespace ShoppingListApi
{
    public class TaxedShoppingList : ShoppingList
    {
        private readonly IEnumerable<ITaxPolicy> _taxPolicies;

        public TaxedShoppingList(IEnumerable<ITaxPolicy> taxPolicies)
        {
            _taxPolicies = taxPolicies;
        }

        public override decimal CalculateTotalCost()
        {
            var pureCost = base.CalculateTotalCost();
            if (_taxPolicies == null) return pureCost;

            var actualCost = pureCost;
            foreach (var taxPolicy in _taxPolicies)
            {
                actualCost = taxPolicy.Apply(actualCost);
            }

            return actualCost;
        }
    }
}