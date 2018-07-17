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
    class FOGRENCI
    {
        public static EOGRENCI Select(string ogrenciNo, string sifre)
        {
            EOGRENCI ogrenci = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("OGRENCI_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_NO", ogrenciNo);
                cmd.Parameters.AddWithValue("OGRENCI_SIFRE", sifre);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ogrenci = new EOGRENCI();
                        ogrenci.ID1 = Convert.ToInt32(rdr["ID"]);
                        ogrenci.OKULNO1 = rdr["OKULNO"].ToString();
                        ogrenci.TCKIMLIKNO1 = rdr["TCKIMLIKNO"].ToString();
                        ogrenci.AD1 = rdr["AD"].ToString();
                        ogrenci.SOYAD1 = rdr["SOYAD"].ToString();
                        ogrenci.DOGUMYERI1 = Convert.ToInt32(rdr["DOGUMYERI"]);
                        ogrenci.DOGUMTARIHI1 = Convert.ToDateTime(rdr["DOGUMTARIHI"]);
                        ogrenci.KAYITTARIHI1 = Convert.ToDateTime(rdr["KAYITTARIHI"]);
                        ogrenci.OGRENCITURU1 = Convert.ToInt32(rdr["TUR"]);
                        ogrenci.BOLUM1 = Convert.ToInt32(rdr["BOLUM"]);
                        ogrenci.SIFRE1 = rdr["SIFRE"].ToString();
                        ogrenci.MAIL1 = rdr["MAIL"].ToString();
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ogrenci = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return ogrenci;
        }

        public static List<EOGRENCI> SelectList()
        {
            List<EOGRENCI> ogrenciler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("OGRENCI_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    ogrenciler = new List<EOGRENCI>();
                    while (rdr.Read())
                    {
                        EOGRENCI ogrenci = new EOGRENCI();
                        ogrenci.ID1 = Convert.ToInt32(rdr["ID"]);
                        ogrenci.ADSOYAD1 = rdr["AD"].ToString() + " " + rdr["SOYAD"].ToString();
                        ogrenciler.Add(ogrenci);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ogrenciler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return ogrenciler;
        }

        public static int Update(EOGRENCI item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("OGRENCI_UPDATE", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_ID", item.ID1);
                cmd.Parameters.AddWithValue("MAIL", item.MAIL1);
                cmd.Parameters.AddWithValue("SIFRE", item.SIFRE1);

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
