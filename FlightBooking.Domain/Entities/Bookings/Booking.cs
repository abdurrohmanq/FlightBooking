using FlightBooking.Domain.Commons;
using FlightBooking.Domain.Entities.Customers;
using FlightBooking.Domain.Entities.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Entities.Bookings;

public class Booking : AudiTable
{
    public long FlightId { get; set; }
    public Flight Flight { get; set; }
    public long CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPassengers { get; set; }
}
