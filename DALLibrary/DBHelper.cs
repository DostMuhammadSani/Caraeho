using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DALLibrary
{
    public class DBHelper
    {
        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QQB77P7\\SQLEXPRESS;Initial Catalog=CareahoDB;Integrated Security=True");
            return con;
        }
    }
}
