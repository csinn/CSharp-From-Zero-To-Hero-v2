using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingListApi.Models;
using ShoppingListApi.Repositories;

namespace ShoppingListApi.Services
{
    public interface IShoppingListService
    {
        decimal CalculateTotalCost();
        void Add(ShoppingList shoppingList);
        IEnumerable<ShoppingList> Get();
        ShoppingList FindShoppingList(int id);
        void RemoveShoppingList(int id);
        void UpdateShoppingListName(int id, string name);
        void UpdateShoppingList(int id, ShoppingList update);
        void AddItem(int shoppingListId, Item item);
    }

    public class ShoppingListService: IShoppingListService
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IItemsRepository _itemsRepository;

        public ShoppingListService(IShoppingListRepository shoppingListRepository, IItemsRepository itemsRepository)
        {
            _shoppingListRepository = shoppingListRepository;
            _itemsRepository = itemsRepository;
        }

        public IEnumerable<ShoppingList> GetByName(string name)
        {
            return _shoppingListRepository.GetByName(name);
        }

        public decimal CalculateTotalCost()
        {
            return _shoppingListRepository.Get()
                .Select(sl => sl.CalculateTotalCost())
                .Sum();
        }

        public void Add(ShoppingList shoppingList)
        {
            _shoppingListRepository.Add(shoppingList);
        }

        public IEnumerable<ShoppingList> Get()
        {
            return _shoppingListRepository.Get();
        }

        public ShoppingList FindShoppingList(int id)
        {
            return _shoppingListRepository.Get(id);
        }

        public void RemoveShoppingList(int id)
        {
            _shoppingListRepository.Delete(id);
        }

        public void UpdateShoppingListName(int id, string name)
        {
            _shoppingListRepository.Update(id, name);
        }

        public void UpdateShoppingList(int id, ShoppingList update)
        {
            _shoppingListRepository.Update(id, update);
        }

        public void AddItem(int shoppingListId, Item item)
        {
            _itemsRepository.Create(shoppingListId, item);
        }
    }
}
