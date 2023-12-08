using Microsoft.EntityFrameworkCore;
using MiniProjectEcomm.Data;
using MiniProjectEcomm.Models;

namespace MiniProjectEcomm.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext db;

        public CategoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categories.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCategory(int Cid)
        {
            int result = 0;
            var category = await db.Categories.Where(x => x.Cid == Cid).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categories.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int Cid)
        {
            var category = await db.Categories.Where(x => x.Cid == Cid).FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var b = await db.Categories.Where(x => x.Cid == category.Cid).FirstOrDefaultAsync();
            if (b != null)
            {
                b.Cname = category.Cname;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
