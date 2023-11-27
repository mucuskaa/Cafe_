using Cafe.Models;
using Cafe.Services;
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

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для DeleteItemWindow.xaml
    /// </summary>
    public partial class DeleteItemWindow : Window
    {
        private readonly MenuItemService menuItemService;
        private List<MenuItemModel> menuItemModels;
        public DeleteItemWindow()
        {
            InitializeComponent();
            menuItemService = new MenuItemService();
        }

        private void bDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            string input = tbItemNumber.Text;
            int itemId;

            menuItemModels = menuItemService.GetAllMenuItems();

            bool success = int.TryParse(input, out itemId) && menuItemModels.Any(mi=>mi.Id==itemId);
            if (success)
            {
                menuItemService.DeleteItemFromDn(itemId);
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
