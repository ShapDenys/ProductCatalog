using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class AccessoryTests
{
    [TestMethod]
    public void CheckAccessoryDescriptionIncludesColor()
    {
        var accessory = new Accessory
        {
            Name = "Test Accessory",
            Price = 20.0,
            Category = 'A',
            Quantity = 10,
            Color = "Red"
        };

        var description = accessory.Description();

        Assert.Contains(accessory.Color, description, "Description does not include the color.");
    }
}
