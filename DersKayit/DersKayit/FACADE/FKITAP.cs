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
    class FKITAP
    {
        public static List<EKITAP> SelectList()
        {
            List<EKITAP> kitaplar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("KITAP_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    kitaplar = new List<EKITAP>();
                    while (rdr.Read())
                    {
                        EKITAP kitap = new EKITAP();
                        kitap.ID1 = Convert.ToInt32(rdr["ID"]);
                        kitap.KITAPADI1 = rdr["KITAPADI"].ToString();
                        kitaplar.Add(kitap);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                kitaplar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return kitaplar;
        }

        public static int Insert(EKITAP item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("KITAP_INSERT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("KITAPADI", item.KITAPADI1);

                etkilenen = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                etkilenen = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return etkilenen;
        }
    }
}
