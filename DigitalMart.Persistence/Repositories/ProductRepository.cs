using DigitalMart.Application.Repositories;
using DigitalMart.Domain.Entities;
using DigitalMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DigitalMart.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetByCategory(string category)
        {
            return await _context.Products
                .Where(e => e.category_name == category && e.is_deleted == false)
                .ToListAsync();
        }
        
    }
}
