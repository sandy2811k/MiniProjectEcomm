using MiniProjectEcomm.Models;
using MiniProjectEcomm.Repositories;

namespace MiniProjectEcomm.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo repo;
        public CategoryService(ICategoryRepo repo)
        {
            this.repo = repo;
        }
        public async Task<int> AddCategory(Category category)
        {
            return await repo.AddCategory(category);
        }

        public async Task<int> DeleteCategory(int Cid)
        {
            return await repo.DeleteCategory(Cid);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await repo.GetAllCategories();
        }

        public async Task<Category> GetCategoryById(int Cid)
        {
            return await repo.GetCategoryById(Cid);
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return await repo.UpdateCategory(category);
        }
    }
}
