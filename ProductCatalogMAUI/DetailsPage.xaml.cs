using ProductCatalog;

namespace ProductCatalogMAUI;

public partial class DetailsPage : ContentPage, IQueryAttributable
{
    private Product? product;

    public DetailsPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["product"] is Product product)
        {
            this.product = product;
            BindingContext = product;
            nameEntry.Text = product.Name;
            categoryEntry.Text = product.Category.ToString();
            priceEntry.Text = product.Price.ToString();
            quantityEntry.Text = product.Quantity.ToString();
            descriptionLabel.Text = product.Description();
            stockValueLabel.Text = $"Stock Value: {product.StockValue:C}";
            errorLabel.IsVisible = false;
            successLabel.IsVisible = false;
        }
    }

    private void Save_Clicked(object sender, EventArgs e)
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

    private async void ReturnToList_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}