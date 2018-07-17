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
    class FDERSLIK
    {
        public static List<EDERSLIK> SelectList()
        {
            List<EDERSLIK> derslikler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DERSLIK_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    derslikler = new List<EDERSLIK>();
                    while (rdr.Read())
                    {
                        EDERSLIK derslik = new EDERSLIK();
                        derslik.ID1 = Convert.ToInt32(rdr["ID"]);
                        derslik.KODU1 = rdr["KODU"].ToString();
                        derslikler.Add(derslik);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                derslikler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return derslikler;
        }
    }
}
