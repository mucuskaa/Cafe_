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
    /// Interaction logic for AddNewItemWindow.xaml
    /// </summary>
    public partial class AddNewItemWindow : Window
    {
        public AddNewItemWindow()
        {
            InitializeComponent();
        }

        private void bAddItem_Click(object sender, RoutedEventArgs e)
        {
            string newItemName=tbItemName.Text;
            string input=tbItemPrice.Text;
            int newItemPrice;

            bool success = int.TryParse(input, out newItemPrice);
            //if (!success)
            //{
                
            //}

            CafeDbContext dbContext = new CafeDbContext();

            Cafe.Entities.MenuItem menuItem = new Cafe.Entities.MenuItem()
            {
                Name = newItemName,
                Price = newItemPrice
            };

            dbContext.MenuItems.Add(menuItem);

            dbContext.SaveChanges();
        }
    }
}
