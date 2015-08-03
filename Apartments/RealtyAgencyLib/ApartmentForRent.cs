using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyAgencyLib
{
    public class ApartmentForRent : Apartment
    {
        public ApartmentForRent(int id, double footage, int countRomms, float coast)
            : base(id, footage, countRomms, coast)
        {
        }

        public ApartmentType ApartmentType
        {
            get { return ApartmentType.Rent; }
        }
    }
}
