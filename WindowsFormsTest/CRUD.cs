using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest
{
    public class CRUD
    {
        static DataTable dt;
        public static DataTable Listele(string sql)
        {
            dt = new DataTable();
            SQLiteDataAdapter adptr = new SQLiteDataAdapter(sql, Baglan.connection);
            adptr.Fill(dt);
            return dt;
        }
        public static bool ESG(string sql)
        {
            int dogrula = 0;
            SQLiteCommand command = new SQLiteCommand(sql, Baglan.connection);
            Baglan.connection.Open();
            dogrula = command.ExecuteNonQuery();
            Baglan.connection.Close();
            if (dogrula ==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
