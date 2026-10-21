using ProductCatalog;

var productCatalog = new Product();
var products = productCatalog.GetTestData(10);

var productsInCategories = new Dictionary<char, List<Product>>();

Console.WriteLine("Enter the maximum price: ");
double maxPrice = double.Parse(Console.ReadLine());


foreach (var product in products)
{
    if (!productsInCategories.ContainsKey(product.Category))
    {
        productsInCategories[product.Category] = new List<Product>();
    }
    productsInCategories[product.Category].Add(product);
}

Console.WriteLine("Which product category do you want to see? ");
char selectedCategory = char.Parse(Console.ReadLine());

Console.WriteLine($"---Products in category {selectedCategory}---");
foreach (var product in productsInCategories[selectedCategory])
{
    Product.DisplayProductInfo(product);
}

Console.WriteLine($"---Products cheaper than {maxPrice} zł---");
foreach (var product in products.Where(p => p.Price <= maxPrice))
{
    Product.DisplayProductInfo(product);
}

Console.WriteLine("---Sorted by Price---");
foreach (var product in products.OrderBy(p => p.Price))
{
    Product.DisplayProductInfo(product);
}

Console.WriteLine($"---Whole Stock Value---");
Console.WriteLine($"{Math.Round(products.Sum(p => p.StockValue), 2)} zł");

var producerParts = new List<Parts>
{
    new Parts { Name = "Part 1", Price = 10.0, Category = 'A', Quantity = 5, Producer = "Producer A" },
    new Parts { Name = "Part 2", Price = 15.0, Category = 'B', Quantity = 3, Producer = "Producer B" },
    new Parts { Name = "Part 3", Price = 20.0, Category = 'C', Quantity = 2, Producer = "Producer C" }
};

foreach(var part in producerParts)
{
    Console.WriteLine(part.Description());
}