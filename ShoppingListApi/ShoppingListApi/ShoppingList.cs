using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShoppingListApi
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
