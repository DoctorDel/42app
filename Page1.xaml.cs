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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        database db = new database();
        public Page1()
        {
            InitializeComponent();
            LoadParticipants();
        }
        private void LoadParticipants()
        {
            var participants_table = db.get_Participants();
            ParticipantListBox.ItemsSource = participants_table;
        }
        private void add_participant_Click(object sender, RoutedEventArgs e)
        {
            string firstname = firstname_box.Text;
            string lastname = lastname_box.Text;
            string nickname = nickname_box.Text;
            string strOFhype = stofhype_box.Text;


            if (!string.IsNullOrEmpty(firstname) && !string.IsNullOrEmpty(lastname) && !string.IsNullOrEmpty(nickname) && !string.IsNullOrEmpty(strOFhype))
            {
                try
                {
                    db.insert_participant(firstname, lastname, nickname, Convert.ToInt32(strOFhype));
                    firstname_box.Clear();
                    lastname_box.Clear();
                    nickname_box.Clear();
                    stofhype_box.Clear();
                    var participant = ParticipantListBox.ItemsSource as List<Participants>;
                    participant.Add(new Participants { FirstName = firstname, LastName = lastname, nickname = nickname, Star_of_hype = Convert.ToInt32(strOFhype) });
                    ParticipantListBox.Items.Refresh();
                }
                catch (Exception)
                {
                    MessageBox.Show("Проверьте корректность вводимых данных");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
            }
        }

        private void delete_participant_click(object sender, RoutedEventArgs e)
        {
            string code = participant_id_to_delete.Text;
            if (db.RecordExists("Participants", "id_participant", Convert.ToInt32(code)))
            {
                if (!string.IsNullOrEmpty(code))
                {
                    try
                    {
                        int participantId = Convert.ToInt32(code);
                        db.delete_participants(participantId);
                        participant_id_to_delete.Clear();
                        ParticipantListBox.ItemsSource = db.get_Participants();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Проверьте корректность вводимых данных.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Произошла ошибка: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Такого 42 не существует","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
