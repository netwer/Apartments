using System;
using System.Collections.Generic;
using System.Linq;

namespace RealtyAgencyLib
{
    public class Agency : IRealty
    {
        private List<Apartment> _allApartments;

        public double AgencyProfit { get; set; }

        public Agency(List<Apartment> allApartments)
        {
            _allApartments = allApartments;
        }

        public double GetPotentialProfitAgency()
        {
            var rentProfit = _allApartments.Where(item => item is ApartmentForRent).Sum(p=>p.Cost);
            var saleProfit1 = _allApartments.Where(item => item is ApartmentForSale && item.Cost <= 5000000).Sum(p => p.Cost*0.06);
            var saleProfit2 = _allApartments.Where(item => item is ApartmentForSale && item.Cost > 5000000).Sum(p => p.Cost*0.04);
            return rentProfit + saleProfit1 + saleProfit2;
        }

        public Apartment GetApartmentById(int apartmentId)
        {
            return _allApartments.FirstOrDefault(item => item.Id == apartmentId);
        }

        public List<Apartment> GetApartmentsByCountRoom(int roomCount)
        {
            return _allApartments.Where(item => item.CountRooms == roomCount).ToList();
        }

        public List<Apartment> GetApartmentsByFootage(double @from, double to)
        {
            return _allApartments.Where(item => item.Footage >= from && item.Footage <= to).ToList();
        }

        public List<Apartment> GetApartmentsForSale()
        {
            return _allApartments.Where(item => item is ApartmentForSale).ToList();
        }

        public List<Apartment> GetApartmentsForRent()
        {
            return _allApartments.Where(item => item is ApartmentForSale).ToList().OrderBy(p=>p.Cost/p.Footage).ToList();
        }
    }
}
