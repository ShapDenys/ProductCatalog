using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class ServiceTests
{
    [TestMethod]
    public void CheckServiceStockValue()
    {
        var service = new Service
        {
            Name = "Test Service",
            Price = 100.0,
            Category = 'S',
            Quantity = 1
        };

        Assert.AreEqual(0, service.StockValue, "Stock value for Service should be 0.");
    }
}
