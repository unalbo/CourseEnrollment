using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BKAYITLIDERS
    {
        public static int Insert(EKAYITLIDERS item)
        {
            if (item.OGRENCIID1 > 0 && item.DERSID1 > 0)
                return FKAYITLIDERS.Insert(item);
            else
                return -1;
        }
    }
}
