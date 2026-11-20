using ProductCatalog;

namespace ProductCatalogMAUI;

public partial class DetailsPage : ContentPage, IQueryAttributable
{
    private Product? product;
    private List<Product>? products;

    public DetailsPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["product"] is Product product)
        {
            this.product = product;
            products = query["products"] as List<Product>;
            BindingContext = product;
            nameEntry.Text = product.Name;
            categoryEntry.Text = product.Category.ToString();
            priceEntry.Text = product.Price.ToString();
            quantityEntry.Text = product.Quantity.ToString();
            IsAvailableCheckBox.IsChecked = product.IsAvailable;
            descriptionLabel.Text = product.Description();
            stockValueLabel.Text = $"Stock Value: {product.StockValue:C}";
            errorLabel.IsVisible = false;
            successLabel.IsVisible = false;
        }
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (product is null)
        {
            ShowError("No product selected.");
            return;
        }

        string name = nameEntry.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
        {
            ShowError("Product name cannot be empty.");
            return;
        }

        if (!char.TryParse(categoryEntry.Text?.Trim(), out char category))
        {
            ShowError("Category must contain one character.");
            return;
        }

        if (!double.TryParse(priceEntry.Text, out double price) || price < 0)
        {
            ShowError("Please enter a valid non-negative price.");
            return;
        }

        if (!uint.TryParse(quantityEntry.Text, out uint quantity))
        {
            ShowError("Please enter a valid quantity.");
            return;
        }

        product.Name = name;
        product.Category = category;
        product.Price = Math.Round(price, 2);
        product.Quantity = quantity;
        product.IsAvailable = IsAvailableCheckBox.IsChecked;
        if (products is not null)
        {
            await FileStorage.SaveAsync(products);
        }
        descriptionLabel.Text = product.Description();
        stockValueLabel.Text = $"Stock Value: {product.StockValue:C}";
        errorLabel.IsVisible = false;
        successLabel.Text = "Product data saved successfully.";
        successLabel.IsVisible = true;
    }

    private void ShowError(string message)
    {
        errorLabel.Text = message;
        errorLabel.IsVisible = true;
        successLabel.IsVisible = false;
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        if (product is null || products is null)
        {
            ShowError("No product selected.");
            return;
        }

        bool confirmed = await DisplayAlertAsync(
            "Delete product",
            $"Are you sure you want to delete '{product.Name}'?",
            "Delete",
            "Cancel");

        if (!confirmed)
        {
            return;
        }

        products.Remove(product);
        await FileStorage.SaveAsync(products);
        await Shell.Current.GoToAsync("..");
    }

    private async void ReturnToList_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}