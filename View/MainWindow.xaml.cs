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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cafe.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    CafeDbContext dbContext = new CafeDbContext();

        //    Cafe.Entities.MenuItem menuItem = new Cafe.Entities.MenuItem()
        //    {
        //        Name = "Salad",
        //        Price = 25
        //    };

        //    dbContext.MenuItems.Add(menuItem);

        //    dbContext.SaveChanges();
        //}
    }
}
