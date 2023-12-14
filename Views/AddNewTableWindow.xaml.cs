using Cafe.Models;
using Cafe.Services;
using System;
using System.Windows;

namespace Cafe.View
{
    public partial class AddNewTableWindow : Window
    {
        private readonly TableService tableService;
        private TableModel tableModel;
        public AddNewTableWindow()
        {
            InitializeComponent();
            tableService = new ();
        }       

        private void bAddTable_Click_1(object sender, RoutedEventArgs e)
        {
            string newTableStatus = tbTableStatus.Text;

            bool success = !String.IsNullOrWhiteSpace(newTableStatus);
            if (success)
            {
                tableModel = new TableModel()
                {
                    Status = (Common.TableStatus)tbTableStatus.SelectedIndex
                };

                try
                {
                    tableService.AddTableToDb(tableModel);
                    ((MainWindow)Owner)?.LoadTables();
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
