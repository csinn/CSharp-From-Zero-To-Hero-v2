using System;
using System.Collections.Generic;

namespace ShoppingListApi.Services
{
    public interface IShoppingListService
    {
        decimal CalculateTotalCost();
        void Add(ShoppingList shoppingList);
        List<ShoppingList> Get();
        ShoppingList FindShoppingList(int id);
        void RemoveShoppingList(int id);
        void UpdateShoppingListName(int id, string name);
        void UpdateShoppingList(int id, ShoppingList update);
        void AddItem(int shoppingListId, Item item);
    }

    public class ShoppingListService: IShoppingListService
    {
        private List<ShoppingList> _shoppingLists = new List<ShoppingList>();

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var shoppingList in _shoppingLists)
            {
                totalCost += shoppingList.CalculateTotalCost();
            }

            return totalCost;

        }

        public void Add(ShoppingList shoppingList)
        {
            _shoppingLists.Add(shoppingList);
        }

        public IEnumerable<ShoppingList> GetByName(string name)
        {
            var shoppingLists = new List<ShoppingList>();
            foreach (var shoppingList in _shoppingLists)
            {
                if (shoppingList.ShopName.ToLower() == name.ToLower())
                {
                    shoppingLists.Add(shoppingList);
                }
            }

            return shoppingLists;
        }

        public List<ShoppingList> Get()
        {
            return _shoppingLists;
        }

        public ShoppingList FindShoppingList(int id)
        {
            foreach (var list in _shoppingLists)
            {
                if (list.Id == id)
                {
                    return list;
                }
            }

            return null;
        }

        public void RemoveShoppingList(int id)
        {
            var shoppingList = FindShoppingList(id);
            if (shoppingList == null)
            {
                throw new ArgumentException($"Shopping list by id {id} was not found.");
            }

            _shoppingLists.Remove(shoppingList);
        }

        public void UpdateShoppingListName(int id, string name)
        {
            var oldShoppingList = FindShoppingList(id);

            if (oldShoppingList == null)
            {
                throw new ArgumentException($"Shopping list by id {id} was not found.");
            }

            oldShoppingList.ShopName = name;
        }

        public void UpdateShoppingList(int id, ShoppingList update)
        {
            var oldShoppingList = FindShoppingList(id);

            if (oldShoppingList == null)
            {
                throw new ArgumentException($"Shopping list by id {id} was not found.");
            }

            oldShoppingList.Update(update);
        }

        public void AddItem(int shoppingListId, Item item)
        {
            var shoppingList = FindShoppingList(shoppingListId);

            if (shoppingList == null)
            {
                throw new ArgumentException($"Shopping list by id {shoppingListId} was not found.");
            }

            shoppingList.Add(item);
        }
    }
}
