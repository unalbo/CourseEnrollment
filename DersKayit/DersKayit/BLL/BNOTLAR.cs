using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BNOTLAR
    {
        public static List<ENOTLAR> Select(int ogrenciId)
        {
            if (ogrenciId > 0)
                return FNOTLAR.Select(ogrenciId);
            else
                return null;
        }

        public static ENOTLAR Select(int ogrenciId, int dersId)
        {
            if (ogrenciId > 0 && dersId > 0)
                return FNOTLAR.Select(ogrenciId, dersId);
            else
                return null;
        }

        public static int Delete(int dersId)
        {
            if (dersId > 0)
                return FNOTLAR.Delete(dersId);
            else
                return -1;
        }

        public static int Update(ENOTLAR item)
        {
            if (item.OGRENCINO1 != null && item.ACILANDERS1 != null)
                return FNOTLAR.Update(item);
            else
                return -1;
        }
    }
}
