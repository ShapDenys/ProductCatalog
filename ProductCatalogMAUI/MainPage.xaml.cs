using ProductCatalog;
using System.Collections.ObjectModel;

namespace ProductCatalogMAUI
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Product> allProducts = new();

        public ObservableCollection<Product> Products { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            allProducts.AddRange(new Product().GetTestData(5));

            RefreshView();
        }

        private void RefreshView()
        {
            Products.Clear();

            foreach (var p in ProductSearch.Search(allProducts, ProductSearchBar?.Text))
            {
                Products.Add(p);
            }

            if (ItemsCounterLabel is not null)
            {
                ItemsCounterLabel.Text = $"Showing {Products.Count} of {allProducts.Count}";
            }
        }

        private void OnSearchBarTextChanged(object? sender, TextChangedEventArgs e)
        {
            RefreshView();
        }

        private void OnClickAddProduct(object? sender, EventArgs e)
        {
            string newProductName = ProductNameEntry.Text;
            double newProductPrice = double.Parse(ProductPriceEntry.Text);
            char newProductCategory = char.Parse(ProductCategoryPicker.SelectedItem.ToString());
            uint newProductQuantity = uint.Parse(ProductQuantityEntry.Text);

            var newProduct = new Product
            {
                Name = newProductName,
                Price = newProductPrice,
                Category = newProductCategory,
                Quantity = newProductQuantity
            };

            allProducts.Add(newProduct);
            RefreshView();
        }

        private void OnClickRemoveProduct(object? sender, EventArgs e)
        {
            if (ProductsCollectionView.SelectedItem is Product selectedProduct)
            {
                allProducts.Remove(selectedProduct);
                RefreshView();
            }
        }
    }
}