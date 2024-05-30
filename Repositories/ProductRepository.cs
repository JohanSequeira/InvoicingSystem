using InvoicingSystem.Models;

namespace InvoicingSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new List<Product>();
        private readonly ICategoryRepository _categoryRepository;
        private int _currentId = 1;

        public ProductRepository(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task AddAsync(Product product)
        {
            if (!await _categoryRepository.CategoryExistsAsync(product.CategoryId))
            {
                throw new InvalidOperationException($"Category with id {product.CategoryId} does not exist");
            }
            product.Id = _currentId++;
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.CategoryId = product.CategoryId;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            await Task.CompletedTask;
        }

        public async Task UpdateQuantityAsync(int productId, int quantity)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == productId);
            if (existingProduct != null)
            {
                existingProduct.Quantity = quantity;
            }
            await Task.CompletedTask;
        }


    }

}
