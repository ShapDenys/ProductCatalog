using ProductCatalog;

namespace ProductCatalogMAUI;

public partial class DetailsPage : ContentPage
{
    // Page gets a product from outside - this is "data passing"
    public DetailsPage(Product product)
    {
        InitializeComponent();
        BindingContext = product;   // Label with {Binding ...} reads from this object
        descriptionLabel.Text = product.Description(); // Description() executes on sertain object
    }

    private async void ReturnToList_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}