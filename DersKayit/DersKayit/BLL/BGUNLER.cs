using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BGUNLER
    {
        public static List<EGUNLER> SelectList()
        {
            return FGUNLER.SelectList();
        }
    }
}
