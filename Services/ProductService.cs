using InvoicingSystem.DTOs;
using InvoicingSystem.Models;
using InvoicingSystem.Repositories;

namespace InvoicingSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
            //var products = await _productRepository.GetAllAsync();
            //return products.Select(p => new Product
            //{
            //    Name = p.Name,
            //    Description = p.Description,
            //    Price = p.Price,
            //    Quantity = p.Quantity,
            //    CategoryId = p.CategoryId
            //});
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                Quantity = productDTO.Quantity,
                CategoryId = productDTO.CategoryId
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(int id, ProductDTO productDTO)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new Exception("Product not found");

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.Quantity = productDTO.Quantity;
            product.CategoryId = productDTO.CategoryId;

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task ReduceProductQuantityAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product != null && product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                await _productRepository.UpdateQuantityAsync(productId, product.Quantity);
            }
            else
            {
                throw new InvalidOperationException($"Insufficient stock for product ID {productId}");
            }
        }
    }

}
