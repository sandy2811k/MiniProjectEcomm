using MiniProjectEcomm.Models;

namespace MiniProjectEcomm.Repositories
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int Cid);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int Cid);
    }
}
