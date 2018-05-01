using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarBooking
{
    public class Car
    {
        string name;
        string model;
        string licenseNumber;
        uint noOfSeats;
        private static Dictionary<int, List<Car>> carList;
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


        public static Dictionary<int, List<Car>> CarList
        {
            get
            {
                carList = new Dictionary<int, List<Car>>();
                carList.Add(2, new List<Car>());
                carList.Add(4, new List<Car>());
                carList.Add(5, new List<Car>());
                carList.Add(7, new List<Car>());
                carList.Add(8, new List<Car>());
                carList[2].Add(new Car("Porsche", "718 Boxster", "NXD CFG 567",2));
                carList[2].Add(new Car("Mazda", "MX-5 Miata", "CDJ PNP 345", 2));
                carList[2].Add(new Car("Fiat", "124 Spider", "CDJ PNP 345", 2));
                carList[4].Add(new Car("Audi", "TTS", "NXD CFG 567", 4));
                carList[4].Add(new Car("BMW", "M2", "CDJ PNP 345", 4));
                carList[4].Add(new Car("Toyota", "GT86", "XMP EFR 123", 4));
                carList[5].Add(new Car("Dodge Challenger", "T/A 392", "VGH EFT 657", 5));
                carList[5].Add(new Car("Mercedes-Benz", "AMG CLA 45 Coupe", "WER GTY 134", 5));
                carList[5].Add(new Car("Subaru", "WRX STI", "GHJ WUY 234", 5));
                carList[7].Add(new Car("Citroen Grand C4 Picasso", "Citroen Grand C4 Picasso", "OIU HDS 657", 7));
                carList[7].Add(new Car("Land Rover Discovery", "Land Rover Discovery", "NBJ WTU 134", 7));
                carList[7].Add(new Car("Volvo XC90", "Volvo XC90", "DJI YTR 234", 7));
                carList[8].Add(new Car("Mercedes Benz Viano", "MPV", "DFG ERT 678", 8));
                carList[8].Add(new Car("Volkswagen Caravelle", "Volkswagen Caravelle", "WER BHG 678", 8));
                carList[8].Add(new Car("Peugeot Expert Tepee", "Peugeot Expert Tepee", "BGH SDF 098", 8));
                return carList;
            }
        }
    }
}
