using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DersKayit.ENTITY
{
    class BAGLAN
    {
        public static readonly SqlConnection conn = new SqlConnection("Data Source=DESKTOP-GNBBE7B;Initial Catalog=DERSKAYIT;Integrated Security=True");
    }
}
