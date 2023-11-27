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
using System.Windows.Shapes;
using Cafe.Services;
using Cafe.Models;


namespace Cafe.View
{
    /// <summary>
    /// Interaction logic for AddNewItemWindow.xaml
    /// </summary>
    public partial class AddNewItemWindow : Window
    {
        private readonly MenuItemService menuItemService;
        private MenuItemModel menuItemModel;
        public AddNewItemWindow()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();
        }

        private void bAddItem_Click(object sender, RoutedEventArgs e)
        {
            string newItemName = tbItemName.Text;
            string input = tbItemPrice.Text;
            int newItemPrice;

            bool success = int.TryParse(input, out newItemPrice) && newItemName != null;
            if (success)
            {
                menuItemModel = new MenuItemModel()
                {
                    Name = newItemName,
                    Price = newItemPrice,
                };
                menuItemService.AddItemtoDb(menuItemModel);
            }
            else
            {
                MessageView messageView = new MessageView("Incorrect input");
                messageView.Owner = Application.Current.MainWindow;
                messageView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                messageView.ShowDialog();
            }


        }
    }
}
