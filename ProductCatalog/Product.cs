namespace ProductCatalog;

public class Product
{
    public const int MaxNameLength = 100;

    public string Name { get; set; }
    public double Price { get; set; }
    public char Category { get; set; }
    public uint Quantity { get; set; }
    public double StockValue { get { return Price * Quantity; } }

    public bool IsValid() => Validate().Count == 0;

    public static bool IsValid(object? value) => value switch
    {
        Product product => product.IsValid(),
        double maxPrice => double.IsFinite(maxPrice) && maxPrice >= 0,
        char category => category is 'A' or 'B' or 'C',
        _ => false
    };

    public IReadOnlyList<string> Validate()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(Name))
        {
            errors.Add("Product name is required.");
        }
        else if (Name.Trim().Length > MaxNameLength)
        {
            errors.Add($"Product name cannot be longer than {MaxNameLength} characters.");
        }

        if (!double.IsFinite(Price) || Price < 0)
        {
            errors.Add("Price must be a finite number greater than or equal to 0.");
        }

        if (Category is not ('A' or 'B' or 'C'))
        {
            errors.Add("Category must be A, B or C.");
        }

        return errors;
    }

    public static void DisplayProductInfo(Product product)
    {
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Quantity: {product.Quantity}");
        Console.WriteLine($"Stock Value: {product.StockValue}");
    }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}";
    }

    public List<Product> GetTestData(uint amount)
    {
        Random random = new Random();
        var products = new List<Product>();
         
        for (int i = 0; i < amount; i++)
        {
            products.Add(
                new Product {
                    Name = $"Product {i + 1}",
                    Price = Math.Round(random.NextDouble() * 100, 2),
                    Category = (char)('A' + random.Next(0, 3)),
                    Quantity = (uint)random.Next(1, 100)
                }
            );
        }

        return products;
    }
}
