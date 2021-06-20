using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Db;
using Xunit;

namespace ShoppingListApi.Tests
{
    public class DbTests
    {
        protected ShoppingContext Context { get; set; }

        public DbTests()
        {
            Context = new ShoppingContext(
                new DbContextOptionsBuilder<ShoppingContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options);
        }

        [Fact]
        public void Test()
        {
            Assert.Empty(Context.Items);
        }
    }
}
