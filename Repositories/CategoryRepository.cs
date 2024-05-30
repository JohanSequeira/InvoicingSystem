using InvoicingSystem.Models;

namespace InvoicingSystem.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly List<Category> _categories = new List<Category>();

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(c => c.Id == id));
        }

        public async Task AddAsync(Category category)
        {
            category.Id = _categories.Count + 1;
            _categories.Add(category);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
            await Task.CompletedTask;
        }
        public Task<bool> CategoryExistsAsync(int id)
        {
            return Task.FromResult(_categories.Any(c => c.Id == id));
        }

    }

}
