using System.Collections.Generic;

namespace ShoppingList.API.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ShopName { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Item> ListItems { get; set; } = new List<Item>();
    }
}