using Guna.UI2.WinForms;
using MySqlConnector;
using Rent.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Controller
{
    internal class RentController : Model.Connection
    {
        DataTable data = new DataTable();

        public DataTable readRent()
        {
            try
            {
                string read = "SELECT * FROM rents";
                da = new MySqlDataAdapter(read, GetConn());
                da.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public void addRent(int idrent, int idconsole, string custname, DateTime rentdate, DateTime returndate, int cost)
        {
            string add = "INSERT INTO rents VALUES (@idrent, @idconsole, @custname, @rentdate, @returndate, @cost)";

            try
            {
                cmd = new MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@idrent", MySqlDbType.Int32).Value = idrent;
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = idconsole;
                cmd.Parameters.Add("@custname", MySqlDbType.VarChar).Value = custname;
                cmd.Parameters.Add("@rentdate", MySqlDbType.DateTime).Value = rentdate;
                cmd.Parameters.Add("@returndate", MySqlDbType.DateTime).Value = returndate;
                cmd.Parameters.Add("@cost", MySqlDbType.Int32).Value = cost;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add Failed, " + e.Message);
            }
        }

        public void updateRent(int idrent, int idconsole, string custname, DateTime rentdate, DateTime returndate, int cost)
        {
            string update = "UPDATE rents SET idconsole = @idconsole, custname = @custname, rentdate = @rentdate, returndate = @returndate, cost = @cost WHERE idrent = " + idrent;

            try
            {
                cmd = new MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@idrent", MySqlDbType.Int32).Value = idrent;
                cmd.Parameters.Add("@idconsole", MySqlDbType.Int32).Value = idconsole;
                cmd.Parameters.Add("@custname", MySqlDbType.VarChar).Value = custname;
                cmd.Parameters.Add("@rentdate", MySqlDbType.DateTime).Value = rentdate;
                cmd.Parameters.Add("@returndate", MySqlDbType.DateTime).Value = returndate;
                cmd.Parameters.Add("@cost", MySqlDbType.Int32).Value = cost;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Failed, " + e.Message);
            }
        }

        public void deleteCustomer(int id)
        {
            string delete = "DELETE FROM rents WHERE idrent = @idrent";

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
