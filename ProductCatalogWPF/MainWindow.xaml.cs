using ProductCatalog;
using System.Windows;

namespace ProductCatalogWPF
{
    public partial class MainWindow : Window
    {
        public double WarehouseTotal { get; }

        public MainWindow()
        {
            InitializeComponent();

            var products = new List<Product>
            {
                new Product { Name = "Prebuild PC", Price = 2499.99, Category = 'C', Quantity = 3 },
                new Parts { Name = "Motherboard", Price = 155.99, Category = 'P', Quantity = 5, Producer = "MSI" },
                new Service { Name = "Reapply Thermal Interface", Price = 20.0, Category = 'S', Quantity = 3, Producer = "ASUS" },
                new Accessory { Name = "Pink Catgirl-headphones for Tomasz", Price = 15.0, Category = 'A', Quantity = 10, Color = "#FFB7CE" }
            };

            WarehouseTotal = Warehouse.CalculateTotalWarehouseValue(products);
            productsListBox.ItemsSource = products;
        }

        private void ProductsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            productDetailsPanel.DataContext = productsListBox.SelectedItem;
        }
    }
}