using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TESTNeversitup
{
    public class GlobalsDB
    {
        private string connection_string;
        public string Connection_String
        {
            set { connection_string = value; }
            get { return connection_string; }
        }

        public GlobalsDB()
        {
            connection_string = ConfigurationManager.ConnectionStrings["sql_connection"].ConnectionString;
        }
    }
}