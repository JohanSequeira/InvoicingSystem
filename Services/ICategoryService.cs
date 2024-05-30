using InvoicingSystem.DTOs;
using InvoicingSystem.Models;

namespace InvoicingSystem.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(CategoryDTO categoryDTO);
        Task UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        Task DeleteCategoryAsync(int id);
    }

}
