using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OnlineCarBooking
{
    [XmlRoot("BookingList")]
    public class BookingList : IEnumerable
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public BookingEnumerator GetEnumerator()
        {
            return new BookingEnumerator(bookings);
        }

        public void Remove(Booking booking)
        {
            bookings.Remove(booking);
        }
    }

    public class BookingEnumerator : IEnumerator
    {
        public ObservableCollection<Booking> bookingList;
        int position = -1;

        public BookingEnumerator(ObservableCollection<Booking> list)
        {
            bookingList = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < bookingList.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Booking Current
        {
            get
            {
                try
                {
                    return bookingList[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

    }
}
