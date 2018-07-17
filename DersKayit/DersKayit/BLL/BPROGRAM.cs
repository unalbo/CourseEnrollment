using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BPROGRAM
    {
        public static EPROGRAM Select(int id)
        {
            if (id > 0)
                return FPROGRAM.Select(id);
            else
                return null;
        }

        public static List<EPROGRAM> SelectList()
        {
            return FPROGRAM.SelectList();
        }
    }
}
