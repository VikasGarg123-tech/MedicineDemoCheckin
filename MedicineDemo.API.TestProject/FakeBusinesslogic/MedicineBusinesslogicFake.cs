using MedicineDemo.Businesslogic.Contracts;
using MedicineDemo.Businessmodel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineDemo.API.Test.FakeBusinesslogic
{
    public static class MedicineBusinesslogicFake
    {
        public static List<Medicine> MedicineList { get; set; }

        static MedicineBusinesslogicFake()
        {
            MedicineList = new List<Medicine>()
              {
                new Medicine() { Id = 1, Name = "MedicineTest1", Brand = "BrandTest1", ExpiryDate = new DateTime(2021, 07, 22).ToString(), Notes = "This is BrandTest1", Price = 302.08, Quantity = 10 },
                new Medicine() { Id = 2, Name = "MedicineTest2", Brand = "BrandTest2", ExpiryDate = new DateTime(2021, 03, 22).ToString(), Notes = "This is BrandTest2", Price = 402.79, Quantity = 4 },
                new Medicine() { Id = 3, Name = "MedicineTest3", Brand = "BrandTest3", ExpiryDate = new DateTime(2021, 04, 22).ToString(), Notes = "This is BrandTest3", Price = 102.39, Quantity = 2 },
                new Medicine() { Id = 4, Name = "MedicineTest4", Brand = "BrandTest4", ExpiryDate = new DateTime(2021, 08, 22).ToString(), Notes = "This is BrandTest4", Price = 702.19, Quantity = 1 },
                new Medicine() { Id = 5, Name = "MedicineTest5", Brand = "BrandTest5", ExpiryDate = new DateTime(2021, 11, 22).ToString(), Notes = "This is BrandTest5", Price = 52.34, Quantity = 7 }
              };
        }

    }
}