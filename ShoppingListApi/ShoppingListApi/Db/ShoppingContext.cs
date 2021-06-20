using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShoppingListApi.Db
{
    public class ShoppingContext : DbContext
    {
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<Item> Items { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(SqliteOptionsAction);
        //}

        // Supports injecting any provider we want

        public ShoppingContext() : base(UseSqlite())
        {
        }

        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
        }

        private static DbContextOptions<ShoppingContext> UseSqlite()
        {
            return new DbContextOptionsBuilder<ShoppingContext>()
                .UseSqlite(@"DataSource=ShoppingList.db;")
                .LogTo(m => Debug.WriteLine(m))
                .Options;
        }
    }
}
