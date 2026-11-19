using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog
{
    public class Accessory : Product
    {
        private string _color = "#000000";

        public string Color
        {
            get => _color;
            set
            {
                if (!IsHexColor(value))
                {
                    throw new ArgumentException("Color must be a valid HEX color: #RGB, #RGBA, #RRGGBB, or #RRGGBBAA.", nameof(value));
                }

                _color = value;
            }
        }

        private static bool IsHexColor(string? color)
        {
            if (color is null || (color.Length != 4 && color.Length != 5 && color.Length != 7 && color.Length != 9) || color[0] != '#')
            {
                return false;
            }

            for (var i = 1; i < color.Length; i++)
            {
                if (!Uri.IsHexDigit(color[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override string Description()
        {
            return $"Accessory: {Name}, Price: {Price}, Category: {Category}, Quantity: {Quantity}, Color: {Color}, Stock Value: {StockValue}";
        }
    }
}
