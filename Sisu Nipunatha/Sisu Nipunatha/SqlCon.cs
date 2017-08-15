using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sisu_Nipunatha
{
    public static class SqlCon
    {
        public static String server = "sql12.freemysqlhosting.net";
        public static String username = "sql12189588";
        public static String password = "3QMbvRkyg";
        public static String database = "sql12189588";
        public static String connectionString = "server=" + server + ";port=3306;user id="+username+";database="+database+";password="+password+";Charset=utf8";
        public static MySqlConnection con = new MySqlConnection("server=smbiz.lankahost.net;user id=srisara1_amila;database=srisara1_sisunipunatha;password = amila@2017;Charset=utf8");
        
        
    }
}
