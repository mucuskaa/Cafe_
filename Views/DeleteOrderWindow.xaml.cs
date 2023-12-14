using Cafe.Services;
using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для DeleteOrderWindow.xaml
    /// </summary>
    public partial class DeleteOrderWindow : Window
    {
        private readonly OrderService orderService;

       public DeleteOrderWindow()
        {
            InitializeComponent();
            orderService = new ();
        }

        private void bDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            string input = tbOrderId.Text;

            bool success = int.TryParse(input, out int orderId) && orderService.DoesExist(orderId);
            if (success)
            {
                orderService.RemoveOrderFromDb(orderId);
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }

            Close();
        }
    }
}
