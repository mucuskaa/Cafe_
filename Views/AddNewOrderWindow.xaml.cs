using Cafe.Models;
using Cafe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewOrderWindow.xaml
    /// </summary>
    public partial class AddNewOrderWindow : Window
    {
        private readonly TableService tableService;
        private readonly OrderService orderService;
        private readonly MenuItemService menuItemService;   
        private readonly WaiterService waiterService;

        private TableModel table = null;
        private WaiterModel waiter = null;
        private List<WaiterModel> waiters;
        private List<MenuItemModel> menu;
        private readonly List<OrderPositionModel> Positions;
        private bool firstAdding = true;

        public AddNewOrderWindow()
        {
            InitializeComponent();
            tableService = new();
            orderService = new(); 
            menuItemService = new();   
            waiterService = new();
            Positions = new();
        }


        private void AddItem()
        {
            if (String.IsNullOrEmpty(cbTable.Text)
            || String.IsNullOrEmpty(cbDish.Text)
            || String.IsNullOrEmpty(cbWaiter.Text)
            || !Int32.TryParse(tbItemQuantity.Text, out int quantity))
            {
                return;
            }

            if (firstAdding)
            {
                table = tableService.GetTableById(Int32.Parse(cbTable.Text));
                waiter = waiters[cbWaiter.SelectedIndex];

                cbTable.IsEnabled = false;
                cbWaiter.IsEnabled = false;

                firstAdding = false;
            }

            Positions.Add(new OrderPositionModel
            {
                MenuItem = menu[cbDish.SelectedIndex],
                Quantity = quantity,
                Status = Common.OrderStatus.Ordered
            });
        }

        private void bAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddItem();

            tbItemQuantity.Text = "1";
            cbDish.Text = String.Empty;
        }  

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!Positions.Select(m => m.MenuItem.Name).Contains(cbDish.Text))
            {
                AddItem();
            }

            var newOrder = new OrderModel
            {
                Table = table,
                Waiter = waiter,
                Positions = this.Positions,
            };

            try
            {
                orderService.AddOrder(newOrder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbItemQuantity.Text = "1";
            waiters = waiterService.GetAllWaiters();
            menu = menuItemService.GetAllAvailiableMenuItems();

            cbDish.ItemsSource = null;
            cbDish.ItemsSource = menu.Select(m => m.Name);
            cbWaiter.ItemsSource = null;
            cbWaiter.ItemsSource = waiters.Select(w => $"{w.Surname} {w.Name}");
            cbTable.ItemsSource = null;
            cbTable.ItemsSource = tableService.GetAllTables().Select(t => t.Id);
        }
    }
}
