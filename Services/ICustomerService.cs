using InvoicingSystem.DTOs;
using InvoicingSystem.Models;

namespace InvoicingSystem.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerDTO customerDTO);
        Task UpdateCustomerAsync(int id, CustomerDTO customerDTO);
        Task DeleteCustomerAsync(int id);
    }

}
