using Cafe.Services;
using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для DeleteItemWindow.xaml
    /// </summary>
    public partial class DeleteItemWindow : Window
    {
        private readonly MenuItemService menuItemService;
        public DeleteItemWindow()
        {
            InitializeComponent();
            menuItemService = new();
        }

        private void bDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            string input = tbItemNumber.Text;

            bool success = int.TryParse(input, out int itemId) && menuItemService.DoesExist(itemId);
            if (success)
            {
                menuItemService.RemoveMenuItemFromDb(itemId);
                ((MainWindow)Owner)?.LoadMenuItems();
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }

            Close();
        }
    }
}
