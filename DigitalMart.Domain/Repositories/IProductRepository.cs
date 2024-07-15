using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task<Product> Create(Product product);
    }
}
