using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BKITAP
    {
        public static List<EKITAP> SelectList()
        {
            return FKITAP.SelectList();
        }

        public static int Insert(EKITAP item)
        {
            if (item.KITAPADI1 != null)
                return FKITAP.Insert(item);
            else
                return -1;
        }
    }
}
