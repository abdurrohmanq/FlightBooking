namespace FlightBooking.Service.DTOs.Bookings;

public class BookingUpdateDto
{
    public long Id { get; set; }
    public long FlightId { get; set; }
    public long CustomerId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPassengers { get; set; }
}
