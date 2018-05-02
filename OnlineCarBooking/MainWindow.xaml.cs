using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            dpPickupDate.SelectedDate = DateTime.Today;
            dpDropOffDate.SelectedDate = DateTime.Now.AddDays(1);
            lblErrorMessage.Content = "";
            Bookings = new BookingList();
            bookingGrid.Items.Refresh();
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
        /// <summary>
        /// File saving
        /// </summary>
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
        /// <summary>
        /// File retriving
        /// </summary>
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

        private void txtCustomerFName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCustomerFName.BorderBrush = Brushes.Black;
            txtCustomerFName.BorderThickness = new Thickness(1);
        }

        private void txtPhoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPhoneNo.BorderBrush = Brushes.Black;
            txtPhoneNo.BorderThickness = new Thickness(1);
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAddress.BorderBrush = Brushes.Black;
            txtAddress.BorderThickness = new Thickness(1);
        }

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCity.BorderBrush = Brushes.Black;
            txtCity.BorderThickness = new Thickness(1);
        }

        private void txtCustomerLName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCustomerLName.BorderBrush = Brushes.Black;
            txtCustomerLName.BorderThickness = new Thickness(1);
        }

        private void txtPostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPostalCode.BorderBrush = Brushes.Black;
            txtPostalCode.BorderThickness = new Thickness(1);
        }

        private void txtDrivingLicenceNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtDrivingLicenceNo.BorderBrush = Brushes.Black;
            txtDrivingLicenceNo.BorderThickness = new Thickness(1);
        }

        private void listAvailCar_SelectionChanged(object sender, RoutedEventArgs e)
        {
            listAvailCar.BorderBrush = Brushes.Black;
            listAvailCar.BorderThickness = new Thickness(1);
        }

        private void cmbPickupTime_SelectionChanged(object sender, RoutedEventArgs e)
        {
            cmbPickupTime.BorderBrush = Brushes.Black;
            cmbPickupTime.BorderThickness = new Thickness(1);
        }

        private void cmbDropOffTime_SelectionChanged(object sender, RoutedEventArgs e)
        {
            cmbDropOffTime.BorderBrush = Brushes.Black;
            cmbDropOffTime.BorderThickness = new Thickness(1);
        }

        private void dpPickupDate_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            dpPickupDate.BorderBrush = Brushes.Black;
            dpPickupDate.BorderThickness = new Thickness(1);
        }

        private void dpDropOffDate_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            dpDropOffDate.BorderBrush = Brushes.Black;
            dpDropOffDate.BorderThickness = new Thickness(1);
        }

        private void cmbSeatNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbSeatNo.BorderBrush = Brushes.Black;
            cmbSeatNo.BorderThickness = new Thickness(1);

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

        private void btnCarBook_Click(object sender, RoutedEventArgs e)
        {
            lblErrorMessage.Content = "";
            bool result = true;
            string errorMessage = string.Empty;
            if (txtCustomerFName.Text.Length == 0)
            {
                result = false;
                txtCustomerFName.BorderBrush = Brushes.Red;
                txtCustomerFName.BorderThickness = new Thickness(5);
                lblErrorMessage.Content = "Please enter Customer First Name " + Environment.NewLine;
            }
            if (txtCustomerLName.Text.Length == 0)
            {
                result = false;
                txtCustomerLName.BorderBrush = Brushes.Red;
                txtCustomerLName.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter Customer Last Name " + Environment.NewLine;
            }
            if (txtPhoneNo.Text.Length == 0)
            {
                result = false;
                txtPhoneNo.BorderBrush = Brushes.Red;
                txtPhoneNo.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter Phone Number " + Environment.NewLine;
            }
            else if (txtPhoneNo.Text.Length < 10)
            {
                result = false;
                txtPhoneNo.BorderBrush = Brushes.Red;
                txtPhoneNo.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Phone number must be 10 digit " + Environment.NewLine;
            }
            else if (!CheckPhoneNo(txtPhoneNo.Text))
            {
                result = false;
                txtPhoneNo.BorderBrush = Brushes.Red;
                txtPhoneNo.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Phone number is not valid " + Environment.NewLine;
            }
            
            if (txtAddress.Text.Length == 0)
            {
                result = false;
                txtAddress.BorderBrush = Brushes.Red;
                txtAddress.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter Address " + Environment.NewLine;
            }
            if (txtCity.Text.Length == 0)
            {
                result = false;
                txtCity.BorderBrush = Brushes.Red;
                txtCity.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter City " + Environment.NewLine;
            }
            if (txtPostalCode.Text.Length == 0)
            {
                result = false;
                txtPostalCode.BorderBrush = Brushes.Red;
                txtPostalCode.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter Postal Code " + Environment.NewLine;
            }
            else if (!IsValidPostalCode(txtPostalCode.Text))
            {
                result = false;
                txtPostalCode.BorderBrush = Brushes.Red;
                txtPostalCode.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Postal Code is not valid " + Environment.NewLine;
            }
            if (txtDrivingLicenceNo.Text.Length == 0)
            {
                result = false;
                txtDrivingLicenceNo.BorderBrush = Brushes.Red;
                txtDrivingLicenceNo.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please enter Driving Licence No " + Environment.NewLine;
            }
            if (cmbSeatNo.Text.Length == 0)
            {
                result = false;
                cmbSeatNo.BorderBrush = Brushes.Red;
                cmbSeatNo.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select Seat No " + Environment.NewLine;
            }
            if (cmbPickupTime.Text.Length == 0)
            {
                result = false;
                cmbPickupTime.BorderBrush = Brushes.Red;
                cmbPickupTime.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select Pickup Date " + Environment.NewLine;
            }
            if (cmbDropOffTime.Text.Length == 0)
            {
                result = false;
                cmbDropOffTime.BorderBrush = Brushes.Red;
                cmbDropOffTime.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select Drop-Off Date " + Environment.NewLine;
            }
            if (cmbPickupTime.Text.Length == 0)
            {
                result = false;
                cmbPickupTime.BorderBrush = Brushes.Red;
                cmbPickupTime.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select pickup time " + Environment.NewLine;
            }
            if (cmbDropOffTime.Text.Length == 0)
            {
                result = false;
                cmbDropOffTime.BorderBrush = Brushes.Red;
                cmbDropOffTime.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select drop off time " + Environment.NewLine;
            }
            if (listAvailCar.Items.Count == 0)
            {
                result = false;
                listAvailCar.BorderBrush = Brushes.Red;
                listAvailCar.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select available car " + Environment.NewLine;
            }
            if(dpPickupDate.SelectedDate.Value.Date < DateTime.Today)
            {
                result = false;
                dpPickupDate.BorderBrush = Brushes.Red;
                dpPickupDate.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select future date for Pickup date " + Environment.NewLine;
            }
            if (dpDropOffDate.SelectedDate.Value.Date < DateTime.Today)
            {
                result = false;
                dpDropOffDate.BorderBrush = Brushes.Red;
                dpDropOffDate.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Please select future date for Drop-off date " + Environment.NewLine;
            }
            else if (dpPickupDate.SelectedDate.Value.Date == dpDropOffDate.SelectedDate.Value.Date)
            {
                result = false;
                dpDropOffDate.BorderBrush = Brushes.Red;
                dpDropOffDate.BorderThickness = new Thickness(5);
                lblErrorMessage.Content += "Drop-Off date should be greater than Pick-up date " + Environment.NewLine;
            }
            if (result)
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
                ClearData();
            }
        }

        private bool CheckPhoneNo(string phoneNo)
        {
            try
            {
                ulong result;
                if (phoneNo.Length == 0)
                {
                    return false;
                }
                else
                {
                    return ulong.TryParse(phoneNo, out result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private bool IsValidPostalCode(string postalCode)
        {
            try
            {
                //Canadian Postal Code in the format of "M3A 1A5"
                string pattern = "^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";

                System.Text.RegularExpressions.Regex reg = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                if (!(reg.IsMatch(postalCode)))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Data binding
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            ReadFromXML();
            bookingGrid.ItemsSource = Bookings;
            bookingGrid.Items.Refresh();
        }

        /// <summary>
        /// LINQ implementation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReadFromXML();
            string carName = txtSearch.Text;
            var query = (from b in Bookings.bookings where b.Car.Name.Contains(carName) select b);
            bookingGrid.ItemsSource = query;
        }

        private void ClearData()
        {
            try
            {
                dpPickupDate.SelectedDate = DateTime.Today;
                dpDropOffDate.SelectedDate = DateTime.Now.AddDays(1);
                cmbPickupTime.SelectedIndex = 1;
                cmbDropOffTime.SelectedIndex = 1;
                cmbSeatNo.SelectedIndex = 1;
                listAvailCar.Items.Clear();
                txtCustomerFName.Text = "";
                txtCustomerLName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtPhoneNo.Text = "";
                txtDrivingLicenceNo.Text = "";
                txtPostalCode.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
