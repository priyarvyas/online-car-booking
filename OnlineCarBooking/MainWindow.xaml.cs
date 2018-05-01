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
        List<string> listSeatNo = new List<string>() { "2", "4", "5", "7","8" };
        List<string> listSearch = new List<string>() { "", "4", "5", "6" };
        public BookingList bookingList = new BookingList();
        public MainWindow()
        {
            InitializeComponent();
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
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Booking>));
                TextWriter writer = new StreamWriter("BookingsData.xml");
                serializer.Serialize(writer, bookingList);
                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error writing to XML");
            }
        }

        private void ReadFromXML()
        {
            
            try
            {
                using (var reader = XmlReader.Create(@"BookingsData.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(BookingList));
                    bookingList = (BookingList)deserializer.Deserialize(reader);
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
            Car selectedCar = (Car)lstAvailCar.SelectedItem;

            Booking booking = new Booking(pickupDate, pickupTime, dropoffDate, dropoffTime, customer, selectedCar);
            bookingList.Add(booking);
        }
    }
}
