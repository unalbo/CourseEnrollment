using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BOGRENCI
    {
        public static EOGRENCI Select(string ogrenciNo, string sifre)
        {
            if (ogrenciNo.Length == 9 && sifre.Length > 0)
                return FOGRENCI.Select(ogrenciNo, sifre);
            else
                return null;
        }

        public static List<EOGRENCI> SelectList()
        {
            return FOGRENCI.SelectList();
        }

        public static int Update(EOGRENCI item)
        {
            if (item.MAIL1 != null && item.SIFRE1 != null)
                return FOGRENCI.Update(item);
            else
                return -1;
        }
    }
}
