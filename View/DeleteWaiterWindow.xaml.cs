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
    /// Логика взаимодействия для DeleteWaiterWindow.xaml
    /// </summary>
    public partial class DeleteWaiterWindow : Window
    {
        private readonly WaiterService waiterService;
        private List<WaiterModel> waiterModels;

       public DeleteWaiterWindow()
        {
            InitializeComponent();
            waiterService = new WaiterService();
        }

        private void bDeleteWaiter_Click(object sender, RoutedEventArgs e)
        {
            string input = tbWaiterId.Text;
            int waiterId;
            waiterModels = waiterService.GetAllWaiters();

            bool success = int.TryParse(input, out waiterId) && waiterModels.Any(mi => mi.Id == waiterId);
            if (success)
            {
                waiterService.DeleteWaiterFromDb(waiterId);
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
