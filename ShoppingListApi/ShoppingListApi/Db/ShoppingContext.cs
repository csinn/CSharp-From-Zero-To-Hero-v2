using System;
using System.Collections.Generic;
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
        public ShoppingContext(DbContextOptions<ShoppingContext> options): base(options)
        {
        }

        public ShoppingContext(): base(UseSqlite())
        {
        }

        private static DbContextOptions UseSqlite()
        {
            return new DbContextOptionsBuilder()
                .UseSqlite()
                .Options;
        }
    }
}
