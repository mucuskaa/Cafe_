using System;
using System.Collections.Generic;
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
using Cafe.Models;
using Cafe.Services;

namespace Cafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OrderService orderService;
        private List<OrderModel> orders;

        public MainWindow()
        {
            orderService = new OrderService();
            orders = new List<OrderModel>();
            InitializeComponent();
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            cbOrders.IsEnabled = true;
        }

        private void cbOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = sender as ComboBox;
            int index = list.SelectedIndex;
            OrderModel currentOrder = orders[index];

            tbOrder.Text=currentOrder.Id.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // dgTables.ItemsSource;
            LoadOrders();
            cbOrders.ItemsSource = orders.Select(o => o.Date);
        }

        private void LoadOrders()
        {
            orders = orderService.GetOredersByDate(DateTime.Now);

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    CafeDbContext dbContext = new CafeDbContext();

        //    Cafe.Entities.MenuItem menuItem = new Cafe.Entities.MenuItem()
        //    {
        //        Name = "Salad",
        //        Price = 25
        //    };

        //    dbContext.MenuItems.Add(menuItem);

        //    dbContext.SaveChanges();
        //}
    }
}
