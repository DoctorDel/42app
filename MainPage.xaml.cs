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

namespace school
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnNavigateToPage1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void OnNavigateToPage2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void OnNavigateToPage3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void OnNavigateToPage4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }
    }
}
