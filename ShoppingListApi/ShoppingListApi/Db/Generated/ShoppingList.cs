using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingListApi.Db.Generated
{
    public partial class ShoppingList
    {
        public ShoppingList()
        {
            Items = new HashSet<Item>();
        }

        public long Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public long IsProgressiveTaxes { get; set; }
        public string FixedTaxes { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
