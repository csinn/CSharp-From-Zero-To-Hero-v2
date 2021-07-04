using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingListApi.Db.Generated
{
    public partial class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public double Amount { get; set; }
        public long ShoppingListId { get; set; }

        public virtual ShoppingList ShoppingList { get; set; }
    }
}
