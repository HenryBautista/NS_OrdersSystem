using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NS_OrdersSystem.Data;
namespace NS_OrdersSystem.Services
{
    public static class OrdersServices
    {
        public static void InsertOrder() 
        {
            
        }

        internal static void InsertOrder(DateTime? date, string p1, string p2, string p3, string p4, string p5, string p6, bool state)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "I1");
                //string time = date.ToString();
                //time = time.Substring(0, 10);
                //time = time + " " + DateTime.Now.TimeOfDay;
                //comando.Parameters.AddWithValue("i_date", DateTime.Parse(time));
                comando.Parameters.AddWithValue("i_date",date);
                comando.Parameters.AddWithValue("i_client_name",p1.ToUpper() );
                comando.Parameters.AddWithValue("i_phone",p2);
                comando.Parameters.AddWithValue("i_product_description",p3.ToUpper() );
                comando.Parameters.AddWithValue("i_price",p4 );
                comando.Parameters.AddWithValue("i_anticipe",p5 );
                comando.Parameters.AddWithValue("i_observation",p6 );
                comando.Parameters.AddWithValue("i_state",state);
                comando.Parameters.AddWithValue("i_user_owner", SessionData.CurrentUser);
                

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {

              
            }
        }

        internal static DataTable GetAllOrders()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
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

            }

            return table;
        }

        internal static DataTable GetThisOrder(int currentItemSelected)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S2");
                comando.Parameters.AddWithValue("i_order",currentItemSelected);

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();



                conexion.Close();


            }
            catch (Exception)
            {

               
            }

            return table;
        }

        internal static void UpdateThisOrder(DateTime? date, string p1, string p2, string p3, string p4, string p5, string p6, bool state, int currentItemSelected)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "U1");
                comando.Parameters.AddWithValue("i_date", date);
                comando.Parameters.AddWithValue("i_client_name", p1.ToUpper());
                comando.Parameters.AddWithValue("i_phone", p2);
                comando.Parameters.AddWithValue("i_product_description", p3.ToUpper());
                comando.Parameters.AddWithValue("i_price", p4);
                comando.Parameters.AddWithValue("i_anticipe", p5);
                comando.Parameters.AddWithValue("i_observation", p6);
                comando.Parameters.AddWithValue("i_state", state);
                //comando.Parameters.AddWithValue("i_user_owner", SessionData.CurrentUser);
                comando.Parameters.AddWithValue("i_order", currentItemSelected);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {

                
            }
        }

        internal static void DeleteThisOrder(int currentItemSelected)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "D1");
                comando.Parameters.AddWithValue("i_order", currentItemSelected);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {

               
            }
        }

        internal static DataTable FindThisOrder(string name, string product, string date)
        {

            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "F1");
                if (name!="")
                    comando.Parameters.AddWithValue("i_client_name", name.ToUpper());
                
                if(product!="")
                    comando.Parameters.AddWithValue("i_product_description", product.ToUpper());

                if (date != "")
                    comando.Parameters.AddWithValue("i_date", date);

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                adapter.Fill(table);
                adapter.Dispose();



                conexion.Close();


            }
            catch (Exception)
            {


            }

            return table;
        }

        internal static void InsertQuote(DateTime? date, string p1, string p2, string p3, string p4, string p5)
        {
            throw new NotImplementedException();
        }


        internal static DataSet1 FindThisOrderToReport(string order)
        {

            DataSet1 ds = new DataSet1();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_orders",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S2");
                comando.Parameters.AddWithValue("i_order",order);

                comando.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = comando;
                DataTable table = new DataTable();
                adapter.Fill(table);
                adapter.Fill(ds,"orders");
                adapter.Dispose();



                conexion.Close();


            }
            catch (Exception)
            {


            }

            return ds;
        }
    }
}
