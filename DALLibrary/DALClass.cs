using ClassLibraryModel;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DALLibrary
{
    public class DALClass
    {
        public static void CUD (SqlParameter[] p, string ProcName )
        {
            SqlConnection conn = DBHelper.getConnection();
            conn.Open ();
            SqlCommand cmd= new SqlCommand (ProcName, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddRange ( p );
            cmd.ExecuteNonQuery ();
            conn.Close ();
        }



        public static List<T> GetData<T>(string procedureName) where T : class, new()
        {

            List<T> users = new List<T>();
            SqlConnection con = DBHelper.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            Type tp = typeof(T);
            PropertyInfo[] properties = tp.GetProperties();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                T obj = new T();
                foreach (var property in properties)
                {

                    var name = property.Name;

                    property.SetValue(obj, Convert.ChangeType(reader[$"{name}"], property.PropertyType));


                }

                users.Add(obj);

            }
            con.Close();
            return users;





        }



        public static string GetID(string Email)
        {
            string A_Id = "";
            SqlConnection conn = DBHelper.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("GetPersonsID", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", Email);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                A_Id = Convert.ToString(reader["Id"]);

            }
            conn.Close();
            return A_Id;


        }

        public static string GetCID(string CName)
        {
            string A_Id = "";
            SqlConnection conn = DBHelper.getConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("CompanyID", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CName", CName);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                A_Id = Convert.ToString(reader["CID"]);

            }
            conn.Close();
            return A_Id;


        }

        public static List<T> GetDataParameter<T>(string procedureName, SqlParameter [] p) where T : class, new()
        {

            List<T> users = new List<T>();
            SqlConnection con = DBHelper.getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(p);
            Type tp = typeof(T);
            PropertyInfo[] properties = tp.GetProperties();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                T obj = new T();
                foreach (var property in properties)
                {

                    var name = property.Name;

                    property.SetValue(obj, Convert.ChangeType(reader[$"{name}"], property.PropertyType));


                }

                users.Add(obj);

            }
            con.Close();
            return users;





        }








    }
}
