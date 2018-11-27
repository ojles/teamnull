using System.Windows;
using Task3.Pages;

namespace Task3
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

        private void MenuPageClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new MenuPage());
        }

        private void ReceiptPageClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new ReceiptPage());
        }
    }
}
