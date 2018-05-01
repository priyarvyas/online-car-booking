using System;
using System.Collections.Generic;
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

namespace OnlineCarBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listTime = new List<string>() { "10AM", "11AM", "12AM", "1PM", "2PM", "3PM", "4PM", "5PM", "6PM" };
        List<string> listSeatNo = new List<string>() { "2", "4", "5", "7","8" };

        
        public MainWindow()
        {
            InitializeComponent();
            dpPickupDate.SelectedDate = DateTime.Today;
            dpDropOffDate.SelectedDate = DateTime.Now.AddDays(1);
            lblErrorMessage.Content = "";
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

        private void cmbSeatNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string vSeatNo = cmbSeatNo.Text;

            Car c = new Car();
            Dictionary<int, List<Car>> carList = new Dictionary<int, List<Car>>();
            carList = c.CarList;
            if (vSeatNo != string.Empty)
            {
                foreach (var v in carList)
                {
                    //if (v.Key == Convert.ToInt32(vSeatNo))
                    //{
                        //listAvailCar.Items.Add(v.Value);
                        foreach(var val in v.Value)
                        {
                            listAvailCar.Items.Add(val.CarList);
                        }
                    //}
                }
            }

            if (vSeatNo == "2")
            {
                
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
            else if (!CheckPhoneNo(txtPhoneNo.Text))
            {
                result = false;
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






    }
}
