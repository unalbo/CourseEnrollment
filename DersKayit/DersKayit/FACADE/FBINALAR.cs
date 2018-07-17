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
    class FBINALAR
    {
        public static List<EBINALAR> SelectList()
        {
            List<EBINALAR> binalar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("BINALAR_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    binalar = new List<EBINALAR>();
                    while (rdr.Read())
                    {
                        EBINALAR bina = new EBINALAR();
                        bina.ID1 = Convert.ToInt32(rdr["ID"]);
                        bina.KODU1 = rdr["KODU"].ToString();
                        bina.BINAADI1 = rdr["BINAADI"].ToString();
                        binalar.Add(bina);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                binalar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return binalar;
        }
    }
}
