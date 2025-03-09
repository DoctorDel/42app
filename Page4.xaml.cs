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
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        database db = new database();
        public Page4()
        {
            InitializeComponent();
            LoadParticipants();
        }
        private void LoadParticipants()
        {
            var participants_table = db.get_Participants();
            ParticipantListBox.ItemsSource = participants_table;
        }

        private void OnClickFound(object sender, RoutedEventArgs e)
        {
            try
            {
                var socials_table = db.get_Socials(Convert.ToInt32(id_fortytwo.Text));
                SocialListBox.ItemsSource = socials_table;
            }
            catch(Exception)
            {
                MessageBox.Show("Введите корректные данные");
            }
        }
        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
