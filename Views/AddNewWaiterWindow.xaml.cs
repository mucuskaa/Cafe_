using Cafe.Models;
using Cafe.Services;
using System;
using System.Windows;

namespace Cafe.View
{
    public partial class AddNewWaiterWindow : Window
    {
        private readonly WaiterService waiterService;

        public AddNewWaiterWindow()
        {
            InitializeComponent();
            waiterService = new();
        }

        private void bAddWaiter_Click(object sender, RoutedEventArgs e)
        {
            string newWaiterName = tbWaiterName.Text;
            string newwaiterSurname = tbWaiterSurname.Text;

            if (!String.IsNullOrWhiteSpace(newWaiterName) && !String.IsNullOrWhiteSpace(newwaiterSurname))
            {
                var waiterModel = new WaiterModel()
                {
                    Name = newWaiterName,
                    Surname = newwaiterSurname,
                };

                try
                {
                    waiterService.AddWaiterToDb(waiterModel);
                    ((MainWindow)Owner)?.LoadWaiters();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }              
            }
            else
            {
                MessageBox.Show("Incorrect input");
            }

            Close();
        }
    }
}
