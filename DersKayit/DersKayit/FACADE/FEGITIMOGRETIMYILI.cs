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
    class FEGITIMOGRETIMYILI
    {
        public static List<EEGITIMOGRETIMYILI> SelectList()
        {
            List<EEGITIMOGRETIMYILI> yillar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("EGITIMOGRETIMYILI_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    yillar = new List<EEGITIMOGRETIMYILI>();
                    while (rdr.Read())
                    {
                        EEGITIMOGRETIMYILI yil = new EEGITIMOGRETIMYILI();
                        yil.ID1 = Convert.ToInt32(rdr["ID"]);
                        yil.YIL1 = Convert.ToInt32(rdr["YIL"]);
                        yillar.Add(yil);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                yillar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return yillar;
        }
    }
}
