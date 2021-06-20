using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListApi.Db
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public List<Item> Items { get; set; }

        public ShoppingList()
        {
            Items = new List<Item>();
        }
    }
}
