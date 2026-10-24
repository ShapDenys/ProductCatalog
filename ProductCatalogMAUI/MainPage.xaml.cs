using Microsoft.Maui.Controls;
using ProductCatalog;
using System.Collections.ObjectModel;

namespace ProductCatalogMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Product> allProducts = new();

        public ObservableCollection<Product> VisibleProducts { get; set; } = new();
        public ObservableCollection<Product> Products => VisibleProducts;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            if (ProductCategoryPicker is not null && ProductCategoryPicker.Items.Count > 0)
            {
                ProductCategoryPicker.SelectedIndex = 0;
            }

            allProducts.AddRange(new Product().GetTestData(5));

            RefreshView();
        }

        private void RefreshView()
        {
            VisibleProducts.Clear();

            foreach (var p in ProductSearch.Search(allProducts, ProductSearchBar?.Text))
            {
                VisibleProducts.Add(p);
            }

            if (ItemsCounterLabel is not null)
            {
                ItemsCounterLabel.Text = $"Showing {VisibleProducts.Count} of {allProducts.Count}";
            }
        }

        private void OnSearchBarTextChanged(object? sender, TextChangedEventArgs e)
        {
            RefreshView();
        }

        private void OnClickAddProduct(object? sender, EventArgs e)
        {
            string newProductName = ProductNameEntry?.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(newProductName))
            {
                ShowError("Product name cannot be empty.");
                return;
            }

            if (!double.TryParse(ProductPriceEntry?.Text, out double newProductPrice) || newProductPrice < 0)
            {
                ShowError("Please enter a valid non-negative price.");
                return;
            }

            if (ProductCategoryPicker?.SelectedItem is null ||
                !char.TryParse(ProductCategoryPicker.SelectedItem.ToString(), out char newProductCategory))
            {
                ShowError("Please select a valid category.");
                return;
            }

            if (!uint.TryParse(ProductQuantityEntry?.Text, out uint newProductQuantity))
            {
                ShowError("Please enter a valid quantity (positive integer).");
                return;
            }

            HideError();

            var newProduct = new Product
            {
                Name = newProductName,
                Price = newProductPrice,
                Category = newProductCategory,
                Quantity = newProductQuantity
            };

            allProducts.Add(newProduct);

            if (ProductNameEntry is not null) ProductNameEntry.Text = string.Empty;
            if (ProductPriceEntry is not null) ProductPriceEntry.Text = string.Empty;
            if (ProductQuantityEntry is not null) ProductQuantityEntry.Text = string.Empty;

            RefreshView();
        }

        private void OnClickRemoveProduct(object? sender, EventArgs e)
        {
            if (ProductsCollectionView?.SelectedItem is Product selectedProduct)
            {
                allProducts.Remove(selectedProduct);
                ProductsCollectionView.SelectedItem = null;
                HideError();
                RefreshView();
            }
            else
            {
                ShowError("Please select a product from the list to remove.");
            }
        }

        private void ShowError(string message)
        {
            if (ErrorMessageLabel is not null)
            {
                ErrorMessageLabel.Text = message;
                ErrorMessageLabel.IsVisible = true;
            }
        }

        private void HideError()
        {
            if (ErrorMessageLabel is not null)
            {
                ErrorMessageLabel.IsVisible = false;
            }
        }
    }
}