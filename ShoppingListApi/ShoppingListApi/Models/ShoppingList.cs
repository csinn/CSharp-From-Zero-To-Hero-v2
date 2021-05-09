using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShoppingListApi
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return CalculateTotalCost();
            }
        }

        public IEnumerable<Item> Items
        {
            get
            {
                return _items;
            }
        }

        private List<Item> _items = new List<Item>();

        public virtual decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in Items)
            {
                totalCost += item.Price;
            }

            return totalCost;
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Update(ShoppingList update)
        {
            _items = update.Items.ToList();
            Address = update.Address;
            ShopName = update.ShopName;
        }
    }
}
