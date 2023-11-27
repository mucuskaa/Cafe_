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
    /// Логика взаимодействия для DeleteTableWindow.xaml
    /// </summary>
    public partial class DeleteTableWindow : Window
    {
        private readonly TableService tableService;
        private List<TableModel>  tableModels;
        public DeleteTableWindow()
        {
            InitializeComponent();
            tableService= new TableService();
        }

        private void bDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            string input = tbTableNumber.Text;
            int tableId;

            tableModels=tableService.GetAllTables();

            bool success = int.TryParse(input, out tableId) && tableModels.Any(mi => mi.Id == tableId);
            if (success)
            {
                tableService.DeleteTableFromDb(tableId);
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
