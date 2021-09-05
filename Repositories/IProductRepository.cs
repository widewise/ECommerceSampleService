using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceSampleService.Models;

namespace ECommerceSampleService.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetByTypeAsync(ProductType type);

        Task<Product> AddAsync(string name, string description, ProductType type);
    }
}