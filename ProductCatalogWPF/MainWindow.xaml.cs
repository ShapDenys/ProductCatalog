using ProductCatalog;
using System.Windows;

namespace ProductCatalogWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var products = new List<Product>
            {
                new Parts { Name = "Part A", Price = 10.0, Category = 'P', Quantity = 5, Producer = "Producer A" },
                new Service { Name = "Service B", Price = 20.0, Category = 'S', Quantity = 3, Producer = "Producer B" },
                new Accessory { Name = "Accessory C", Price = 15.0, Category = 'A', Quantity = 10, Color = "#FFFFFF" }
            };

            productsDataGrid.ItemsSource = products;
        }
    }
}