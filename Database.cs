using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace school
{
    class database
    {
        public MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=fortytwo_band; port=3306; password=123456789");
        public List<Participants> get_Participants()
        {
            List<Participants> Participants_list = new List<Participants>();
            try
            {
                connection.Open();
                string query = "select * from Participants";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Participants participant = new Participants();
                    participant.id_participant = Convert.ToInt32(reader["id_participant"]);
                    participant.FirstName = reader["FirstName"].ToString();
                    participant.LastName = reader["LastName"].ToString();
                    participant.nickname = reader["nickname"].ToString();
                    participant.Star_of_hype = Convert.ToInt32(reader["Star_of_hype"]);
                    Participants_list.Add(participant);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return Participants_list;
        }
        public void insert_participant(string FirstName, string LastName, string nickname, int Star_of_hype)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Participants (FirstName, LastName, nickname, Star_of_hype) VALUES (@FirstName,@LastName,@nickname,@Star_of_hype)", connection);
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@nickname", nickname);
                command.Parameters.AddWithValue("@Star_of_hype", Star_of_hype);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Leaders> get_leaders()
        {
            List<Leaders> Leaders_list = new List<Leaders>();
            try
            {
                connection.Open();
                string query = "select * from Leaders";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Leaders leader = new Leaders();
                    leader.id_leader = Convert.ToInt32(reader["id_leader"]);
                    leader.participants_id = Convert.ToInt32(reader["participants_id"]);
                    Leaders_list.Add(leader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return Leaders_list;
        }
        public void insert_leaders(int participants_id)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Leaders (participants_id) VALUES (@participants_id)", connection);
                command.Parameters.AddWithValue("@participants_id", participants_id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Costumes> get_Costumes()
        {
            List<Costumes> Costumes_list = new List<Costumes>();
            try
            {
                connection.Open();
                string query = "select * from Costumes";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Costumes costume = new Costumes();
                    costume.id_dress = Convert.ToInt32(reader["id_dress"]);
                    costume.headwear = reader["headwear"].ToString();
                    costume.wear = reader["wear"].ToString();
                    costume.pants = reader["pants"].ToString();
                    costume.boots = reader["boots"].ToString();
                    Costumes_list.Add(costume);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return Costumes_list;
        }

        public Costumes get_Costume(int participantsID)
        {
            Costumes costume = null;
            try
            {
                connection.Open();
                string query = "SELECT * FROM Costumes WHERE participant_id = @participants_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@participants_id", participantsID);
                command.ExecuteNonQuery();

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    costume = new Costumes();
                    costume.id_dress = Convert.ToInt32(reader["id_dress"]);
                    costume.headwear = reader["headwear"].ToString();
                    costume.wear = reader["wear"].ToString();
                    costume.pants = reader["pants"].ToString();
                    costume.boots = reader["boots"].ToString();
                    costume.participants_id = Convert.ToInt32(reader["participants_id"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return costume;
        }
        public void insert_costume(string headwear, string wear, string pants, string boots)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Costumes (headwear, wear, pants, boots) VALUES (@headwear,@wear,@pants,@boots)", connection);
                command.Parameters.AddWithValue("@headwear", headwear);
                command.Parameters.AddWithValue("@wear", wear);
                command.Parameters.AddWithValue("@pants", pants);
                command.Parameters.AddWithValue("@boots", boots);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }
        public List<Socials> get_Socials(int participantsID)
        {
            List<Socials> Socials_list = new List<Socials>();
            try
            {
                connection.Open();
                string query = "select * from Socials where participant_id = @participants_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@participants_id", participantsID);
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Socials social = new Socials();
                    social.id_social = Convert.ToInt32(reader["id_social"]);
                    social.account_name = reader["account_name"].ToString();
                    social.follower = Convert.ToInt32(reader["follower"]);
                    social.participant_id = Convert.ToInt32(reader["participant_id"]);
                    Socials_list.Add(social);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
            return Socials_list;
        }

        public void delete_leader(int participants_id)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM Leaders WHERE (participants_id) = (@participants_id)", connection);
                command.Parameters.AddWithValue("@participants_id", participants_id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void delete_participants(int id_participant)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM Participants WHERE (id_participant) = (@id_participant)", connection);
                command.Parameters.AddWithValue("@id_participant", id_participant);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            finally
            {
                connection.Close();
            }
        }


        public void update_costume(int id_participant, string headwear, string wear, string pants, string boots)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("UPDATE Costumes SET headwear = @headwear, wear = @wear, pants = @pants, boots = @boots WHERE participant_id = @id_participant;)", connection);
                command.Parameters.AddWithValue("@id_participant", id_participant);
                command.Parameters.AddWithValue("@headwear", headwear);
                command.Parameters.AddWithValue("@wear", wear);
                command.Parameters.AddWithValue("@pants", pants);
                command.Parameters.AddWithValue("@boots", boots);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public void insert_costume(string headwear,string wear,string pants,string boots, int participant_id)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO Costumes (headwear,wear,pants,boots,participant_id) VALUES (@headwear,@wear,@pants,@boots,@participants_id)", connection);
                command.Parameters.AddWithValue("@headwear", headwear);
                command.Parameters.AddWithValue("@wear", wear);
                command.Parameters.AddWithValue("@pants", pants);
                command.Parameters.AddWithValue("@boots", boots);
                command.Parameters.AddWithValue("@participants_id", participant_id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RecordExists(string tableName, string columnName, object value)
        {
            try
            {
                connection.Open();

                // Создаем SQL-запрос для проверки существования записи в указанной таблице
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value";

                // Создаем объект команды и добавляем параметр
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@value", value);

                // Выполняем запрос и получаем количество записей
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0; // Возвращаем true, если запись существует
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false; // Возврат false в случае ошибки
            }
            finally
            {
                connection.Close();
            }
        }
    }
}