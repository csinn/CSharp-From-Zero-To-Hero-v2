using System;
using System.Collections.Generic;
using System.Text;
using ShoppingListApi.Models;
using ShoppingListApi.Services;
using Xunit;

namespace ShoppingListApi.Tests
{
    public class ShoppingListServiceTests
    {
        [Fact]
        public void RemoveShoppingList_WhenNonExistingShoppingListId_ThrowsArgumentException()
        {
            const int nonExistingShoppingListId = 0;
            var service = new ShoppingListService();
            
            Action removeNonExistingShoppingList = () => service.RemoveShoppingList(nonExistingShoppingListId);

            Assert.Throws<ArgumentException>(removeNonExistingShoppingList);
        }

        [Fact]
        public void RemoveShoppingList_WhenShoppingListExists_RemovesIt()
        {
            const int existingShoppingListId = 1;
            var service = new ShoppingListService();
            var removedShoppingList = new ShoppingList {Id = existingShoppingListId};
            service.Add(removedShoppingList);

            service.RemoveShoppingList(existingShoppingListId);

            var shoppingLists = service.Get();
            Assert.DoesNotContain(removedShoppingList, shoppingLists);
        }
    }
}
