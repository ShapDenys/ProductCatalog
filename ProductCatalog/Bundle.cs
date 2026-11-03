using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog;

public class Bundle : IPriced
{
    private readonly List<Product> components;
    public string Name { get; set; }

    /// <summary>
    /// Create a new bundle based on the provided products
    /// </summary>
    /// <param name="name">Bundle name</param>
    /// <param name="products">List of products</param>
    public Bundle(string name, List<Product> products)
    {
        Name = name;
        components = products ?? new List<Product>();
    }

    /// <summary>
    /// Bundle price is the sum of prices of its components
    /// </summary>
    public double Price => components.Sum(p => p.Price);
}
