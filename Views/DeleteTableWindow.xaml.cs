using Cafe.Services;
using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для DeleteTableWindow.xaml
    /// </summary>
    public partial class DeleteTableWindow : Window
    {
        private readonly TableService tableService;
        public DeleteTableWindow()
        {
            InitializeComponent();
            tableService= new();
        }

        private void bDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            string input = tbTableNumber.Text;

            bool success = int.TryParse(input, out int tableId) && tableService.DoesExist(tableId);
            if (success)
            {
                tableService.RemoveTableFromDb(tableId);
                ((MainWindow)Owner)?.LoadTables();
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }

            Close();
        }

    }
}
