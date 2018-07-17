using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BOGRETIMGOREVLISI
    {
        public static EOGRETIMGOREVLISI Select(string ogretimNo, string sifre)
        {
            if (ogretimNo.Length == 9 && sifre.Length > 0)
                return FOGRETIMGOREVLISI.Select(ogretimNo, sifre);
            else
                return null;
        }

        public static List<EOGRETIMGOREVLISI> SelectList()
        {
            return FOGRETIMGOREVLISI.SelectList();
        }

        public static int Update(EOGRETIMGOREVLISI item)
        {
            if (item.MAIL1 != null && item.SIFRE1 != null)
                return FOGRETIMGOREVLISI.Update(item);
            else
                return -1;
        }
    }
}
