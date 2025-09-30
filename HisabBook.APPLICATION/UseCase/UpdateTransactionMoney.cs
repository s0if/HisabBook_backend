using HisabBook.APPLICATION.DTO;
using HisabBook.APPLICATION.Mapping;
using HisabBook.DOMAIN.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.UseCase
{
    public class UpdateTransactionMoney
    {
        private readonly EditTransactionMoney _editTransaction;
        private readonly ITransactionMoneyRepository _moneyRepository;

        public UpdateTransactionMoney(EditTransactionMoney editTransaction,ITransactionMoneyRepository moneyRepository)
        {
            _editTransaction = editTransaction;
            _moneyRepository = moneyRepository;
        }
        public async Task<TransactionMoneyDTOs> ExecuteAsync(Guid id,TransactionMoneyDTOs transaction)
        {
            var existingTransaction = await _moneyRepository.GetTransactionByIdAsync(id);
            if (existingTransaction == null)
            {
                throw new Exception("Transaction not found");
            }
            var updatedTransaction = _editTransaction.ToTransactionMoney(transaction, existingTransaction);
            await _moneyRepository.UpdateTransactionAsync(updatedTransaction);
            return transaction;
        }
    }
}
