using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Service : Product
    {
        public override double StockValue => 0; // Services don't have stock value

        public override string Description()
        {
            return $"Service: {Name}, Price: {Price}";
        }
    }
}
