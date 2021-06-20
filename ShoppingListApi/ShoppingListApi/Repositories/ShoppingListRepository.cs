using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Mappers;
using System.Collections.Generic;
using System.Linq;
using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;


namespace ShoppingListApi.Repositories
{
    public interface IShoppingListRepository
    {
        void Add(Domain.ShoppingList shoppingList);
        IEnumerable<Domain.ShoppingList> GetByName(string name);
        IEnumerable<Domain.ShoppingList> Get();
        Domain.ShoppingList Get(int id);
        void Delete(int id);
        void Update(int id, string name);
        void Update(int id, Domain.ShoppingList update);
    }

    public class ShoppingListRepository : IShoppingListRepository
    {
        private Db.ShoppingContext _context;

        public ShoppingListRepository(Db.ShoppingContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.ShoppingList> GetByName(string name)
        {
            return _context
                .ShoppingLists
                .Include(sl => sl.Items)
                .Where(list => list.ShopName == name)
                .Select(list => list.Map());
        }

        public void Add(Domain.ShoppingList shoppingList)
        {
            var dbShoppingList = shoppingList.Map();
            _context.Add(dbShoppingList);
            _context.SaveChanges();
        }

        public IEnumerable<Domain.ShoppingList> Get()
        {
            return _context.ShoppingLists
                .Include(sl => sl.Items)
                .ToList()
                .Select(sl => sl.Map());
        }

        public Domain.ShoppingList Get(int id)
        {
            return _context.ShoppingLists
                .Include(sl => sl.Items)
                .FirstOrDefault(sl => sl.Id == id)
                .Map();
        }

        public void Update(int id, Domain.ShoppingList shoppingList)
        {
            var shoppingListInDb = _context.ShoppingLists.Find(id);
            shoppingListInDb.ShopName = shoppingList.ShopName;
            shoppingListInDb.Address = shoppingList.Address;

            _context.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var shoppingList = _context.ShoppingLists.Find(id);
            shoppingList.ShopName = name;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbShoppingList = _context.ShoppingLists.Find(id);
            _context.Remove(dbShoppingList);
            _context.SaveChanges();
        }
    }
}
