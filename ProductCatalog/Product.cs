using System.ComponentModel;

namespace ProductCatalog;

public class Product : IPriced, IComparable<Product>, INotifyPropertyChanged
{
    private string _name = string.Empty;
    private double _price;
    private char _category;
    private uint _quantity;

    private bool _isAvailable = true;

    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            if (_price != value)
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }

    public char Category
    {
        get => _category;
        set
        {
            if (_category != value)
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
    }

    public uint Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    public bool IsAvailable
    {
        get => _isAvailable;
        set
        {
            if (_isAvailable != value)
            {
                _isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
    }

    public virtual double StockValue => Price * Quantity;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public static void DisplayProductInfo(Product product)
    {
        Console.WriteLine($"Name: {product.Name}");
        Console.WriteLine($"Price: {product.Price}");
        Console.WriteLine($"Category: {product.Category}");
        Console.WriteLine($"Quantity: {product.Quantity}");
        Console.WriteLine($"Stock Value: {product.StockValue}");
    }

    public virtual string Description()
    {
        return $"Product: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}";
    }

    public List<Product> GetTestData(uint amount)
    {
        var random = new Random();
        var products = new List<Product>();

        for (var i = 0; i < amount; i++)
        {
            products.Add(new Product
            {
                Name = $"Product {i + 1}",
                Price = Math.Round(random.NextDouble() * 100, 2),
                Category = (char)('A' + random.Next(0, 3)),
                Quantity = (uint)random.Next(1, 100)
            });
        }

        return products;
    }

    public static List<Product> Search(List<Product> products, string name)
    {
        return products
            .Where(product =>
                product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public int CompareTo(Product? other)
    {
        if (other is null)
        {
            return 1;
        }

        return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
    }
}
