using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product product);
    }
}
