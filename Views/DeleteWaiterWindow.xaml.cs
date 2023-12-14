using Cafe.Services;
using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Логика взаимодействия для DeleteWaiterWindow.xaml
    /// </summary>
    public partial class DeleteWaiterWindow : Window
    {
        private readonly WaiterService waiterService;

       public DeleteWaiterWindow()
        {
            InitializeComponent();
            waiterService = new ();
        }

        private void bDeleteWaiter_Click(object sender, RoutedEventArgs e)
        {
            string input = tbWaiterId.Text;

            bool success = int.TryParse(input, out int waiterId) && waiterService.DoesExist(waiterId);
            if (success)
            {
                waiterService.DeleteWaiterFromDb(waiterId);
                ((MainWindow)Owner)?.LoadWaiters();
            }
            else
            {
                MessageBox.Show("Incorrect input");               
            }

            Close();    
        }
    }
}
