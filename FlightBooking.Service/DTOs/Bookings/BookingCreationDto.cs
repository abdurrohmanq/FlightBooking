using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.DTOs.Bookings;

public class BookingCreationDto
{
    public long FlightId { get; set; }
    public long CustomerId { get; set; }
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public int NumberOfPassengers { get; set; }
}