using MedicineDemo.Businesslogic.Contracts;
using MedicineDemo.Businessmodel;
using MedicineDemo.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MedicineDemo.Businesslogic
{
    public class MedicineBusinesslogic : IMedicineBusinesslogic
    {
        private readonly BaseDataRepository dataAccess;

        private List<Medicine> medicineList = new List<Medicine>();
        public MedicineBusinesslogic(BaseDataRepository dataAccessObj)
        {
            dataAccess = dataAccessObj;

            medicineList.Add(new Medicine() { Id = 1, Name = "Medicine1", Brand = "Brand1", ExpiryDate = new DateTime(2021, 07, 22).ToString(), Notes = "This is Brand1", Price = 302.08, Quantity = 10 });
            medicineList.Add(new Medicine() { Id = 2, Name = "Medicine2", Brand = "Brand2", ExpiryDate = new DateTime(2021, 03, 22).ToString(), Notes = "This is Brand2", Price = 402.79, Quantity = 4 });
            medicineList.Add(new Medicine() { Id = 3, Name = "Medicine3", Brand = "Brand3", ExpiryDate = new DateTime(2021, 04, 22).ToString(), Notes = "This is Brand3", Price = 102.39, Quantity = 2 });
            medicineList.Add(new Medicine() { Id = 4, Name = "Medicine4", Brand = "Brand4", ExpiryDate = new DateTime(2021, 08, 22).ToString(), Notes = "This is Brand4", Price = 702.19, Quantity = 1 });
            medicineList.Add(new Medicine() { Id = 5, Name = "Medicine5", Brand = "Brand5", ExpiryDate = new DateTime(2021, 11, 22).ToString(), Notes = "This is Brand5", Price = 52.34, Quantity = 7 });
        }

        public List<Medicine> AddMedicine(Medicine medicine)
        {
            //In Actual it will be  dataAccess.ExecuteStoredPrc("ADDUPDATESPNAME");
            var id = medicineList.Max(a => a.Id);
            medicine.Id = id + 1;
            var diff = Convert.ToDateTime(medicine.ExpiryDate) - DateTime.Now;
            medicine.IsMedicineExpiring = Convert.ToDateTime(medicine.ExpiryDate) < DateTime.Now || diff.Days < 30;
            medicineList.Add(medicine);

            return medicineList;
        }

        public Medicine GetMedicineDetails(int id)
        {
            var med = medicineList.Where(m => m.Id == id).FirstOrDefault();
            if (med != null)
            {
                return med;
            }
            return new Medicine();
        }

        public List<Medicine> GetMedicineList()
        {
            //In Actual it will be  dataAccess.ExecuteStoredPrc("GETSPNAME");
            foreach (var item in medicineList)
            {
                var diff = Convert.ToDateTime(item.ExpiryDate) - DateTime.Now;
                item.IsMedicineExpiring = Convert.ToDateTime(item.ExpiryDate) < DateTime.Now || diff.Days < 30;
            }
            return medicineList;
        }

        public List<Medicine> UpdateMedicine(Medicine medicine)
        {
            //In Actual it will be  dataAccess.ExecuteStoredPrc("ADDUPDATESPNAME");
            var med = medicineList.Where(m => m.Id == medicine.Id).FirstOrDefault();
            if (med != null)
            {
                med.Notes = medicine.Notes;
            }

            return medicineList;
        }
    }
}