using System;
namespace FYP.iOS
{
    public class Prescriptions
    {
        
        public string Name { get; set; }
        public int ID { get; set; }
        public string Dosage { get; set; }
        public string Length { get; set; }
        public bool Pickup { get; set; }
        public string Instructions { get; set; }
        public bool Done { get; set; }

    }
}