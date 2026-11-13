using ProductCatalog;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            productsListBox.ItemsSource = products.Select(product =>
                $"{product.Name} | Kategoria: {product.Category} | " +
                $"Cena: {product.Price:C} | Ilość: {product.Quantity} | " +
                $"Wartość: {product.StockValue:C}")
                .ToList();
        }
    }
}