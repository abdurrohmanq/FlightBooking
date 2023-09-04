using FlightBooking.Service.DTOs.Airports;

namespace FlightBooking.Service.Interfaces;

public interface IAirportService
{
    Task<AirportResultDto> AddAsync(AirportCreationDto dto);
    Task<AirportResultDto> UpdateAsync(AirportUpdateDto dto);
    Task<bool> Delete(long id);
    Task<AirportResultDto> GetAsync(long id);
    Task<IEnumerable<AirportResultDto>> GetAllAsync();
}
