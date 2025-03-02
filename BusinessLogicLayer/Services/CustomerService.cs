using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;
using DTOs.CustomerDtos;

namespace BusinessLogicLayer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, 
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddCustomerAsync(AddCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _unitOfWork.customerInterface.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _unitOfWork.customerInterface.GetByIdAsync(id);
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));  
            }
            await _unitOfWork.customerInterface.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();   
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.customerInterface.GetAllAsync();
            if (customers != null)
            {
                return customers.Select(c => _mapper.Map<CustomerDto>(c));
            }
            throw new ArgumentNullException(nameof(customers));
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await _unitOfWork.customerInterface.GetByIdAsync(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto customerDto)
        {
            var customer = await _unitOfWork.customerInterface.GetByIdAsync(customerDto.Id);
            if (customer != null)
            {
                var mappedCustomer = _mapper.Map(customerDto, customer);
                await _unitOfWork.customerInterface.UpdateAsync(mappedCustomer);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(customer));
            }
                


        }
    }
}
