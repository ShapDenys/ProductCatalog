using ProductCatalog;

namespace Product_Catalog
{
    public partial class MainPage : ContentPage
    {
        public List<Product> Products { get; } = Product.GetTestData(10);

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnClickChangeColor(object? sender, EventArgs e)
        {
            var rnd = new Random();

            ProductNameLabel.TextColor = Color.FromRgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
        }
    }
}
