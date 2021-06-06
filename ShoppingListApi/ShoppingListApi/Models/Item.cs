using ShoppingListApi.Extensions;

namespace ShoppingListApi.Models
{
    public class Item
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            } 
            set
            {
                _name = value.CapitalizeFirstLetter();
            }
        }

        public decimal Price { get; set; }
        public double Amount { get; set; }
    }
}
