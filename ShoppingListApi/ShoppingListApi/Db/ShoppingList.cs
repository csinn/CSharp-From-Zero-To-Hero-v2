using System.Collections.Generic;

namespace ShoppingListApi.Db
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
        public bool IsProgressiveTaxes { get; set; }
        public decimal? FixedTaxes { get; set; }
    }
}
