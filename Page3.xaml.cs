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

    public partial class Page3 : Page
    {
        database db = new database();
        public Page3()
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
                Costumes costume = db.get_Costume(Convert.ToInt32(id_fortytwo.Text));
                List<Costumes> costumesList = new List<Costumes>();
                costumesList.Add(costume);
                CostumeListBox.ItemsSource = costumesList;
                id_fortytwo.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void OnClickUpdate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (db.RecordExists("Costumes", "participant_id", Convert.ToInt32(id_fortytwo_to_update.Text)) && db.RecordExists("Participants", "id_participant", Convert.ToInt32(id_fortytwo_to_update.Text)))
                {
                    var result = MessageBox.Show("Вы уверены, что хотите внести изменения?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes && !string.IsNullOrEmpty(new_headwear.Text) && !string.IsNullOrEmpty(new_wear.Text) && !string.IsNullOrEmpty(new_pants.Text) && !string.IsNullOrEmpty(new_boots.Text) && !string.IsNullOrEmpty(id_fortytwo_to_update.Text))
                    {
                        db.update_costume(Convert.ToInt32(id_fortytwo_to_update.Text), new_headwear.Text, new_wear.Text, new_pants.Text, new_boots.Text);
                        CostumeListBox.Items.Refresh();
                        new_headwear.Clear();
                        new_wear.Clear();
                        new_pants.Clear();
                        new_boots.Clear();
                        id_fortytwo_to_update.Clear();
                        MessageBox.Show("Вы успешно изменили костюм");
                    }
                }
                else if (db.RecordExists("Participants", "id_participant", Convert.ToInt32(id_fortytwo_to_update.Text)))
                {
                    var result = MessageBox.Show("Вы уверены, что хотите добавить костюм?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        db.insert_costume(new_headwear.Text, new_wear.Text, new_pants.Text, new_boots.Text, Convert.ToInt32(id_fortytwo_to_update.Text));
                        CostumeListBox.Items.Refresh();
                        new_headwear.Clear();
                        new_wear.Clear();
                        new_pants.Clear();
                        new_boots.Clear();
                        id_fortytwo_to_update.Clear();
                        MessageBox.Show("Вы успешно добавили новый костюм");
                        CostumeListBox.Items.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Такого 42 не существует!", "Ошибка!", MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            catch (Exception)
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
