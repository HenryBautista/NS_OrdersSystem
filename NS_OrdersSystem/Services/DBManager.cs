using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NS_OrdersSystem.Services
{
    public static class DBManager
    {
        public static string PassWord;
        public static string sqlConnectionString = @"Data Source=DESKTOP-APK6QOP\HTTSERVER;Initial Catalog=ns_orders;Persist Security Info=True;User ID=HTTUser;Password=123456";
        //public static string sqlConnectionString = @"Data Source=SERVIDOR;Initial Catalog=ns_orders;Persist Security Info=True;User ID=henry;Password=123456";

      
    }
}
