using FlightBooking.Service.DTOs.Customers;
using FlightBooking.Service.DTOs.Flights;

namespace FlightBooking.Service.DTOs.Bookings;

public class BookingResultDto
{
    public long Id { get; set; }
    public FlightResultDto Flight { get; set; }
    public CustomerResultDto Customer { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPassengers { get; set; }
}
