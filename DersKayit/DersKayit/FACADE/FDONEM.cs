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
    class FDONEM
    {
        public static List<EDONEM> SelectList()
        {
            List<EDONEM> donemler = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("DONEM_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    donemler = new List<EDONEM>();
                    while (rdr.Read())
                    {
                        EDONEM donem = new EDONEM();
                        donem.ID1 = Convert.ToInt32(rdr["ID"]);
                        donem.DONEM1 = rdr["DONEM"].ToString();
                        donemler.Add(donem);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                donemler = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return donemler;
        }
    }
}
