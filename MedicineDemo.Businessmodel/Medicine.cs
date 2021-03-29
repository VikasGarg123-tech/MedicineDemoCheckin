using System;

namespace MedicineDemo.Businessmodel
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ExpiryDate { get; set; }
        public string Notes { get; set; }
        public bool IsMedicineExpiring { get; set; }
    }
}
