using FlightBooking.Domain.Commons;
using FlightBooking.Domain.Entities.Airports;
using FlightBooking.Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Entities.Flights;

public class Flight : AudiTable
{
    public string FlightNumber { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }
    public int AvailableSeats { get; set; }

    public long DepartureAirportId { get; set; } 
    public long ArrivalAirportId { get; set; } 
    public Airport DepartureAirport { get; set; } 
    public Airport ArrivalAirport { get; set; }

    public ICollection<Booking> Bookings { get; set; }  
}
