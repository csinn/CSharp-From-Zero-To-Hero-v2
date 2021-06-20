using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;

namespace ShoppingListApi.Mappers
{
    public static class ItemMappings
    {
        public static Domain.Item Map(this Db.Item item)
        {
            return new Domain.Item
            {
                Amount = item.Amount,
                Name = item.Name,
                Price = item.Price
            };
        }

        public static Db.Item Map(this Domain.Item item)
        {
            return new Db.Item
            {
                Amount = item.Amount,
                Name = item.Name,
                Price = item.Price
            };
        }
    }
}
