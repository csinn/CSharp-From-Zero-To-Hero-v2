using System;
using System.Collections.Generic;
using System.Text;
using ShoppingListApi.Models;
using ShoppingListApi.Repositories;
using ShoppingListApi.Services;
using Xunit;

namespace ShoppingListApi.Tests
{
    public class ShoppingListServiceTests : DbTests
    {
        private readonly ShoppingListRepository _shoppingListRepository;
        private readonly ItemsRepository _itemsRepository;

        public ShoppingListServiceTests()
        {
            _shoppingListRepository = new ShoppingListRepository(Context);
            _itemsRepository = new ItemsRepository(Context);
        }

        [Fact]
        public void RemoveShoppingList_WhenNonExistingShoppingListId_ThrowsArgumentException()
        {
            const int nonExistingShoppingListId = 0;
            var service = new ShoppingListService(_shoppingListRepository, _itemsRepository);
            
            Action removeNonExistingShoppingList = () => service.RemoveShoppingList(nonExistingShoppingListId);

            Assert.Throws<ArgumentException>(removeNonExistingShoppingList);
        }

        [Fact]
        public void RemoveShoppingList_WhenShoppingListExists_RemovesIt()
        {
            const int existingShoppingListId = 1;
            var service = new ShoppingListService(_shoppingListRepository, _itemsRepository);
            var removedShoppingList = new ShoppingList {Id = existingShoppingListId};
            service.Add(removedShoppingList);

            service.RemoveShoppingList(existingShoppingListId);

            var shoppingLists = service.Get();
            Assert.DoesNotContain(removedShoppingList, shoppingLists);
        }
    }
}
