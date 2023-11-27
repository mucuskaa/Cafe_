using System.Windows;

namespace Cafe.View
{
    /// <summary>
    /// Interaction logic for MessageView.xaml
    /// </summary>
    public partial class MessageView : Window
    {
        public MessageView(string text)
        {
            InitializeComponent();
            MessageText.Text = text;
        }

        private void bCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
            
        }
    }
}
