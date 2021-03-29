using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineDemo.Businesslogic.Contracts;
using MedicineDemo.Businessmodel;
using Microsoft.AspNetCore.Mvc;

namespace MedicineDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineBusinesslogic medicineBusinesslogic;
        public MedicineController(IMedicineBusinesslogic medicineBusinesslogicObj)
        {
            medicineBusinesslogic = medicineBusinesslogicObj;
        }


        // GET api/values
        [HttpGet("/api/Medicine/GetMedicineList")]
        public IEnumerable<Medicine> GetMedicineList()
        {
            return medicineBusinesslogic.GetMedicineList();
        }

        // GET api/values
        [HttpGet("/api/Medicine/GetMedicineDetails")]
        public Medicine GetMedicineDetails(int id)
        {
            return medicineBusinesslogic.GetMedicineDetails(id);
        }

        // GET api/values
        [HttpPost("/api/Medicine/AddMedicine")]
        public IEnumerable<Medicine> AddMedicine([FromBody] Medicine medicine)
        {
            return medicineBusinesslogic.AddMedicine(medicine);
        }

        // GET api/values
        [HttpPut("/api/Medicine/UpdateMedicine")]
        public IEnumerable<Medicine> UpdateMedicine([FromBody] Medicine medicine)
        {
            return medicineBusinesslogic.UpdateMedicine(medicine);
        }
    }
}