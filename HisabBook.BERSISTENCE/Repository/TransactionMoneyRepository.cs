using HisabBook.DOMAIN.Interface;
using HisabBook.DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.PERSISTENCE.Repository
{
    public class TransactionMoneyRepository : ITransactionMoneyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionMoneyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddTransactionAsync(TransactionMoney transaction)
        {
          await _dbContext.TransactionMoneys.AddAsync(transaction);
          await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(TransactionMoney transaction)
        {
            _dbContext.TransactionMoneys.Remove(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionMoney>> GetAllTransactionsAsync()
        {
            return await _dbContext.TransactionMoneys.AsNoTracking().ToListAsync();
        }

        public async Task<TransactionMoney?> GetTransactionByIdAsync(Guid id)
        {
           return await _dbContext.TransactionMoneys.AsNoTracking().FirstOrDefaultAsync(M=>M.Id==id);
        }

        public async Task UpdateTransactionAsync(TransactionMoney transaction)
        {
            _dbContext.TransactionMoneys.Update(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
