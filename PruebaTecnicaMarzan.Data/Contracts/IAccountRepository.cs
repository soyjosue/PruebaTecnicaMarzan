using PruebaTecnicaMarzan.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaMarzan.Data.Contracts
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<bool> IsEmailUsedAsync(string email);
        Task<Account> GetByEmailAsync(string email);
    }
}
