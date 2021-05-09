using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApi.Services
{
    public class ShoppingListService
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
