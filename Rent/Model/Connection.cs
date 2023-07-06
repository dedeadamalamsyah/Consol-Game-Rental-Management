using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Rent.Model
{
    internal class Connection
    {
        public MySqlCommand cmd;
        public DataSet ds;
        public MySqlDataAdapter da;
        public MySqlDataReader dr;

        public MySqlConnection GetConn()
        {
            MySqlConnection Conn = new MySqlConnection();
            Conn.ConnectionString = "server = localhost; user = root; database = gc_rental";
            try
            {
                Conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed" + ex.Message);
            }
            return Conn;
        }
    }
}
