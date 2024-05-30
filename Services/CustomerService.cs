using InvoicingSystem.DTOs;
using InvoicingSystem.Models;
using InvoicingSystem.Repositories;

namespace InvoicingSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task AddCustomerAsync(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Name = customerDTO.Name,
                Email = customerDTO.Email,
                Address = customerDTO.Address,
                ContactNumber = customerDTO.ContactNumber
            };

            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustomerDTO customerDTO)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            customer.Name = customerDTO.Name;
            customer.Email = customerDTO.Email;
            customer.Address = customerDTO.Address;
            customer.ContactNumber = customerDTO.ContactNumber;

            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }

}
