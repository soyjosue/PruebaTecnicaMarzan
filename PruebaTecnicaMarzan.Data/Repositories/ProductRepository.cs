using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMarzan.Data.Contracts;
using PruebaTecnicaMarzan.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMarzan.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        PTMContext _context;
        DbSet<Product> _products;
        public ProductRepository(PTMContext context)
        {
            _context = context;
            _products = _context.Set<Product>();
        }
        public Task<bool> CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        => await _products.ToListAsync();

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
