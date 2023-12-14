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
using Cafe.Entities;
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
        public List<OrderModel> orders;
        public List<TableModel> tables;
        private List<MenuItemModel> menuItems;
        public List<WaiterModel> waiters;

        public MainWindow()
        {
            waiterService = new();
            waiters= [];

            tableService = new();
            tables = [];

            menuItemService = new ();
            menuItems = [];

            orderService = new ();
            orders = [];

            InitializeComponent();
        }

        private void DatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            cbOrders.IsEnabled = true;

            if (dpDate.SelectedDate.HasValue)
            {
                orders = orderService.GetOredersByDate(dpDate.SelectedDate.Value);
                cbOrders.ItemsSource = null;
                cbOrders.ItemsSource = orders.Select(o => o.Id);  
            }
        }

        private void cbOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbOrder.Text = String.Empty;
            var list = sender as ComboBox;
            int index = list.SelectedIndex;
            OrderModel currentOrder = orders[index];

            if (currentOrder == null) return; 

            foreach (OrderPositionModel op in currentOrder.Positions)
            {
                tbOrder.Text += $"Dish - {op.MenuItem.Name}\n";
                tbOrder.Text += $"Quantity - {op.Quantity}\n";
                tbOrder.Text += new string('-', 50) + '\n';
            }
            
            tbOrder.Text += $"Total {GetTotalPrice(currentOrder)}";
        }

        private double GetTotalPrice(OrderModel order) => order.Positions.Sum(p => p.MenuItem.Price * p.Quantity);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadWaiters();           
            LoadTables();      
            LoadMenuItems();         
            LoadOrders();            
        }

        public void LoadOrders()
        {
            orders = orderService.GetOredersByDate(DateTime.Now);
            cbOrders.ItemsSource = null;
            cbOrders.ItemsSource = orders.Select(o => o.Date);
        }

        public void LoadMenuItems()
        {
            menuItems = menuItemService.GetAllMenuItems();
            dgItems.ItemsSource = null;
            dgItems.ItemsSource = menuItems;
        }

        public void LoadTables()
        {
            tables = tableService.GetAllTables();
            dgTables.ItemsSource = null;
            dgTables.ItemsSource = tables;
        }

        public void LoadWaiters()
        {
            waiters = waiterService.GetAllWaiters();
            dgWaiters.ItemsSource = null;
            dgWaiters.ItemsSource = waiters;
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

        private void bDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrderWindow deleteOrderWindow=new DeleteOrderWindow();
            deleteOrderWindow.Owner = Application.Current.MainWindow;
            deleteOrderWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            deleteOrderWindow.ShowDialog();
        }

        private void bNewOrder_Click(object sender, RoutedEventArgs e)
        {
            AddNewOrderWindow addNewOrderWindow = new();
            addNewOrderWindow.Owner = Application.Current.MainWindow;
            addNewOrderWindow.WindowStartupLocation= WindowStartupLocation.CenterOwner; 
            addNewOrderWindow.ShowDialog(); 
        }
    }
}
