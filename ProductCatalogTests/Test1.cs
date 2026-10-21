using ProductCatalog;

namespace TestProject1
{
    [TestClass]
    public sealed class Test1
    {
        Random random = new Random();

        IEnumerable<Product> ReadyTestProducts()
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new Product
                {
                    Name = $"Product {i + 1}",
                    Price = Math.Round(random.NextDouble() * 100, 2), // 0 - 100
                    Category = (char)('A' + random.Next(0, 3)), // A, B, or C
                    Quantity = (uint)random.Next(1, 20) // 1 - 20
                };
            }
        }

        [TestMethod]

        public void CheckIfThereAreThreeCategories()
        {
            var products = ReadyTestProducts();
            var categories = products.Select(p => p.Category).Distinct().ToList();
            Assert.AreEqual(3, categories.Count, $"Expected 3 categories, but found {categories.Count}.");
        }

        [TestMethod]

        public void CheckIfEachCategoryHasFiveOrMoreProducts()
        {
            var products = ReadyTestProducts();
            var categoryGroups = products.GroupBy(p => p.Category);
            foreach (var group in categoryGroups)
            {
                Assert.IsTrue(group.Count() >= 5, $"Category {group.Key} has less than 5 products.");
            }
        }

        [TestMethod]

        public void TestStockValue()
        {
            var products = ReadyTestProducts();
            var product = products.First();

            double expectedStockValue = product.Price * product.Quantity;

            Assert.AreEqual(expectedStockValue, product.StockValue, $"Stock value is incorrect, expected {expectedStockValue}");
        }

        [TestMethod]
        public void TestIfThereAreAnyProducts()
        {
            var products = ReadyTestProducts();

            Assert.IsTrue(products.Any(), "There are no products available.");
        }

        [TestMethod]
        public void CountAllProducts()
        {
            var products = ReadyTestProducts();
            int expectedCount = 100;
            int actualCount = products.Count();
            Assert.AreEqual(expectedCount, actualCount, $"Expected {expectedCount} products, but found {actualCount}.");
        }

        [TestMethod]
        public void CheckPriceAndQuantity()
        {
            var products = ReadyTestProducts();
            foreach (var product in products)
            {
                Assert.IsTrue(product.Price >= 0, $"Product {product.Name} has a negative price.");
                Assert.IsTrue(product.Quantity >= 0, $"Product {product.Name} has a negative quantity.");
            }
        }

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
            string description = part.Description();
            Assert.IsTrue(description.Contains(part.Producer), "Description does not include the producer.");
        }

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
            string description = accessory.Description();
            Assert.IsTrue(description.Contains(accessory.Color), "Description does not include the color.");
        }
    }
}
