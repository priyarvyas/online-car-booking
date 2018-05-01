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
    class BookingList
    {
        [XmlArray("Bookings")]
        [XmlArrayItem("Booking")]
        public ObservableCollection<Booking> Bookings;
    }
}
