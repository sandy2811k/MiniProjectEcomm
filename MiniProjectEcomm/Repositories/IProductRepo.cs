using MiniProjectEcomm.Models;

namespace MiniProjectEcomm.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int Pid);
        Task<int> AddProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int Pid);
    } 
}
