using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog;

public class Order
{
    // Internal list of order items, not directly accessible from outside
    private readonly List<OrderItem> items = new List<OrderItem>();

    // External list of order items, accessible from outside without allowing modification
    public IReadOnlyList<OrderItem> Items => items;

    // Method to add an order item
    public void Add(IPriced product, int quantity)
    {
        // First check if quantity is valid
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        // If item already exists, increase its quantity, otherwise add new item
        var existingItem = items.FirstOrDefault(p => p.Product == product);
        if (existingItem != null)
            existingItem.AddQuantity(quantity);
        else
            items.Add(new OrderItem(product, quantity));
    }

    // Helper property - total sum of values of all order items
    public double OrderValue => items.Sum(p => p.Value);
}
