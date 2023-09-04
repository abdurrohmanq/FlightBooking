using FlightBooking.Service.DTOs.Flights;

namespace FlightBooking.Service.Interfaces;

public interface IFlightService
{
    Task<FlightResultDto> AddAsync(FlightCreationDto dto);
    Task<FlightResultDto> UpdateAsync(FlightUpdateDto dto);
    Task<bool> Delete(long id);
    Task<FlightResultDto> GetAsync(long id);
    Task<IEnumerable<FlightResultDto>> GetAllAsync();
    Task<IEnumerable<FlightResultDto>> SearchFlightAsync(string DepartureCity, string ArrivalCity, DateTime DepartureTime, int NumberOfPassengers);
}