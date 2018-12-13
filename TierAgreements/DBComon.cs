using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace TierAgreements
{
    public static class DBComon
    {


        //Production
        //private static string Conn = @"Data Source=DESKTOP-367K99T\SQLEXPRESS; Initial Catalog=RICOHFIXEDASSETS;Integrated Security=True";
        private static string Conn = @"Data Source=DESKTOP-367K99T\SQLEXPRESS; Initial Catalog=RICOHFIXEDASSETS;User ID=LOCAL;Password=123";

        public static IDbConnection Connectiondb()
        {
            return new SqlConnection(Conn);
        }

        public static IDbCommand GetCommanddb(string pCommand, IDbConnection pCnn)
        {
            return new SqlCommand(pCommand, pCnn as SqlConnection);
        }
    }
}
