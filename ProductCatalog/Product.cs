namespace ProductCatalog;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public char Category { get; set; }
    public uint Quantity { get; set; }
    public double StockValue { get { return Price * Quantity; } }

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
