using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarBooking
{
    class Booking
    {
        Customer customer;
        DateTime pickupDate;
        string pickTime;
        DateTime dropoffDate;
        string dropoffTime;
        Car car;

        public Booking()
        {
        }

        public Booking(DateTime pickupDate, string pickTime, DateTime dropoffDate, string dropoffTime, Customer customer, Car car)
        {
            PickupDate = pickupDate;
            PickTime = pickTime;
            DropoffDate = dropoffDate;
            DropoffTime = dropoffTime;
            Customer = customer;
            Car = car;
        }

        public DateTime PickupDate { get => pickupDate; set => pickupDate = value; }
        public string PickTime { get => pickTime; set => pickTime = value; }
        public DateTime DropoffDate { get => dropoffDate; set => dropoffDate = value; }
        public string DropoffTime { get => dropoffTime; set => dropoffTime = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public Car Car { get => car; set => car = value; }
    }
}
