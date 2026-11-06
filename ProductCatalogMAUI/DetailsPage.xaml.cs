using ProductCatalog;

namespace ProductCatalogMAUI;

public partial class DetailsPage : ContentPage, IQueryAttributable
{
    // Page gets a product from outside - this is "data passing"
    public DetailsPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["product"] is Product product)
        {
            BindingContext = product;
            descriptionLabel.Text = product.Description();
        }
    }

    private async void ReturnToList_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}