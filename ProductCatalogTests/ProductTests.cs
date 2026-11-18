using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class ProductTests
{
    private static IEnumerable<Product> ReadyTestProducts()
    {
        var random = new Random(0);

        for (var i = 0; i < 100; i++)
        {
            yield return new Product
            {
                Name = $"Product {i + 1}",
                Price = Math.Round(random.NextDouble() * 100, 2),
                Category = (char)('A' + random.Next(0, 3)),
                Quantity = (uint)random.Next(1, 20)
            };
        }
    }

    [TestMethod]
    public void CheckIfThereAreThreeCategories()
    {
        var products = ReadyTestProducts();
        var categories = products.Select(product => product.Category).Distinct().ToList();

        Assert.HasCount(3, categories, $"Expected 3 categories, but found {categories.Count}.");
    }

    [TestMethod]
    public void CheckIfEachCategoryHasFiveOrMoreProducts()
    {
        var categoryGroups = ReadyTestProducts().GroupBy(product => product.Category);

        foreach (var group in categoryGroups)
        {
            Assert.IsGreaterThanOrEqualTo(5, group.Count(), $"Category {group.Key} has less than 5 products.");
        }
    }

    [TestMethod]
    public void TestStockValue()
    {
        var product = ReadyTestProducts().First();
        var expectedStockValue = product.Price * product.Quantity;

        Assert.AreEqual(expectedStockValue, product.StockValue, $"Stock value is incorrect, expected {expectedStockValue}");
    }

    [TestMethod]
    public void TestIfThereAreAnyProducts()
    {
        Assert.IsTrue(ReadyTestProducts().Any(), "There are no products available.");
    }

    [TestMethod]
    public void CountAllProducts()
    {
        Assert.AreEqual(100, ReadyTestProducts().Count(), "Expected 100 products.");
    }

    [TestMethod]
    public void CheckPriceAndQuantity()
    {
        foreach (var product in ReadyTestProducts())
        {
            Assert.IsGreaterThanOrEqualTo(0.0, product.Price, $"Product {product.Name} has a negative price.");
            Assert.IsGreaterThanOrEqualTo(0u, product.Quantity, $"Product {product.Name} has a negative quantity.");
        }
    }
}
