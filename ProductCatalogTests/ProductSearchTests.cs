using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;

namespace ProductCatalogTests;

[TestClass]
public sealed class ProductSearchTests
{
    [TestMethod]
    public void SearchProductsByName()
    {
        var products = PrepareProductsList();
        const string searchName = "Product1";

        var foundProducts = Product.Search(products, searchName);

        foreach (var product in foundProducts)
        {
            StringAssert.Contains(product.Name, searchName, $"Found product {product.Name} should contain '{searchName}' in its name.");
        }
    }

    [TestMethod]
    public void SearchProductsByName_FoundProductsCount()
    {
        var products = PrepareProductsList();
        const string searchName = "000";

        var foundProducts = Product.Search(products, searchName);

        Assert.AreEqual(9, foundProducts.Count, "Number of found products should equal 9.");
    }

    [TestMethod]
    public void Search_MatchingQuery_ReturnsMatchingProducts()
    {
        var result = ProductSearch.Search(CreateSearchTestData(), "Mouse").ToList();

        Assert.HasCount(2, result);
    }

    [TestMethod]
    public void Search_EmptyQuery_ReturnsAllProducts()
    {
        var result = ProductSearch.Search(CreateSearchTestData(), "").ToList();

        Assert.HasCount(3, result);
    }

    [TestMethod]
    public void Search_NoMatchQuery_ReturnsEmptyList()
    {
        var result = ProductSearch.Search(CreateSearchTestData(), "Monitor").ToList();

        Assert.IsEmpty(result);
    }

    private static List<Product> PrepareProductsList()
    {
        var random = new Random(0);
        var products = new List<Product>();

        for (var i = 0; i < 10000; i++)
        {
            products.Add(new Product
            {
                Name = $"Product{i}",
                Price = random.NextDouble() * 100,
                Category = (char)('A' + random.Next(0, 3)),
                Quantity = (uint)random.Next(1, 20)
            });
        }

        return products;
    }

    private static List<Product> CreateSearchTestData() =>
    [
        new Product { Name = "Wireless Mouse", Price = 80, Category = 'A', Quantity = 5 },
        new Product { Name = "Keyboard", Price = 150, Category = 'B', Quantity = 2 },
        new Product { Name = "Mouse Pad", Price = 40, Category = 'A', Quantity = 8 }
    ];
}
