using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    // Class Parts inherits from Product class, representing a specific part in the product catalog.
    public class Parts : Product
    {
        public string Producer { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}, Producer: {Producer}";
        }
    }
}
