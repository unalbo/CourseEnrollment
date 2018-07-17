using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BDERSLER
    {
        public static EDERSLER Select(int id)
        {
            if (id > 0)
                return FDERSLER.Select(id);
            else
                return null;
        }

        public static List<EDERSLER> SelectList()
        {
            return FDERSLER.SelectList();
        }

        public static int Insert(EDERSLER item)
        {
            if (item.DERS1 != null)
                return FDERSLER.Insert(item);
            else
                return -1;
        }
    }
}
