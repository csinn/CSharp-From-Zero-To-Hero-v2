using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using ShoppingListApi.Services;

namespace ShoppingListApi.Controllers
{
    // This is an attribute.
    // It adds metadata to a class.
    // Something, somewhere will read this attribute
    // And apply extra logic to the class.
    [ApiController]
    // Discoverable endpoint: api/ShoppingList
    [Route("api/[controller]")]
    // : ControllerBase is called inheritance.
    // We take methods and state from ControllerBase
    // and now we are able to use them.
    public class ShoppingListController : ControllerBase
    {
        private static ShoppingListService _shoppingListService = new ShoppingListService();
        private static ItemsGenerator _itemsGenerator = new ItemsGenerator();

        [HttpGet("total")]
        public IActionResult GetTotalPrice()
        {
            var totalCost = _shoppingListService.CalculateTotalCost();
            return Ok(totalCost);
        }

        // Allows using a POST http verb.
        // IActionResult allows different types of result to be returned.
        // Specifically, it allows different status codes to be returned.
        // If we don't use IActionResult, we will be left with just 2 options:
        // - either 200 or 500.
        // With IActionresult we can return any status code possible.
        // Usually is used for creating new resources or running complex queries.
        [HttpPost("basic")]
        public IActionResult Create(ShoppingList shoppingList)
        {
            _shoppingListService.Add(shoppingList);

            return Created("/shoppinglist/basic", shoppingList);
        }

        [HttpPost("taxed")]
        public IActionResult Create(TaxedShoppingList shoppingList)
        {
            _shoppingListService.Add(shoppingList);

            return Created("/shoppinglist/taxed", shoppingList);
        }

        [HttpGet("item/random")]
        public IActionResult GetRandomItem()
        {
            var item = _itemsGenerator.Generate();

            return Ok(item);
        }

        // Allows using a GET http verb.
        [HttpGet]
        public IActionResult Get()
        {
            // Never return resource directly, always return it through Ok() or similar.
            var shoppingLists = _shoppingListService.Get();
            
            return Ok(shoppingLists);
        }

        // Allows using a GET http verb
        // {id}- is a custom route- a placeholder for the value that comes as an argument.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shoppingList = _shoppingListService.FindShoppingList(id);

            if (shoppingList == null)
            {
                return NotFound($"Shopping list by id {id} was not found.");
            }

            return Ok(shoppingList);
        }

        // Allows using a PATCH http verb
        // Patch updates a part of a resource.
        [HttpPatch("{shoppingListId}")]
        public IActionResult AddItem(int shoppingListId, Item item)
        {
            try
            {
                _shoppingListService.AddItem(shoppingListId, item);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        // Allows using a PUT http verb
        // Overrides resource with the new values.
        [HttpPut("{id}")]
        public IActionResult UpdateShoppingList(int id, ShoppingList shoppingList)
        {
            try
            {
                _shoppingListService.UpdateShoppingList(id, shoppingList);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpPatch("{id}/updateName")]
        public IActionResult UpdateShoppingListName(int id, ShoppingList shoppingList)
        {
            try
            {
                _shoppingListService.UpdateShoppingListName(id, shoppingList.ShopName);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        // Allows using a DELETE http verb
        // Deletes resource.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _shoppingListService.RemoveShoppingList(id);
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
