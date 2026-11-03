using ProductCatalog;

var productCatalog = new Product();
var products = productCatalog.GetTestData(10);

var productsInCategories = new Dictionary<char, List<Product>>();

Console.WriteLine("Enter the maximum price: ");
string? maxPriceInput = Console.ReadLine();
double maxPrice = double.TryParse(maxPriceInput, out double parsedMaxPrice) ? parsedMaxPrice : 100.0;


foreach (var product in products)
{
    if (!productsInCategories.ContainsKey(product.Category))
    {
        productsInCategories[product.Category] = new List<Product>();
    }
    productsInCategories[product.Category].Add(product);
}

Console.WriteLine("Which product category do you want to see? ");
string? selectedCategoryInput = Console.ReadLine();
char selectedCategory = !string.IsNullOrEmpty(selectedCategoryInput) ? selectedCategoryInput[0] : 'A';

Console.WriteLine($"---Products in category {selectedCategory}---");
if (productsInCategories.TryGetValue(selectedCategory, out var categoryProducts))
{
    foreach (var product in categoryProducts)
    {
        Product.DisplayProductInfo(product);
    }
}
else
{
    Console.WriteLine("No products found in this category.");
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

// Inheritance and method overriding demonstration
// The list is of type Product, but can store objects of classes inheriting from Product
List<Product> inheritedProducts = new List<Product>
{
    new Product { Name = "Product1", Price = 10.0, Category = 'A', Quantity = 5 },
    new Parts { Name = "Part1", Price = 25.0, Category = 'B', Quantity = 2, Producer = "Producer1" },
    new Accessory { Name = "Accessory1", Price = 15.0, Category = 'B', Quantity = 3, Color = "Black" },
    new Service { Name = "Service1", Price = 50.0, Category = 'C', Quantity = 1 }
};

foreach (var product in inheritedProducts)
{
    Console.WriteLine(product.Description());
}

// This works because all classes inherit from Product, which implements IComparable<Product>,
// so we can sort the list of inherited products by Price
inheritedProducts.Sort();

// Sort inherited products alphabetically by name
var productsAlphabetically = inheritedProducts.OrderBy(p => p.Name).ToList();
