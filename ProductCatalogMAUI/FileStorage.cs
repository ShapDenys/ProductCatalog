using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ProductCatalog;

namespace ProductCatalogMAUI
{
    public class FileStorage
    {
        private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "products.json");

        /// <summary>
        /// Asynchronously saves a collection of products to a JSON file in the application's data directory.
        /// </summary>
        /// <param name="products">List of products to save.</param>
        /// <returns>Task representing the asynchronous operation.</returns>

        public static async Task SaveAsync(IEnumerable<Product> products)
        {
            string json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        /// <summary>
        /// Asynchronously loads a collection of products from a JSON file in the application's data directory.
        /// </summary>
        /// <remarks>Errors during JSON deserialization are ignored, and an empty list is returned.</remarks>
        /// <returns>Task representing the asynchronous operation.</returns>

        public static async Task<IEnumerable<Product>> LoadAsync()
        {
            if (!File.Exists(filePath))
            {
                return new List<Product>();
            }
            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<IEnumerable<Product>>(json) ?? new List<Product>();
        }
    }
}
