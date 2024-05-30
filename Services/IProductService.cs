using InvoicingSystem.DTOs;
using InvoicingSystem.Models;

namespace InvoicingSystem.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(int id, ProductDTO productDTO);
        //Task UpdateProductAsync(Product product);

        Task ReduceProductQuantityAsync(int productId, int quantity);
        Task DeleteProductAsync(int id);
    }

}
