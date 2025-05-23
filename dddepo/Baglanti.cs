using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dddepo
{
    class Baglanti
    {
        public static SqlConnection conn = new SqlConnection(
        @"Server=.;Database=dddepo;Trusted_Connection=True;");
    }
}
