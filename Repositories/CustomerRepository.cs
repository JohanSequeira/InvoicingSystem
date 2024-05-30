using InvoicingSystem.Models;

namespace InvoicingSystem.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly List<Customer> _customers = new List<Customer>();
        private int _currentId = 1;

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customers);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(customer);
        }

        public async Task AddAsync(Customer customer)
        {
            customer.Id = _currentId++;
            _customers.Add(customer);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Address = customer.Address;
                existingCustomer.ContactNumber = customer.ContactNumber;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            await Task.CompletedTask;
        }
    }
}

