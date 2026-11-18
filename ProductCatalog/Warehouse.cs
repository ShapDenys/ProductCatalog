using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Warehouse
    {
        public static double CalculateTotalWarehouseValue(IEnumerable<Product> products)
        {
            return products.Sum(product => product.StockValue);
        }
    }
}
