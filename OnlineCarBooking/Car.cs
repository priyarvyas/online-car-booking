using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineCarBooking
{
    [XmlRoot("Car")]
    [Serializable]
    public class Car
    {
        string name;
        string model;
        string licenseNumber;
        uint noOfSeats;
        
        public Car()
        {
        }

        public Car(string name, string model, string licenseNumber, uint noOfSeats)
        {
            Name = name;
            Model = model;
            LicenseNumber = licenseNumber;
            NoOfSeats = noOfSeats;
        }

        public string Name { get => name; set => name = value; }
        public string Model { get => model; set => model = value; }
        public string LicenseNumber { get => licenseNumber; set => licenseNumber = value; }
        public uint NoOfSeats { get => noOfSeats; set => noOfSeats = value; }
        public override string ToString()
        {
            return this.Name + "-" + this.Model;
        }

        
    }
}
