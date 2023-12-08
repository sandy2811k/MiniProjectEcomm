using MiniProjectEcomm.Models;

namespace MiniProjectEcomm.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int Cid);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int Cid);
    }
}
