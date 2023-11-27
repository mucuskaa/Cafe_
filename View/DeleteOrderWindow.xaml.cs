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
    /// Логика взаимодействия для DeleteOrderWindow.xaml
    /// </summary>
    public partial class DeleteOrderWindow : Window
    {
        private readonly OrderService orderService;
        private List<OrderModel> orderModels;
       public DeleteOrderWindow()
        {
            InitializeComponent();
            orderService=new OrderService();
        }

        private void bDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            string input = tbOrderId.Text;
            int orderId;
            orderModels = orderService.GetAllOreders();

            bool success = int.TryParse(input, out orderId) && orderModels.Any(mi => mi.Id == orderId);
            if (success)
            {
                orderService.DeleteOrderFromDb(orderId);
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
