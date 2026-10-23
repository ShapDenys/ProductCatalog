namespace ProductCatalog;

public static class ProductSearch
{
    public static IEnumerable<Product> Search(IEnumerable<Product> products, string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return products;

        string trimmedQuery = query.Trim();
        return products.Where(p => p.Name.Contains(trimmedQuery, StringComparison.OrdinalIgnoreCase));
    }
}