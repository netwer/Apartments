using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyAgencyLib
{
    public class Apartment
    {
        public int Id { get; set; }
        public double Footage { get; set; }
        public int CountRooms { get; set; }
        public float Cost { get; set; }

        public Apartment(int id, double footage, int countRooms, float cost)
        {
            Id = id;
            Footage = footage;
            CountRooms = countRooms;
            Cost = cost;
        }
    }
}
