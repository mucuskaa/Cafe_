using Cafe.Models;
using Cafe.Services;
using System;
using System.Windows;


namespace Cafe.View
{
    /// <summary>
    /// Interaction logic for AddNewItemWindow.xaml
    /// </summary>
    public partial class AddNewItemWindow : Window
    {
        private readonly MenuItemService menuItemService;

        public AddNewItemWindow()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();
        }

        private void bAddItem_Click(object sender, RoutedEventArgs e)
        {
            string newItemName = tbItemName.Text;
            string input = tbItemPrice.Text;

            bool success = Int32.TryParse(input, out int newItemPrice) && !String.IsNullOrWhiteSpace(newItemName);
            if (success)
            {
                var menuItemModel = new MenuItemModel()
                {
                    Name = newItemName,
                    Price = newItemPrice,
                };

                try
                {
                    menuItemService.AddItemToDb(menuItemModel);
                    ((MainWindow)Owner)?.LoadMenuItems();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Incorrect input");            
            }

            Close();
        }
    }
}
