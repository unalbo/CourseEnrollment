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
    class FIL
    {
        public static EIL Select(int id)
        {
            EIL iller = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("IL_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("IL_NO", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        iller = new EIL();
                        iller.ID1 = Convert.ToInt32(rdr["ID"]);
                        iller.IL1 = rdr["IL"].ToString();
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                iller = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return iller;
        }
    }
}
