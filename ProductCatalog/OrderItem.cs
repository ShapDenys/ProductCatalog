using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog;

public class OrderItem
{
    // Each item consists of a product and its quantity
    public Product Product { get; set; }
    public int Quantity { get; private set; }

    // Constructor accepts a product and its quantity
    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    // Helper property - order item value = product price * quantity
    public double Value => Product.Price * Quantity;

    // Method to increase product quantity in the order
    public void AddQuantity(int quantity) => Quantity += quantity;
}
