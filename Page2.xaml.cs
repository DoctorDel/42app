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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        database db = new database();
        public Page2()
        {
            InitializeComponent();
            LoadParticipants();
            LoadLeader();
        }
        private void LoadParticipants()
        {
            var participants_table = db.get_Participants();
            ParticipantListBox.ItemsSource = participants_table;
        }
        private void LoadLeader()
        {
            var leaders_table = db.get_leaders();
            LeaderListBox.ItemsSource = leaders_table;
        }

        private void add_leader_Click(object sender, RoutedEventArgs e)
        {
            string code = code_box.Text;
            if (!db.RecordExists("Leaders", "participants_id", Convert.ToInt32(code)))
            {
                if (!string.IsNullOrEmpty(code))
                {
                    try
                    {
                        int participantId = Convert.ToInt32(code);
                        db.insert_leaders(participantId);
                        code_box.Clear();
                        LeaderListBox.ItemsSource = db.get_leaders();
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
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                }
            }
            else
            {
                MessageBox.Show("Такой лидер уже существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void delete_leader_click(object sender, RoutedEventArgs e)
        {
            string code = code_box.Text;

            if (db.RecordExists("Leaders", "participants_id", Convert.ToInt32(code)))
            {
                if (!string.IsNullOrEmpty(code))
                {
                    try
                    {
                        int participantId = Convert.ToInt32(code);
                        db.delete_leader(participantId);
                        code_box.Clear();
                        LeaderListBox.ItemsSource = db.get_leaders();
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
                else
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                }
            }
            else
            {
                MessageBox.Show("Такого лидера не существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
