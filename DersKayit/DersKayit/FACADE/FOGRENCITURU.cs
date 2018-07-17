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
    class FOGRENCITURU
    {
        public static EOGRENCITURU Select(int id)
        {
            EOGRENCITURU tur = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("OGRENCITURU_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("TUR_NO", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        tur = new EOGRENCITURU();
                        tur.ID1 = Convert.ToInt32(rdr["ID"]);
                        tur.TUR1 = rdr["TUR"].ToString();
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                tur = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return tur;
        }
    }
}
