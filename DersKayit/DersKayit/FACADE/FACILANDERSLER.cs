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
    class FACILANDERSLER
    {
        public static EACILANDERSLER Select(int id)
        {
            EACILANDERSLER dersler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ACILANDERSLER_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("DERS_ID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        dersler = new EACILANDERSLER();
                        dersler.ID1 = Convert.ToInt32(rdr["ID"]);
                        dersler.DERS1 = Convert.ToInt32(rdr["DERS"]);
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                dersler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return dersler;
        }

        public static List<EACILANDERSLERVIEW> SelectList()
        {
            List<EACILANDERSLERVIEW> dersler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ACILANDERSLER_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    dersler = new List<EACILANDERSLERVIEW>();
                    while (rdr.Read())
                    {
                        EACILANDERSLERVIEW ders = new EACILANDERSLERVIEW();
                        ders.ID1 = Convert.ToInt32(rdr["ID"]);
                        ders.CRN1 = Convert.ToInt32(rdr["CRN"]);
                        ders.DERS1 = rdr["DERS"].ToString();
                        ders.OGERTIMUYESI1 = rdr["AD"].ToString() + rdr["SOYAD"].ToString();
                        ders.BINA1 = rdr["BINAADI"].ToString();
                        ders.GUN1 = rdr["GUN"].ToString();
                        ders.BASLANGICSAATI1 = rdr["BASLANGICSAATI"].ToString();
                        ders.DERSLIK1 = rdr["KODU"].ToString();
                        ders.KONTENJAN1 = Convert.ToInt32(rdr["KONTENJAN"]);
                        ders.YAZILAN1 = Convert.ToInt32(rdr["YAZILAN"]);
                        ders.DERSIALABILENPROGRAMLAR1 = rdr["PROGRAM"].ToString();
                        ders.YIL1 = Convert.ToInt32(rdr["YIL"]);
                        ders.DONEM1 = rdr["DONEM"].ToString();
                        ders.DILI1 = rdr["DIL"].ToString();
                        ders.PROGRAMID1 = Convert.ToInt32(rdr["DERSIALABILENPROGRAM"]);
                        dersler.Add(ders);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                dersler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return dersler;
        }

        public static int Insert(EACILANDERSLER item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("ACILANDERSLER_INSERT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("CRN", item.CRN1);
                cmd.Parameters.AddWithValue("DERS", item.DERS1);
                cmd.Parameters.AddWithValue("OGRETIMUYESI", item.OGRETIMUYESI1);
                cmd.Parameters.AddWithValue("BINA", item.BINA1);
                cmd.Parameters.AddWithValue("GUN", item.GUN1);
                cmd.Parameters.AddWithValue("BASLANGICSAATI", item.BASLANGICSAATI1);
                cmd.Parameters.AddWithValue("DERSLIK", item.DERSLIK1);
                cmd.Parameters.AddWithValue("KONTENJAN", item.KONTENJAN1);
                cmd.Parameters.AddWithValue("YAZILAN", item.YAZILAN1);
                cmd.Parameters.AddWithValue("PROGRAM", item.DERSIALABILENPROGRAM1);
                cmd.Parameters.AddWithValue("YIL", item.YIL1);
                cmd.Parameters.AddWithValue("DONEM", item.DONEM1);
                cmd.Parameters.AddWithValue("DILI", item.DILI1);

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
