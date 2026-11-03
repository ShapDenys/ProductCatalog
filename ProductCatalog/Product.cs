namespace ProductCatalog;

public class Product : IPriced, IComparable<Product>
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public char Category { get; set; }
    public uint Quantity { get; set; }
    public virtual double StockValue { get { return Price * Quantity; } }


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

    public virtual string Description()
    {
        return $"Product: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}";
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

    /// <summary>
    /// Implementation of IComparable for product allowing comparison of two products by price
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public int CompareTo(Product? other)
    {
        // If other object is null, this object is greater (since 1 > 0)
        if (other == null) return 1;
        // Otherwise return comparison of product prices
        return this.Price.CompareTo(other.Price);
    }

    public static List<Product> Search(List<Product> products, string name)
    {
        List<Product> foundProducts = new List<Product>();
        // Foreach loop to search product list and add matching products
        foreach (var product in products)
        {
            if (product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                foundProducts.Add(product);
            }
        }
        // Alternatively LINQ can be used:
        foundProducts.Clear();
        foundProducts = products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return foundProducts;
    }
}
