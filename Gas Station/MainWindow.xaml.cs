using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gas_Station
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> products;
        ObservableCollection<Product> productCart;
        ObservableCollection<Fuel> fuelTypes;
        double totalPrice = 0;

        public MainWindow()
        {
            InitializeComponent();

            productCart = new ObservableCollection<Product>();

            fuelTypes = new ObservableCollection<Fuel>
            {
               new Fuel() {Name="92", litrePrice=158},
               new Fuel() {Name="95", litrePrice=178},
               new Fuel() {Name="98", litrePrice=188},
               new Fuel() {Name="Дизель", litrePrice=160},
            };

            products = new List<Product>
            {
                new Product {Name="Snickers", Price = 150},
                new Product {Name="KitKat", Price = 151},
                new Product {Name="Twix", Price = 152},
                new Product {Name="Mars", Price = 153},
            };

            fuelStack.ItemsSource = fuelTypes;
            marketGrid.ItemsSource = products;
            cartGrid.ItemsSource = productCart;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            productCart.Add((Product)marketGrid.SelectedItem);

            totalPrice += products[marketGrid.SelectedIndex].Price;
        }

        private void СalculateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"К оплате: {totalPrice} тенге");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            totalPrice -= productCart[cartGrid.SelectedIndex].Price;

            productCart.RemoveAt(cartGrid.SelectedIndex);
        }

        private void FuelAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
