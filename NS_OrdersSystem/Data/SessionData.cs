using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS_OrdersSystem.Data
{
    public static class SessionData
    {
        public static int CurrentUser { get; set; }
        public static string selectedToReport { get; set; }
        public static string selectedQuoteToReport { get; set; }

    }
}
