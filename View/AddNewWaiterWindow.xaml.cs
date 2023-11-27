using Cafe.Services;
using Cafe.Models;
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
    public partial class AddNewWaiterWindow : Window
    {
        private readonly WaiterService waiterService;
        private WaiterModel waiterModel;
        private List<TableModel> tableModels;
        private readonly TableService tableService;
        public AddNewWaiterWindow()
        {
            InitializeComponent();
            waiterService = new WaiterService();
            tableService = new TableService();
            tableModels = tableService.GetAllTables();
        }

        private void bAddWaiter_Click(object sender, RoutedEventArgs e)
        {
            string newWaiterName = tbWaiterName.Text;
            string newwaiterSurname = tbWaiterSurname.Text;
            string input = tbTableNumber.Text;
            int newWaiterTableId;

            bool success = int.TryParse(input, out newWaiterTableId) && newWaiterName != null && newwaiterSurname != null;
            if (success)
            {
                waiterModel = new WaiterModel()
                {
                    Name = newWaiterName,
                    Surname = newwaiterSurname,
                    Table = tableModels.SingleOrDefault(t => t.Id == newWaiterTableId),
                };
                waiterService.AddWaiterToDb(waiterModel);
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
