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
    class FGUNLER
    {
        public static List<EGUNLER> SelectList()
        {
            List<EGUNLER> gunler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("GUNLER_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    gunler = new List<EGUNLER>();
                    while (rdr.Read())
                    {
                        EGUNLER gun = new EGUNLER();
                        gun.ID1 = Convert.ToInt32(rdr["ID"]);
                        gun.GUN1 = rdr["GUN"].ToString();
                        gunler.Add(gun);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                gunler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return gunler;
        }
    }
}
