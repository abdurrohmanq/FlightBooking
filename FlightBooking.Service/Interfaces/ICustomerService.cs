using FlightBooking.Service.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Service.Interfaces;

public interface ICustomerService
{
    Task<CustomerResultDto> AddAsync(CustomerCreationDto dto);
    Task<CustomerResultDto> UpdateAsync(CustomerUpdateDto dto);
    Task<bool> Delete(long id);
    Task<CustomerResultDto> GetAsync(long id);
    Task<IEnumerable<CustomerResultDto>> GetAllAsync();
}
