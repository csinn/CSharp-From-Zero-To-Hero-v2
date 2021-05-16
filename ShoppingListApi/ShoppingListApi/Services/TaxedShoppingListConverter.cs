using System.Collections.Generic;

namespace ShoppingListApi.Services
{
    public interface ITaxedShoppingListConverter
    {
        TaxedShoppingList Converts(ShoppingList shoppingList);
    }

    public class TaxedShoppingListConverter: ITaxedShoppingListConverter
    {
        private readonly IEnumerable<ITaxPolicy> _taxPolicies;

        public TaxedShoppingListConverter(IEnumerable<ITaxPolicy> taxPolicies)
        {
            _taxPolicies = taxPolicies;
        }

        public TaxedShoppingList Converts(ShoppingList shoppingList)
        {
            var taxedShoppingList = new TaxedShoppingList(_taxPolicies)
            {
                Address = shoppingList.Address,
                Id = shoppingList.Id,
                ShopName = shoppingList.ShopName
            };

            foreach (var shoppingListItem in shoppingList.Items)
            {
                taxedShoppingList.Add(shoppingListItem);
            }

            return taxedShoppingList;
        }
    }
}
