using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetByCategory(string category);
        public Task<Product> Create(Product product);
        public Task<Product> Update(Product product);
        public Task<bool> Delete(int productId);
    }
}
