using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BIL
    {
        public static EIL Select(int id)
        {
            if (id>0)
                return FIL.Select(id);
            else
                return null;
        }
    }
}
