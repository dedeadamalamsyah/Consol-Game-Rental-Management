using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Controller
{
    internal class ReturnController : Model.Connection
    {
        public DataTable readReturn()
        {
            DataTable data = new DataTable();

            try
            {
                string read = "SELECT * FROM returns";
                da = new MySqlDataAdapter(read, GetConn());
                da.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public void addReturn(int idrent, int idconsole, string custname, DateTime returndate, string delay, string fine)
        {
            string add = "INSERT INTO returns VALUES (@idrent, @idconsole, @custname, @returndate, @delay, @fine)";

            try
            {
                cmd = new MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@idrent", MySqlDbType.Int32).Value = idconsole;
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = idconsole;
                cmd.Parameters.Add("@custname", MySqlDbType.VarChar).Value = custname;
                cmd.Parameters.Add("@returndate", MySqlDbType.DateTime).Value = returndate;
                cmd.Parameters.Add("@delay", MySqlDbType.Int32).Value = delay;
                cmd.Parameters.Add("@fine", MySqlDbType.Int32).Value = fine;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add Failed, " + e.Message);
            }
        }

        public void deleteReturn(int id)
        {
            string delete = "DELETE FROM rent WHERE idrent = @idrent";

            try
            {
                cmd = new MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@idrent", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Failed, " + e.Message);
            }
        }
    }
}
