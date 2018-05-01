using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineCarBooking
{
    [XmlRoot("Customer")]
    [Serializable]
    public class Customer
    {
        string firstName;
        string lastName;
        string address;
        string city;
        string postalCode;
        string drivingLicenseNo;
        ulong phoneNumber;

        public Customer()
        {
        }

        public Customer(string firstName, string lastName, string address, string city, string postalCode, string drivingLicenseNo, ulong phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            PostalCode = postalCode;
            DrivingLicenseNo = drivingLicenseNo;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FullName
        {
            get => FirstName + " " + LastName;
        }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string DrivingLicenseNo { get => drivingLicenseNo; set => drivingLicenseNo = value; }
        public ulong PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}
