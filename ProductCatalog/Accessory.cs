using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Accessory : Product
    {
        public string Color { get; set; }

        public override string Description()
        {
            return $"Accessory: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}, Color: {Color}, Stock Value: {StockValue}";
        }
    }
}
