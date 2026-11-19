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
            Color = "#FF0000"
        };

        var description = accessory.Description();

        Assert.Contains(accessory.Color, description, "Description does not include the color.");
    }

    [DataTestMethod]
    [DataRow("#123")]
    [DataRow("#1a2B")]
    [DataRow("#123456")]
    [DataRow("#aBcDeF12")]
    public void ColorAcceptsValidHexFormats(string color)
    {
        var accessory = new Accessory
        {
            Color = color
        };

        Assert.AreEqual(color, accessory.Color);
    }

    [TestMethod]
    public void ColorHasValidDefaultValue()
    {
        var accessory = new Accessory();

        Assert.AreEqual("#000000", accessory.Color);
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow("Red")]
    [DataRow("123456")]
    [DataRow("#12")]
    [DataRow("#12345")]
    [DataRow("#12345G")]
    [DataRow("#123456789")]
    public void ColorRejectsInvalidHexFormats(string color)
    {
        var accessory = new Accessory();

        Assert.ThrowsExactly<ArgumentException>(() => accessory.Color = color);
    }
}
