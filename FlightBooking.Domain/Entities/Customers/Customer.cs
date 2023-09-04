using FlightBooking.Domain.Commons;
using FlightBooking.Domain.Entities.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Domain.Entities.Customers;

public class Customer : AudiTable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PassportNumber { get; set; }

    public ICollection<Booking> Bookings { get; set; }
}
