using Microsoft.EntityFrameworkCore;
using MiniProjectEcomm.Data;
using MiniProjectEcomm.Models;

namespace MiniProjectEcomm.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;

        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddProduct(Product product)
        {
            int result = 0;
            await db.Products.AddAsync(product);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProduct(int Pid)
        {
            int result = 0;
            var product = await db.Products.Where(x => x.Pid == Pid).FirstOrDefaultAsync();
            if (product != null)
            {
                db.Products.Remove(product);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int Pid)
        {
            var product = await db.Products.Where(x => x.Pid == Pid).FirstOrDefaultAsync();
            return product;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;
            var b = await db.Products.Where(x => x.Pid == product.Pid).FirstOrDefaultAsync();
            if (b != null)
            {
                b.Pname = product.Pname;
                b.Price = product.Price;
                b.ImageUrl = product.ImageUrl;
                b.Cid = product.Cid;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
