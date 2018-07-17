using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DersKayit.FACADE
{
    class FDERSTURU
    {
        public static List<EDERSTURU> SelectList()
        {
            List<EDERSTURU> dersTurleri = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DERSTURU_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    dersTurleri = new List<EDERSTURU>();
                    while (rdr.Read())
                    {
                        EDERSTURU dersTuru = new EDERSTURU();
                        dersTuru.ID1 = Convert.ToInt32(rdr["ID"]);
                        dersTuru.DERSTURU1 = rdr["TUR"].ToString();
                        dersTurleri.Add(dersTuru);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                dersTurleri = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return dersTurleri;
        }
    }
}
