using ProductCatalog;
using System.Collections.ObjectModel;

namespace ProductCatalogMAUI
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>(new Product().GetTestData(5));

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        //private void OnClickChangeColor(object? sender, EventArgs e)
        //{
        //    var rnd = new Random();

        //    ProductNameLabel.TextColor = Color.FromRgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        //}

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
            Products.Add(newProduct);
        }
    }
}
