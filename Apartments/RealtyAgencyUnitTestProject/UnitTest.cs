using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RealtyAgencyLib;

namespace RealtyAgencyUnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        private static List<Apartment> InitializationApartments()
        {
            return new List<Apartment>
            {
                new ApartmentForRent(1,23.3,2,10000),
                new ApartmentForSale(2,12.45,1,500000),
                new ApartmentForSale(3,27.15,1,2000000),
                new ApartmentForSale(4,57.15,3,10000000),
                new ApartmentForSale(5,22.31,1,3000000),
                new ApartmentForSale(6,222.31,5,9000000),
                new ApartmentForSale(7,122.31,5,8000000),
                new ApartmentForRent(8,23.3,2,10000),
                new ApartmentForRent(9,23.8,2,11000),
                new ApartmentForRent(10,30.8,2,13000),
                new ApartmentForRent(11,28.8,2,12000),
                new ApartmentForRent(12,38.8,2,15000)
            };
        }
        
        [TestMethod]
        public void Agency_GetPotentialProfitAgency()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const double profit = 1481000;
            //act
            var profitResult = agency.GetPotentialProfitAgency();
            //assert
            Assert.AreEqual(profitResult,profit);
        }

        [TestMethod]
        public void Agency_GetApartmentById()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const int apartmentId = 7;
            //act
            var apartmet = agency.GetApartmentById(apartmentId);
            //assert
            Assert.AreEqual(apartmet.Id,apartmentId);
        }

        [TestMethod]
        public void Agency_GetApartmentsByCountRoom()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const int countRooms = 2;
            //act
            var apartmentsWithRooms = agency.GetApartmentsByCountRoom(countRooms);
            //assert
            apartmentsWithRooms.ForEach(item =>
            {
                Assert.AreEqual(item.CountRooms, countRooms);
            });
        }

        [TestMethod]
        public void Agency_GetApartmentsByFootage()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const double fFrom = 20.0;
            const double fTo = 30.0;
            //act
            var apartmentByFootage = agency.GetApartmentsByFootage(fFrom, fTo);
            //assert
            apartmentByFootage.ForEach(item =>
            {
                Assert.IsTrue(item.Footage >= fFrom);
                Assert.IsTrue(item.Footage <= fTo);
            });
        }

        [TestMethod]
        public void Agency_GetApartmentsForSale()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const int result = 6;
            //act
            var apartmentsForSale = agency.GetApartmentsForSale();
            //assert
            Assert.AreEqual(apartmentsForSale.Count,result);
        }

        [TestMethod]
        public void Agency_GetApartmentsForRent()
        {
            //arrange
            Agency agency = new Agency(InitializationApartments());
            const int result = 6;
            //act
            var apartmentsForSale = agency.GetApartmentsForRent();
            var expApt =
                InitializationApartments()
                    .Where(item => item is ApartmentForSale)
                    .ToList()
                    .OrderBy(p => p.Cost/p.Footage)
                    .ToList();
            //assert
            CollectionAssert.AreEqual(expApt.ToList(),apartmentsForSale.ToList());
            //Assert.IsTrue(expApt.SequenceEqual(apartmentsForSale));
        }
    }
}
