using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceSampleService.Models;

namespace ECommerceSampleService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICollection<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>
            {
                new() { Id = 1, Name = "ASUS Motherboard Intel X4635", Description = "Cool mother board for Intel platform", ProductType = ProductType.MotherBoards },
                new() { Id = 2, Name = "ASUS Motherboard Intel Z111", Description = "No bad mother board for Intel platform", ProductType = ProductType.MotherBoards },
                new() { Id = 3, Name = "ASUS Motherboard AMD B444", Description = "Cool mother board for AMD platform", ProductType = ProductType.MotherBoards },
                new() { Id = 3, Name = "ASUS Motherboard AMD Z444", Description = "Excellent mother board for AMD platform", ProductType = ProductType.MotherBoards },
                new() { Id = 4, Name = "Intel 6700K", Description = "Intel processor", ProductType = ProductType.Processors },
                new() { Id = 5, Name = "Intel 10600", Description = "New Intel processor", ProductType = ProductType.Processors },
                new() { Id = 6, Name = "Intel 10900X", Description = "New Intel processor premium", ProductType = ProductType.Processors },
                new() { Id = 7, Name = "AMD 5600X", Description = "Middle segment AMD processor", ProductType = ProductType.Processors },
                new() { Id = 8, Name = "AMD 5800X", Description = "Top segment AMD processor", ProductType = ProductType.Processors },
                new() { Id = 8, Name = "AMD 5800X", Description = "Top segment AMD processor", ProductType = ProductType.Processors },
            };
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Product>> GetByTypeAsync(ProductType type)
        {
            return Task.FromResult(_products.Where(p => p.ProductType == type));
        }

        public Task<Product> AddAsync(string name, string description, ProductType type)
        {
            var product = new Product
            {
                Id = NewId,
                Name = name,
                Description = description,
                ProductType = type
            };

            _products.Add(product);

            return Task.FromResult(product);
        }

        private int NewId =>_products.Max(p => p.Id) + 1;
    }
}