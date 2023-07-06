using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.Controller
{
    internal class CustomerController : Model.Connection
    {
        public DataTable readCustomer()
        {
            DataTable data = new DataTable();

            try
            {
                string read = "SELECT * FROM customers";
                da = new MySqlDataAdapter(read, GetConn());
                da.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public void addCustomer(int id, string name, int age, string address, string phone)
        {
            string add = "INSERT INTO customers VALUES (@idcustomer, @name, @age, @address, @phone)";

            try
            {
                cmd = new MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@idcustomer", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@age", MySqlDbType.Int32).Value = age;
                cmd.Parameters.Add("@address", MySqlDbType.TinyText).Value = address;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Add Failed, " + e.Message);
            }
        }

        public void updateCustomer(int id, string name, int age, string address, string phone)
        {
            string update = "UPDATE customers SET name = @name, age = @age, address = @address, phone = @phone WHERE idcustomer = " + id;

            try
            {
                cmd = new MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@idcustomer", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("@age", MySqlDbType.Int32).Value = age;
                cmd.Parameters.Add("@address", MySqlDbType.TinyText).Value = address;
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Failed, " + e.Message);
            }
        }

        public void deleteCustomer(int id)
        {
            string delete = "DELETE FROM customers WHERE idcustomer = @idcustomer";

            try
            {
                cmd = new MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@idcustomer", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Failed, " + e.Message);
            }
        }
    }
}
