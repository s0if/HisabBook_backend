using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HisabBook.DOMAIN.Interface
{
    public interface ITransactionMoneyRepository
    {
        Task AddTransactionAsync(TransactionMoney transaction);
        Task<IEnumerable<TransactionMoney>> GetAllTransactionsAsync();
        Task<TransactionMoney?> GetTransactionByIdAsync(Guid id);
        Task UpdateTransactionAsync(TransactionMoney transaction);
        Task DeleteTransactionAsync(TransactionMoney transaction);
    }
}
