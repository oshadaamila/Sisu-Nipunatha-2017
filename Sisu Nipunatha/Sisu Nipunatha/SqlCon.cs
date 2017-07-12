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
        public static MySqlConnection con = new MySqlConnection("server=localhost;user id=root;database=dahampasala;Charset=utf8");
    }
}
