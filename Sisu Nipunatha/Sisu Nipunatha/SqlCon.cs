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
        public static String server="localhost";
        public static String username="root";
        public static String password="";
        public static String database="dahampasala";
        public static String connectionString = "server=" + server + ";port=3306;user id="+username+";database="+database+";password="+password+";Charset=utf8";
        public static MySqlConnection con = new MySqlConnection(connectionString);
        
        
    }
}
