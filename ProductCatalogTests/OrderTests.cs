using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class OrderTests
{
    [TestMethod]
    public void OrderAddNegativeQuantityThrowsException()
    {
        var order = new Order();
        var product = new Product { Name = "Test Product", Price = 10, Quantity = 1 };

        var exception = Assert.ThrowsExactly<ArgumentException>(() => order.Add(product, -1));

        StringAssert.Contains(exception.Message, "Quantity must be greater than zero.", "Adding product with quantity <= 0 should throw ArgumentException.");
    }
}
