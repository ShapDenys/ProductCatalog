using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class PartsTests
{
    [TestMethod]
    public void DoesPartDescriptionIncludeProducer()
    {
        var part = new Parts
        {
            Name = "Test Part",
            Price = 10.0,
            Category = 'A',
            Quantity = 5,
            Producer = "Test Producer"
        };

        var description = part.Description();

        Assert.Contains(part.Producer, description, "Description does not include the producer.");
    }
}
