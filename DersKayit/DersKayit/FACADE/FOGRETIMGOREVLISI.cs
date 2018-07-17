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
    class FOGRETIMGOREVLISI
    {
        public static EOGRETIMGOREVLISI Select(string ogretimNo, string sifre)
        {
            EOGRETIMGOREVLISI ogretimGorevlisi = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("OGRETIMGOREVLISI_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRETIM_NO", ogretimNo);
                cmd.Parameters.AddWithValue("OGRETIM_SIFRE", sifre);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ogretimGorevlisi = new EOGRETIMGOREVLISI();
                        ogretimGorevlisi.ID1 = Convert.ToInt32(rdr["ID"]);
                        ogretimGorevlisi.OKULNO1 = rdr["OKULNO"].ToString();
                        ogretimGorevlisi.TCKIMLIKNO1 = rdr["TCKIMLIKNO"].ToString();
                        ogretimGorevlisi.AD1 = rdr["AD"].ToString();
                        ogretimGorevlisi.SOYAD1 = rdr["SOYAD"].ToString();
                        ogretimGorevlisi.DOGUMYERI1 = rdr["IL"].ToString();
                        ogretimGorevlisi.DOGUMTARIHI1 = Convert.ToDateTime(rdr["DOGUMTARIHI"]);
                        ogretimGorevlisi.KAYITTARIHI1 = Convert.ToDateTime(rdr["KAYITTARIHI"]);
                        ogretimGorevlisi.TURU1 = rdr["TUR"].ToString();
                        ogretimGorevlisi.UNVAN1 = rdr["UNVAN"].ToString();
                        ogretimGorevlisi.FAKULTE1 = rdr["FAKULTEADI"].ToString();
                        ogretimGorevlisi.SIFRE1 = rdr["SIFRE"].ToString();
                        ogretimGorevlisi.MAIL1 = rdr["MAIL"].ToString();
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                ogretimGorevlisi = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return ogretimGorevlisi;
        }

        public static int Update(EOGRETIMGOREVLISI item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("OGRETIMGOREVLISI_UPDATE", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRETIM_NO", item.ID1);
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

        public static List<EOGRETIMGOREVLISI> SelectList()
        {
            List<EOGRETIMGOREVLISI> gorevliler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("OGRETIMGOREVLISI_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    gorevliler = new List<EOGRETIMGOREVLISI>();
                    while (rdr.Read())
                    {
                        EOGRETIMGOREVLISI gorevli = new EOGRETIMGOREVLISI();
                        gorevli.ID1 = Convert.ToInt32(rdr["ID"]);
                        gorevli.ADSOYAD1 = rdr["AD"].ToString() + " " + rdr["SOYAD"].ToString();
                        gorevliler.Add(gorevli);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                gorevliler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return gorevliler;
        }
    }
}
