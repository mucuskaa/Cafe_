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
using Cafe.View;

namespace Cafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WaiterService waiterService;
        private readonly TableService tableService;
        private readonly MenuItemService menuItemService;
        private readonly OrderService orderService;
        private List<OrderModel> orders;
        private List<TableModel> tables;
        private List<MenuItemModel> menuItems;
        private List<WaiterModel> waiters;

        public MainWindow()
        {
            waiterService=new WaiterService();
            waiters=new List<WaiterModel>();

            tableService = new TableService();
            tables = new List<TableModel>();

            menuItemService = new MenuItemService();
            menuItems = new List<MenuItemModel>();

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
            LoadWaiters();
            dgWaiters.ItemsSource = waiters;
            LoadTables();
            dgTables.ItemsSource=tables;
            LoadMenuItems();
            dgItems.ItemsSource=menuItems;
            LoadOrders();
            cbOrders.ItemsSource = orders.Select(o => o.Date);
        }

        private void LoadOrders()
        {
            orders = orderService.GetOredersByDate(DateTime.Now);
        }

        private void LoadMenuItems()
        {
            menuItems=menuItemService.GetAllMenuItems();
        }

        private void LoadTables()
        {
            tables=tableService.GetAllTablesWithWaiters();
        }

        private void LoadWaiters()
        {
            waiters = waiterService.GetAllWaiters();
        }

        private void bNewTable_Click(object sender, RoutedEventArgs e)
        {
            AddNewTableWindow newTableWindow = new AddNewTableWindow();
            newTableWindow.Owner = Application.Current.MainWindow;
            newTableWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newTableWindow.ShowDialog();
        }

        private void bNewWaiter_Click(object sender, RoutedEventArgs e)
        {
           AddNewWaiterWindow newWaiterWindow = new AddNewWaiterWindow();
            newWaiterWindow.Owner = Application.Current.MainWindow;
            newWaiterWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newWaiterWindow.ShowDialog();
        }

        private void bNewMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddNewItemWindow newItemWindow = new AddNewItemWindow();
            newItemWindow.Owner = Application.Current.MainWindow;
            newItemWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newItemWindow.ShowDialog();
        }


        private void bDeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DeleteItemWindow deleteItemWindow = new DeleteItemWindow();
            deleteItemWindow.Owner = Application.Current.MainWindow;
            deleteItemWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            deleteItemWindow.ShowDialog();
        }

        private void bDeleteWaiter_Click(object sender, RoutedEventArgs e)
        {
            DeleteWaiterWindow deleteWaiterWindow = new DeleteWaiterWindow();
            deleteWaiterWindow.Owner = Application.Current.MainWindow;
            deleteWaiterWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            deleteWaiterWindow.ShowDialog();
        }

        private void bDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            DeleteTableWindow deleteTableWindow=new DeleteTableWindow();
            deleteTableWindow.Owner = Application.Current.MainWindow;
            deleteTableWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            deleteTableWindow.ShowDialog();
        }
    }
}
