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
    class FKAYITLIDERS
    {
        public static int Insert(EKAYITLIDERS item)
        {
            SqlCommand cmd = null;
            int etkilenen = 0;
            try
            {
                cmd = new SqlCommand("NOTLAR_INSERT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("OGRENCI_ID", item.OGRENCIID1);
                cmd.Parameters.AddWithValue("DERS_ID", item.DERSID1);

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
