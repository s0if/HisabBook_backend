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
    public class CreateTransactionMoney
    {
        private readonly ITransactionMoneyRepository _moneyRepository;
        private readonly AddTransactionMoney _addTransaction;

        public CreateTransactionMoney(ITransactionMoneyRepository moneyRepository, AddTransactionMoney addTransaction)
        {
            _moneyRepository = moneyRepository;
            _addTransaction = addTransaction;
        }
        public async Task<TransactionMoneyDTOs> ExecuteAsync(TransactionMoneyDTOs transaction)
        {
            var tra= _addTransaction.ToTransactionMoney(transaction);
            await _moneyRepository.AddTransactionAsync(tra);
            return transaction;

        }
    }
}
