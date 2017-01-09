using System;
using System.Data;
using System.Data.SqlClient;
using NS_OrdersSystem.Data;
namespace NS_OrdersSystem.Services
{
    public static class UsersServices
    {
        public static bool LogUser(string login, string password)
        {
            bool flag = new bool();
            flag = false;
            DataTable table = new DataTable(); 
            try
            {
              SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
              conexion.Open();
                SqlCommand comando =new SqlCommand
                {
                        Connection = conexion,
                        CommandText = "ns_orders..sp_users",
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 0,
                };
                   
                comando.Parameters.AddWithValue("i_accion", "S2");
                comando.Parameters.AddWithValue("i_login", login);
                comando.Parameters.AddWithValue("i_password", password);
                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();
                if (table.Rows.Count>0 && table.Rows[0]["us_password"].ToString()==password && (bool)table.Rows[0]["us_enable"]==true )
                {
                    
                    flag = true;
                    SessionData.CurrentUser = int.Parse(table.Rows[0]["us_user"].ToString());
                }               

               
                conexion.Close();
                

            }
            catch (Exception)
            {

                throw;
            }
             
            return flag;
        }

        internal static DataTable GetThisUser(string p)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S3");
                comando.Parameters.AddWithValue("i_user", p);

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();



                conexion.Close();


            }
            catch (Exception)
            {

                throw;
            }

            return table;
        }



        internal static DataTable GetAllUsers()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S1");
             

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();



                conexion.Close();


            }
            catch (Exception)
            {

                throw;
            }

            return table;
        }

        internal static void AddThisUser(string p1, string p2, string p3, string p4, string p5)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "I1");
                comando.Parameters.AddWithValue("i_name", p1.ToUpper());
                comando.Parameters.AddWithValue("i_paterno", p2.ToUpper());
                comando.Parameters.AddWithValue("i_materno", p3.ToUpper());
                comando.Parameters.AddWithValue("i_login", p4);
                comando.Parameters.AddWithValue("i_password", p5);
                comando.ExecuteNonQuery();
                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static void UpdateThisUser(string p1, string p2, string p3, string p4, string p5, int currentSelectedUser)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "U1");
                comando.Parameters.AddWithValue("i_name", p1.ToUpper());
                comando.Parameters.AddWithValue("i_paterno", p2.ToUpper());
                comando.Parameters.AddWithValue("i_materno", p3.ToUpper());
                comando.Parameters.AddWithValue("i_login", p4);
                comando.Parameters.AddWithValue("i_password", p5);
                comando.Parameters.AddWithValue("i_user", currentSelectedUser);
                comando.ExecuteNonQuery();
                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static void EnableThisUser(int currentSelectedUser, int p)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "U2");
                comando.Parameters.AddWithValue("i_enable", p);
               
                comando.Parameters.AddWithValue("i_user", currentSelectedUser);
                comando.ExecuteNonQuery();
                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static bool ExistLogin(string p)
        {
            bool flag = new bool();
            flag = false;
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_users",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S4");
                comando.Parameters.AddWithValue("i_login", p);

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();

                if (table.Rows.Count>0)
                {
                    flag = true;
                }


                conexion.Close();


            }
            catch (Exception)
            {

                throw;
            }

            return flag;
        }
    }
}
