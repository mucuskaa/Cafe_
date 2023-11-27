﻿using Cafe.Models;
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
    public partial class AddNewTableWindow : Window
    {
        private readonly TableService tableService;
        private TableModel tableModel;
        public AddNewTableWindow()
        {
            InitializeComponent();
            tableService = new TableService();
        }

        private void bAddTable_Click(object sender, RoutedEventArgs e)
        {
            string newTableStatus = tbTableStatus.Text;

            bool success = newTableStatus != null;
            if (success)
            {
                tableModel = new TableModel()
                {
                    Status=newTableStatus,
                    Order=null,
                    Waiter=null,
                };
                tableService.AddTableToDb(tableModel);
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
