using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineCarBooking
{
    [XmlRoot("BookingList")]
    public class BookingList
    {
        [XmlArray("Bookings")]
        [XmlArrayItem("Booking")]
        public ObservableCollection<Booking> bookings = null;

        public BookingList()
        {
            bookings = new ObservableCollection<Booking>();
        }

        public Booking this[int i]
        {
            get { return bookings[i]; }
            set { bookings[i] = value; }
        }

        public void Add(Booking booking)
        {
            bookings.Add(booking);
        }

        public void Remove(Booking booking)
        {
            bookings.Remove(booking);
        }
    }
}
