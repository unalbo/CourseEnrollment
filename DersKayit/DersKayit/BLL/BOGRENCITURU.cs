using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DersKayit.ENTITY;
using DersKayit.FACADE;

namespace DersKayit.BLL
{
    class BOGRENCITURU
    {
        public static EOGRENCITURU Select(int id)
        {
            if (id > 0)
                return FOGRENCITURU.Select(id);
            else
                return null;
        }
    }
}
