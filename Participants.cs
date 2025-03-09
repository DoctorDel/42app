using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace school
{
    internal class Participants
    {
        public int id_participant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string nickname { get; set; }
        public int Star_of_hype { get; set; }
    }
}
