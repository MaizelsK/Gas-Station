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
        double totalPrice;

        public MainWindow()
        {
            InitializeComponent();

            productCart = new ObservableCollection<Product>();

            fuelTypes = new ObservableCollection<Fuel>
            {
               new Fuel() {Name="92", LitrePrice=158},
               new Fuel() {Name="95", LitrePrice=178},
               new Fuel() {Name="98", LitrePrice=188},
               new Fuel() {Name="Дизель", LitrePrice=160},
            };

            products = new List<Product>
            {
                new Product {Name="Snickers", Price = 150},
                new Product {Name="KitKat", Price = 150},
                new Product {Name="Twix", Price = 150},
                new Product {Name="Mars", Price = 150},
                new Product {Name="Сэндвич", Price = 300},
                new Product {Name="Энергетик", Price = 500},
                new Product {Name="Печенье", Price = 250},
                new Product {Name="Масло", Price = 3000},
                new Product {Name="Канистра", Price = 1500},
                new Product {Name="Жвачка", Price = 100},
            };

            fuelStack.ItemsSource = fuelTypes;
            marketGrid.ItemsSource = products;
            cartGrid.ItemsSource = productCart;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            productCart.Add((Product)marketGrid.SelectedItem);
        }

        private void СalculateButton_Click(object sender, RoutedEventArgs e)
        {
            totalPrice = 0;

            foreach(var product in productCart)
            {
                totalPrice += product.Price;
            }

            foreach(var fuel in fuelTypes)
            {
                if(fuel.Amount != 0)
                {
                    totalPrice += fuel.Amount * fuel.LitrePrice;
                }
            }

            MessageBox.Show($"К оплате: {totalPrice} тенге");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            productCart.RemoveAt(cartGrid.SelectedIndex);
        }

        private void DeleteAllButton_Click(object sender, RoutedEventArgs e)
        {
            productCart.Clear();
        }
    }
}
