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
    class FNOTLAR
    {
        public static List<ENOTLAR> Select(int ogrenciId)
        {
            List<ENOTLAR> notlar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("NOTLAR_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_NO", ogrenciId);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    notlar = new List<ENOTLAR>();
                    while (rdr.Read())
                    {
                        ENOTLAR not = new ENOTLAR();
                        not.ID1 = Convert.ToInt32(rdr["ID"]);
                        not.ACILANDERS1 = Convert.ToInt32(rdr["ACILANDERS"]);
                        not.OGRENCINO1 = Convert.ToInt32(rdr["OGRENCI"]);
                        not.VIZENOTU1 = Convert.ToInt32(rdr["VIZENOTU"]);
                        not.FINALNOTU1 = Convert.ToInt32(rdr["FINALNOTU"]);
                        not.PROJENOTU1 = Convert.ToInt32(rdr["PROJENOTU"]);
                        not.HARFNOTU1 = rdr["HARFNOTU"].ToString();
                        notlar.Add(not);
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                notlar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return notlar;
        }

        public static ENOTLAR Select(int ogrenciId, int dersId)
        {
            ENOTLAR notlar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("NOTLAR_SELECT_WITH2KEY", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_ID", ogrenciId);
                cmd.Parameters.AddWithValue("DERS_ID", dersId);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        notlar = new ENOTLAR();
                        notlar.ID1 = Convert.ToInt32(rdr["ID"]);
                        notlar.ACILANDERS1 = Convert.ToInt32(rdr["ACILANDERS"]);
                        notlar.OGRENCINO1 = Convert.ToInt32(rdr["OGRENCI"]);
                        notlar.VIZENOTU1 = Convert.ToInt32(rdr["VIZENOTU"]);
                        notlar.FINALNOTU1 = Convert.ToInt32(rdr["FINALNOTU"]);
                        notlar.PROJENOTU1 = Convert.ToInt32(rdr["PROJENOTU"]);
                        notlar.HARFNOTU1 = rdr["HARFNOTU"].ToString();
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                notlar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return notlar;
        }

        public static int Delete(int id)
        {
            int durum = 0;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("NOTLAR_DELETE", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();
                cmd.Parameters.AddWithValue("ACILANDERS_ID", id);
                durum = cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                durum = -1;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return durum;
        }

        public static int Update(ENOTLAR item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("NOTLAR_OGRETIMGOREVLISI_UPDATE", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_ID", item.OGRENCINO1);
                cmd.Parameters.AddWithValue("DERS_ID", item.ACILANDERS1);
                cmd.Parameters.AddWithValue("VIZE_NOTU", item.VIZENOTU1);
                cmd.Parameters.AddWithValue("FINAL_NOTU", item.FINALNOTU1);
                cmd.Parameters.AddWithValue("PROJE_NOTU", item.PROJENOTU1);
                cmd.Parameters.AddWithValue("HARF_NOTU", item.HARFNOTU1);

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
