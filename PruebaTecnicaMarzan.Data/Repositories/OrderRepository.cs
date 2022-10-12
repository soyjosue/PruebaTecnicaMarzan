using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMarzan.Data.Contracts;
using PruebaTecnicaMarzan.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnicaMarzan.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        PTMContext _context;
        DbSet<Order> _orders;
        public OrderRepository(PTMContext context)
        {
            _context = context;
            _orders = _context.Set<Order>();
        }

        public async Task<bool> CreateAsync(Order entity)
        {
            var result = false;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.AddAsync(entity);

                    result = await _context.SaveChangesAsync() > 0;

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.InnerException.Message);
                }
            }

            return result;
        }

        public async Task<bool> EditAsync(Order entity)
        {
            var result = false;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _orders.Attach(entity);

                    _context.Entry(entity).State = EntityState.Modified;

                    result = await _context.SaveChangesAsync() > 0;

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.InnerException.Message);
                }
            }

            return result;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        => await _orders.ToListAsync();

        public async Task<Order> GetByIdAsync(int id)
        => await _orders.FirstOrDefaultAsync(i => i.ID == id);

        public async Task<bool> RemoveAsync(Order entity)
        {
            var result = false;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _orders.Remove(entity);

                    result = _context.SaveChanges() > 0;

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.InnerException.Message);
                }
            }

            return result;
        }
    }
}
