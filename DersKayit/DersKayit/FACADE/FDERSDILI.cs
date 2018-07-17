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
    class FDERSDILI
    {
        public static List<EDERSDILI> SelectList()
        {
            List<EDERSDILI> diller = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DERSDILI_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    diller = new List<EDERSDILI>();
                    while (rdr.Read())
                    {
                        EDERSDILI dil = new EDERSDILI();
                        dil.ID1 = Convert.ToInt32(rdr["ID"]);
                        dil.DIL1 = rdr["DIL"].ToString();
                        diller.Add(dil);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                diller = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return diller;
        }
    }
}
