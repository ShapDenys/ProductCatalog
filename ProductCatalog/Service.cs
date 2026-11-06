using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Service : Product
    {
        public string Producer { get; set; } = string.Empty;

        public override double StockValue => 0; // Services don't have stock value

        public override string Description()
        {
            return $"Service: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}, Producer: {Producer}, Stock Value: {StockValue}";
        }
    }
}
