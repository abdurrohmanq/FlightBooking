using FlightBooking.Service.DTOs.Bookings;

namespace FlightBooking.Service.Interfaces;

public interface IBookingService
{
    Task<BookingResultDto> AddAsync(BookingCreationDto dto);
    Task<BookingResultDto> UpdateAsync(BookingUpdateDto dto);
    Task<bool> Delete(long id);
    Task<BookingResultDto> GetAsync(long id);
    Task<IEnumerable<BookingResultDto>> GetAllAsync();
}
