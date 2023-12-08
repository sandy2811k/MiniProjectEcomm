using MiniProjectEcomm.Models;
using MiniProjectEcomm.Repositories;

namespace MiniProjectEcomm.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo repo;
        public ProductService(IProductRepo repo)
        {
            this.repo = repo;
        }
        public async Task<int> AddProduct(Product product)
        {
            return await repo.AddProduct(product);
        }

        public async Task<int> DeleteProduct(int Pid)
        {
            return await repo.DeleteProduct(Pid);
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await repo.GetAllProducts();
        }

        public async Task<Product> GetProductById(int Pid)
        {
            return await repo.GetProductById(Pid);
        }

        public async Task<int> UpdateProduct(Product product)
        {
            return await repo.UpdateProduct(product);
        }
    }
}
