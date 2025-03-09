using System.Windows;
using System.Windows.Navigation;

namespace school
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Navigate(new MainPage());
        }
    }
}

