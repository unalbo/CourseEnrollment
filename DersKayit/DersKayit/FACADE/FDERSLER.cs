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
    class FDERSLER
    {
        public static EDERSLER Select(int id)
        {
            EDERSLER dersler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DERSLER_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("DERS_ID", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        dersler = new EDERSLER();
                        dersler.ID1 = Convert.ToInt32(rdr["ID"]);
                        dersler.DERS1 = rdr["DERS"].ToString();
                        dersler.KODU1 = rdr["KODU"].ToString();
                        dersler.YARIYILI1 = Convert.ToInt32(rdr["YARIYILI"]);
                        dersler.KREDI1 = Convert.ToInt32(rdr["KREDI"]);
                        dersler.TUR1 = Convert.ToInt32(rdr["TUR"]);
                        dersler.DERSKITABI1 = Convert.ToInt32(rdr["DERSKITABI"]);
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

        public static List<EDERSLER> SelectList()
        {
            List<EDERSLER> dersler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DERSLER_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    dersler = new List<EDERSLER>();
                    while (rdr.Read())
                    {
                        EDERSLER ders = new EDERSLER();
                        ders.ID1 = Convert.ToInt32(rdr["ID"]);
                        ders.DERS1 = rdr["DERS"].ToString();
                        ders.KODU1 = rdr["KODU"].ToString();
                        ders.YARIYILI1 = Convert.ToInt32(rdr["YARIYILI"]);
                        ders.KREDI1 = Convert.ToInt32(rdr["KREDI"]);
                        ders.DERSTURU1 = rdr["TUR"].ToString();
                        ders.KITAPADI1 = rdr["KITAPADI"].ToString();
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

        public static int Insert(EDERSLER item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("DERSLER_INSERT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("DERS", item.DERS1);
                cmd.Parameters.AddWithValue("KODU", item.KODU1);
                cmd.Parameters.AddWithValue("YARIYIL", item.YARIYILI1);
                cmd.Parameters.AddWithValue("KREDI", item.KREDI1);
                cmd.Parameters.AddWithValue("TUR", item.TUR1);
                cmd.Parameters.AddWithValue("DERSKITABI", item.DERSKITABI1);
                cmd.Parameters.AddWithValue("ONSART", item.ONSART1);

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
