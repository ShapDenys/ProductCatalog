using ProductCatalog;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ProductCatalogWPF
{
    public partial class MainWindow : Window
    {
        private readonly List<Product> _products;
        private Product? _selectedProduct;

        public double WarehouseTotal { get; }

        public MainWindow()
        {
            InitializeComponent();

            _products = new List<Product>
            {
                new Product { Name = "Prebuild PC", Price = 2499.99, Category = 'C', Quantity = 3 },
                new Parts { Name = "Motherboard", Price = 155.99, Category = 'P', Quantity = 5, Producer = "MSI" },
                new Service { Name = "Reapply Thermal Interface", Price = 20.0, Category = 'S', Quantity = 3, Producer = "ASUS" },
                new Accessory { Name = "Pink Catgirl-headphones for Tomasz", Price = 15.0, Category = 'A', Quantity = 10, Color = "#FFB7CE" }
            };

            WarehouseTotal = Warehouse.CalculateTotalWarehouseValue(_products);
            productsListBox.ItemsSource = _products;
        }

        private void ProductsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedProduct = productsListBox.SelectedItem as Product;
            productDetailsPanel.DataContext = _selectedProduct;
            LoadProductIntoEditor();
            saveButton.IsEnabled = _selectedProduct is not null;
            cancelButton.IsEnabled = _selectedProduct is not null;
            producerTextBox.IsEnabled = _selectedProduct is Parts or Service;
            colorTextBox.IsEnabled = _selectedProduct is Accessory;
        }

        private void LoadProductIntoEditor()
        {
            if (_selectedProduct is null)
            {
                nameTextBox.Clear();
                categoryComboBox.SelectedItem = null;
                priceTextBox.Clear();
                quantityTextBox.Clear();
                stockValueTextBlock.Text = string.Empty;
                producerTextBox.Clear();
                colorTextBox.Clear();
                feedbackLabel.Text = string.Empty;
                return;
            }

            nameTextBox.Text = _selectedProduct.Name;
            categoryComboBox.SelectedValue = _selectedProduct.Category.ToString();
            priceTextBox.Text = _selectedProduct.Price.ToString("F2");
            quantityTextBox.Text = _selectedProduct.Quantity.ToString();
            stockValueTextBlock.Text = _selectedProduct.StockValue.ToString("C");
            producerTextBox.Text = string.Empty;
            if (_selectedProduct is Parts parts)
            {
                producerTextBox.Text = parts.Producer;
            }
            else if (_selectedProduct is Service service)
            {
                producerTextBox.Text = service.Producer;
            }

            colorTextBox.Text = string.Empty;
            if (_selectedProduct is Accessory accessory)
            {
                colorTextBox.Text = accessory.Color;
            }
            feedbackLabel.Text = string.Empty;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedProduct is null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(nameTextBox.Text)
                || categoryComboBox.SelectedValue is not string category
                || !double.TryParse(priceTextBox.Text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out var price)
                || price < 0
                || !uint.TryParse(quantityTextBox.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var quantity))
            {
                SetFeedback("Enter a name, category, valid price, and non-negative quantity.", isError: true);
                return;
            }

            try
            {
                _selectedProduct.Name = nameTextBox.Text.Trim();
                _selectedProduct.Category = category[0];
                _selectedProduct.Price = price;
                _selectedProduct.Quantity = quantity;

                if (_selectedProduct is Parts parts)
                {
                    parts.Producer = producerTextBox.Text.Trim();
                }
                else if (_selectedProduct is Service service)
                {
                    service.Producer = producerTextBox.Text.Trim();
                }
                else if (_selectedProduct is Accessory accessory)
                {
                    accessory.Color = colorTextBox.Text.Trim();
                }

                productsListBox.Items.Refresh();
                LoadProductIntoEditor();
                SetFeedback("Product saved successfully.", isError: false);
            }
            catch (ArgumentException ex)
            {
                SetFeedback(ex.Message, isError: true);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            LoadProductIntoEditor();
            SetFeedback("Changes cancelled.", isError: false);
        }

        private void SetFeedback(string message, bool isError)
        {
            feedbackLabel.Text = message;
            feedbackLabel.Foreground = isError ? Brushes.Firebrick : Brushes.ForestGreen;
        }

    }
}