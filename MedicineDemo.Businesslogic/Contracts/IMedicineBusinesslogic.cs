using MedicineDemo.Businessmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineDemo.Businesslogic.Contracts
{
    public interface IMedicineBusinesslogic
    {
        List<Medicine> GetMedicineList();
        Medicine GetMedicineDetails(int id);
        List<Medicine> AddMedicine(Medicine medicine);
        List<Medicine> UpdateMedicine(Medicine medicine);
    }
}