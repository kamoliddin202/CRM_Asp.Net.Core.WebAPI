using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.CustomerDtos;

namespace BusinessLogicLayer.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id); 
        Task AddCustomerAsync(AddCustomerDto customer);
        Task UpdateCustomerAsync(UpdateCustomerDto customer);
        Task DeleteCustomerAsync(int id);
    }
}
