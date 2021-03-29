using MedicineDemo.API.Test.FakeBusinesslogic;
using MedicineDemo.Businesslogic.Contracts;
using MedicineDemo.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace MedicineDemo.API.Test
{
    [TestClass]
    public class MedicineControllerTest
    {
        [TestMethod]
        public void GetMedicineListTest()
        {
            var mockBL = new Mock<IMedicineBusinesslogic>();
            mockBL.Setup(x => x.GetMedicineList())
         .Returns(MedicineBusinesslogicFake.MedicineList);

            var controller = new MedicineController(mockBL.Object);
            var medicineLst = controller.GetMedicineList();

            Assert.IsNotNull(medicineLst);
            Assert.AreEqual(1, medicineLst.First().Id);
        }

        [TestMethod]
        public void AddMedicineTest()
        {
            var med = new Businessmodel.Medicine() { Name = "NEWMED", Brand = "NEWBRAND", ExpiryDate = new DateTime(2021, 07, 22).ToString(), Notes = "This is Brand1", Price = 302.08, Quantity = 10 };
            MedicineBusinesslogicFake.MedicineList.Add(med);
            var mockBL = new Mock<IMedicineBusinesslogic>();
            mockBL.Setup(x => x.AddMedicine(med))
         .Returns(MedicineBusinesslogicFake.MedicineList);

            var controller = new MedicineController(mockBL.Object);
            var medicineLst = controller.AddMedicine(med);

            Assert.AreEqual("NEWMED", MedicineBusinesslogicFake.MedicineList.Last().Name);
        }
    }
}