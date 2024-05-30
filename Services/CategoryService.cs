using InvoicingSystem.DTOs;
using InvoicingSystem.Models;
using InvoicingSystem.Repositories;
using InvoicingSystem.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task AddCategoryAsync(CategoryDTO categoryDTO)
    {
        var category = new Category
        {
            Name = categoryDTO.Name,
            Description = categoryDTO.Description
        };

        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new Exception("Category not found.");
        }

        category.Name = categoryDTO.Name;
        category.Description = categoryDTO.Description;

        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
    
}
