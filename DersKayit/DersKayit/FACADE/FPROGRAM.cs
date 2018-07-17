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
    class FPROGRAM
    {
        public static EPROGRAM Select(int id)
        {
            EPROGRAM program = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("LISANSPROGRAMI_SELECT", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.Parameters.AddWithValue("PROGRAM_NO", id);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        program = new EPROGRAM();
                        program.ID1 = Convert.ToInt32(rdr["ID"]);
                        program.KODU1 = rdr["KODU"].ToString();
                        program.PROGRAM1 = rdr["PROGRAM"].ToString();
                        program.FAKULTE1 = Convert.ToInt32(rdr["FAKULTESI"]);
                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                program = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return program;
        }

        public static List<EPROGRAM> SelectList()
        {
            List<EPROGRAM> programlar = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("LISANSPROGRAMI_SELECTLIST", BAGLAN.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    programlar = new List<EPROGRAM>();
                    while (rdr.Read())
                    {
                        EPROGRAM program = new EPROGRAM();
                        program.ID1 = Convert.ToInt32(rdr["ID"]);
                        program.KODU1 = rdr["KODU"].ToString();
                        program.PROGRAM1 = rdr["PROGRAM"].ToString();
                        programlar.Add(program);

                    }
                }
                rdr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                programlar = null;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return programlar;
        }
    }
}
