using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class WarehouseTests
{
    [TestMethod]
    public void DoesMixedWarehouseReturnCorrectValueIgnoringServices()
    {
        var mixedItems = new List<Product>
        {
            new Product { Name = "Wireless Mouse", Price = 80, Category = 'A', Quantity = 5 },
            new Service { Name = "Installation Service", Price = 300, Category = 'S', Quantity = 1 },
            new Product { Name = "Mouse Pad", Price = 40, Category = 'A', Quantity = 8 }
        };

        var totalValue = Warehouse.CalculateTotalWarehouseValue(mixedItems);

        Assert.AreEqual(720, totalValue, "Services should not be included in the warehouse value.");
    }

    [TestMethod]
    public void DoesEmptyWarehouseReturnZeroValue()
    {
        var totalValue = Warehouse.CalculateTotalWarehouseValue([]);

        Assert.AreEqual(0, totalValue, "Total warehouse value for an empty list should be 0.");
    }
}
