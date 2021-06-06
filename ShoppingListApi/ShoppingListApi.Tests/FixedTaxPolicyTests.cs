using System;
using ShoppingListApi.Models;
using Xunit;

namespace ShoppingListApi.Tests
{
    public class FixedTaxPolicyTests
    {
        [Fact]
        public void Apply_ReturnsPriceAfterTaxes()
        {
            // Arrange
            const decimal priceBeforeTaxes = 2;
            const decimal taxes = 1.1m;
            var fixedTaxPolicy = new FixedTaxPolicy(taxes);

            // Act
            var priceAfterTaxes = fixedTaxPolicy.Apply(priceBeforeTaxes);

            // Assert
            const decimal expectedPriceAfterTaxes = 2.2m;
            Assert.Equal(expectedPriceAfterTaxes, priceAfterTaxes);
        }
    }
}
