using HisabBook.DOMAIN.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.UseCase
{
    public class DeleteTransactionMoney
    {
        private readonly ITransactionMoneyRepository _moneyRepository;
        public DeleteTransactionMoney(ITransactionMoneyRepository moneyRepository)
        {
            _moneyRepository = moneyRepository;
        }
        public async Task ExecuteAsync(Guid id)
        {
            var existingTransaction = await _moneyRepository.GetTransactionByIdAsync(id);
            if (existingTransaction == null)
            {
                throw new Exception("Transaction not found");
            }
            await _moneyRepository.DeleteTransactionAsync(existingTransaction);
        }
    }
}
