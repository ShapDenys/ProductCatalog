using ProductCatalog;

var productCatalog = new Product();
var products = productCatalog.GetTestData(10);

var productsInCategories = new Dictionary<char, List<Product>>();

Console.WriteLine("Enter the maximum price: ");
double maxPrice = ReadMaxPrice();


foreach (var product in products)
{
    if (!productsInCategories.ContainsKey(product.Category))
    {
        productsInCategories[product.Category] = new List<Product>();
    }
    productsInCategories[product.Category].Add(product);
}

Console.WriteLine("Which product category do you want to see? ");
char selectedCategory = ReadCategory();

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

double ReadMaxPrice()
{
    while (true)
    {
        if (double.TryParse(Console.ReadLine(), out var maxPrice) && Product.IsValid(maxPrice))
        {
            return maxPrice;
        }

        Console.WriteLine("Invalid max price. Enter a number greater than or equal to 0:");
    }
}

char ReadCategory()
{
    while (true)
    {
        if (char.TryParse(Console.ReadLine(), out var category))
        {
            category = char.ToUpperInvariant(category);
            if (Product.IsValid(category))
            {
                return category;
            }
        }

        Console.WriteLine("Invalid category. Enter A, B or C:");
    }
}
