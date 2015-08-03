using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyAgencyLib
{
    public class ApartmentForSale : Apartment
    {
        public ApartmentForSale(int id, double footage, int countRooms, float cost)
            : base(id, footage, countRooms, cost)
        {
        }
        public ApartmentType ApartmentType
        {
            get { return ApartmentType.Sale; }
        }

    }
}
