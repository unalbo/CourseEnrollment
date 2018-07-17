using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BACILANDERSLER
    {
        public static EACILANDERSLER Select(int id)
        {
            if (id > 0)
                return FACILANDERSLER.Select(id);
            else
                return null;
        }

        public static List<EACILANDERSLERVIEW> SelectList()
        {
            return FACILANDERSLER.SelectList();
        }

        public static int Insert(EACILANDERSLER item)
        {
            if (item.DERS1 != null)
                return FACILANDERSLER.Insert(item);
            else
                return -1;
        }
    }
}
