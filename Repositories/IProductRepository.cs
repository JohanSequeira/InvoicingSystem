using InvoicingSystem.Models;

namespace InvoicingSystem.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        Task UpdateQuantityAsync(int productId, int quantity);
    }

}
