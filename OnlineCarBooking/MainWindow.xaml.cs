using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace OnlineCarBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listTime = new List<string>() { "10AM", "11AM", "12AM", "1PM", "2PM", "3PM", "4PM", "5PM", "6PM" };
        List<string> listSeatNo = new List<string>() { string.Empty,"2", "4", "5", "7","8" };
        List<string> listSearch = new List<string>() { "", "4", "5", "6" };
        BookingList bookings;
        private static Dictionary<int, List<Car>> carList;
        public Dictionary<int, List<Car>> CarList
        {
            get
            {
                carList = new Dictionary<int, List<Car>>();
                carList.Add(2, new List<Car>());
                carList.Add(4, new List<Car>());
                carList.Add(5, new List<Car>());
                carList.Add(7, new List<Car>());
                carList.Add(8, new List<Car>());
                carList[2].Add(new Car("Porsche", "718 Boxster", "NXD CFG 567", 2));
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
        public BookingList Bookings
        {
            get => bookings;
            set => bookings = value;
        }
        public MainWindow()
        {
            InitializeComponent();
            Bookings = new BookingList();
            ReadFromXML();
        }

        private void cmbPickupTime_Loaded(object sender, RoutedEventArgs e)
        {    
            var cmbPickTime = sender as ComboBox;
            cmbPickTime.ItemsSource = listTime;
            cmbPickTime.SelectedIndex = 0;
        }

        private void cmbDropOffTime_Loaded(object sender, RoutedEventArgs e)
        {
            var cmbDropTime = sender as ComboBox;
            cmbDropTime.ItemsSource = listTime;
            cmbDropTime.SelectedIndex = 0;
        }

        private void cmbSeatNo_Loaded(object sender, RoutedEventArgs e)
        {    
            var cmbSeatNo = sender as ComboBox;
            cmbSeatNo.ItemsSource = listSeatNo;
            cmbSeatNo.SelectedIndex = 0;
        }

        private void WriteToXML()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BookingList));
                TextWriter writer = new StreamWriter("BookingsData.xml");
                serializer.Serialize(writer, Bookings);
                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing to XML" + e.Message);
            }
        }

        private void ReadFromXML()
        {
            
            try
            {
                using (var reader = XmlReader.Create(@"BookingsData.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(BookingList));
                    Bookings = (BookingList)deserializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error in reading from XML");
            }
        }

        private void btnCarBook_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtCustomerFName.Text;
            string lastName = txtCustomerLName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string postalCode = txtPostalCode.Text;
            string licenseNo = txtDrivingLicenceNo.Text;
            ulong phoneNumber = ulong.Parse(txtPhoneNo.Text);

            Customer customer = new Customer(firstName, lastName, address, city, postalCode, licenseNo, phoneNumber);

            DateTime pickupDate = dpPickupDate.SelectedDate.Value.Date;
            string pickupTime = cmbPickupTime.Text;
            DateTime dropoffDate = dpDropOffDate.SelectedDate.Value.Date;
            string dropoffTime = cmbDropOffTime.Text;
            Car selectedCar = (Car)listAvailCar.SelectedItem;

            Booking booking = new Booking(pickupDate, pickupTime, dropoffDate, dropoffTime, customer, selectedCar);
            Bookings.Add(booking);
            WriteToXML();
        }
        private void cmbSeatNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string vSeatNo = cmbSeatNo.SelectedItem.ToString();

            Car c = new Car();
            Dictionary<int, List<Car>> carList = new Dictionary<int, List<Car>>();
            carList = CarList;
            listAvailCar.Items.Clear();
            if (vSeatNo != string.Empty)
            {
                List<Car> keyCars = carList[int.Parse(vSeatNo)];
                foreach (var v in keyCars)
                {
                     listAvailCar.Items.Add(v);
                }
            }
        }
    }
}
