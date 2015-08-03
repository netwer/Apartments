using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtyAgencyLib
{
    public interface IRealty
    {
        Apartment GetApartmentById(int apartmentId);
        List<Apartment> GetApartmentsByCountRoom(int roomCount);
        List<Apartment> GetApartmentsByFootage(double from, double to);
        List<Apartment> GetApartmentsForSale();
        List<Apartment> GetApartmentsForRent();
    }
}
