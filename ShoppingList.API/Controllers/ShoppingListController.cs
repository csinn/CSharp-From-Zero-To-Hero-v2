using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShoppingList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private static List<Models.ShoppingList> _shoppingLists = new List<Models.ShoppingList>();

        [HttpPatch("{id}")]
        public IActionResult AddItem(int id, Models.Item item)
        {
            var list = GetListById(id);

            if (list is null) return NotFound($"List with id {id} not found");
            list.ListItems.Add(item);

            return Ok(list.ListItems);
        }

        public IActionResult Create(Models.ShoppingList shoppingList)
        {
            _shoppingLists.Add(shoppingList);

            return Created($"/shoppinglist/{shoppingList.Id}", shoppingList);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var list = GetListById(id);

            if (list is null) return NotFound($"List with id {id} not found");

            _shoppingLists.Remove(list);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_shoppingLists);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var list = GetListById(id);

            if (list is null) return NotFound($"List with id {id} not found");

            return Ok(list);
        }

        private Models.ShoppingList GetListById(int id)
        {
            foreach (var list in _shoppingLists)
            {
                if (list.Id == id) return list;
            }
            return null;
        }
    }
}