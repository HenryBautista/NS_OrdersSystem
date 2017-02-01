using NS_OrdersSystem.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS_OrdersSystem.Services
{
    public class QuotesServices
    {

        internal static DataTable GetAllQuotes()
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
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

        internal static void InsertQuote(DateTime? date, string p1, string p2, string p3, string p4, string p5)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "I1");
                comando.Parameters.AddWithValue("i_date", date);
                comando.Parameters.AddWithValue("i_client_name", p1.ToUpper());
                comando.Parameters.AddWithValue("i_phone", p2);
                comando.Parameters.AddWithValue("i_detail", p3.ToUpper());
                comando.Parameters.AddWithValue("i_price", p4);
                comando.Parameters.AddWithValue("i_supplier", p5);
                comando.Parameters.AddWithValue("i_user_owner", SessionData.CurrentUser);


                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static DataTable GetThisQuote(int currentItemSelectedCoti)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "S2");
                comando.Parameters.AddWithValue("i_quote", currentItemSelectedCoti);

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

        internal static void DeleteThisQuote(int currentItemSelectedCoti)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "D1");
                comando.Parameters.AddWithValue("i_quote", currentItemSelectedCoti);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static void UpdateThisQuote(DateTime? date, string p1, string p2, string p3, string p4, string p5, int currentItemSelected)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "U1");
                comando.Parameters.AddWithValue("i_date", date);
                comando.Parameters.AddWithValue("i_client_name", p1.ToUpper());
                comando.Parameters.AddWithValue("i_phone", p2);
                comando.Parameters.AddWithValue("i_detail", p3.ToUpper());
                comando.Parameters.AddWithValue("i_price", p4);
                comando.Parameters.AddWithValue("i_supplier", p5);
                //comando.Parameters.AddWithValue("i_user_owner", SessionData.CurrentUser);
                comando.Parameters.AddWithValue("i_quote", currentItemSelected);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception)
            {


            }
        }

        internal static DataTable FindThisQuote(string name, string date)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection conexion = new SqlConnection(DBManager.sqlConnectionString);
                conexion.Open();
                SqlCommand comando = new SqlCommand
                {
                    Connection = conexion,
                    CommandText = "ns_orders..sp_quotes",
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };

                comando.Parameters.AddWithValue("i_accion", "F1");
                if (name != "")
                    comando.Parameters.AddWithValue("i_client_name", name.ToUpper());

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
    }
}
