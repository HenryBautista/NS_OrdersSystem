//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NS_OrdersSystem
{
    using System;
    using System.Collections.Generic;
    
    public partial class quote
    {
        public int qu_quote { get; set; }
        public Nullable<System.DateTime> qu_date { get; set; }
        public string qu_client_name { get; set; }
        public string qu_phone { get; set; }
        public string qu_detail { get; set; }
        public Nullable<double> qu_price { get; set; }
        public string qu_supplier { get; set; }
        public Nullable<int> qu_user_owner { get; set; }
    
        public virtual user user { get; set; }
    }
}