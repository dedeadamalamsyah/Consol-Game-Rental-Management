using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent.View
{
    internal class HistoryController : Model.Connection
    {
        public DataTable readHistory()
        {
            DataTable data = new DataTable();

            try
            {
                string read = "SELECT * FROM histories";
                da = new MySqlDataAdapter(read, GetConn());
                da.Fill(data);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return data;
        }

        public void deleteHistory(int id)
        {
            string delete = "DELETE FROM histories WHERE idtransaction = @idtransaction";

            try
            {
                cmd = new MySqlCommand(delete, GetConn());
                cmd.Parameters.Add("@idtransaction", MySqlDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("Delete Failed, " + e.Message);
            }
        }
    }
}
