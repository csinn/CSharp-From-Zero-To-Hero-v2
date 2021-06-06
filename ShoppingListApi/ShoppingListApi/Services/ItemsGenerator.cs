using System;
using System.Text;
using ShoppingListApi.Models;

namespace ShoppingListApi.Services
{
    public interface IItemsGenerator
    {
        public Item Generate();
    }

    public class ItemsGenerator: IItemsGenerator
    {
        private readonly Random _random;

        public ItemsGenerator()
        {
            _random = new Random();
        }

        public Item Generate()
        {
            var bytes = new byte[100];
            _random.NextBytes(bytes);
            var randomName = Encoding.Unicode.GetString(bytes);

            var item = new Item
            {
                Amount = _random.NextDouble() * 100,
                Price = (decimal)(_random.NextDouble() * 100),
                Name = randomName
            };

            return item;
        }
    }
}
