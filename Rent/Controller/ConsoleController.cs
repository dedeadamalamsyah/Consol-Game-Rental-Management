using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Controller
{
    internal class ConsoleController : Model.Connection
    {
        public DataTable readConsole()
        {
            DataTable data = new DataTable();

            try
            {
                string read = "SELECT * FROM consoles";
                da = new MySqlDataAdapter(read, GetConn());
                da.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public void addConsole(int id, string brand, string name, string available)
        {
            string add = "INSERT INTO consoles VALUES (@idconsole, @brand, @name, @available)";

            try
            {
                cmd = new MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@available", MySqlDbType.VarChar).Value = available;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add Failed, " + e.Message);
            }
        }

        public void updateConsole(int id, string brand, string name, string available)
        {
            string update = "UPDATE consoles SET brand = @brand, name = @name, available = @available WHERE idconsole = " + id;

            try
            {
                cmd = new MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@available", MySqlDbType.Enum).Value = available;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Failed, " + e.Message);
            }
        }

        public void deleteConsole(int id)
        {
            string delete = "DELETE FROM consoles WHERE idconsole = @idconsole";

            try
            {
                cmd = new MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Failed, " + e.Message);
            }
        }
    }
}
