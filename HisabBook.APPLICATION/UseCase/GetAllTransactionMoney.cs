using HisabBook.APPLICATION.DTO;
using HisabBook.DOMAIN.Interface;
using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HisabBook.APPLICATION.UseCase
{
    public class GetAllTransactionMoney
    {
        private readonly ITransactionMoneyRepository _moneyRepository;
        private readonly SalarySummary _salarySummary;

        public GetAllTransactionMoney(ITransactionMoneyRepository moneyRepository,
            SalarySummary salarySummary)
        {
            _moneyRepository = moneyRepository;
            _salarySummary = salarySummary;
        }

        public async Task<GetTransactionMoneyDTOs> ExecuteAsync()
        {
            var transactions = await _moneyRepository.GetAllTransactionsAsync();
            var netSalary=  _salarySummary.GetTotalSalary(transactions);
            return netSalary;
        }
        public async Task<GetTransactionMoneyDTOs> ExecuteAsync(int Month,int Year)
        {
            var transactions = await _moneyRepository.GetAllTransactionsAsync();

            var filteredTransactions = transactions
             .Where(t => t.Date.Month == Month && t.Date.Year == Year);
            var netSalary = _salarySummary.GetTotalSalary(filteredTransactions);
            return netSalary;
        }
        public async Task<TransactionMoney> ExecuteAsync(Guid Id)
        {
            var transactions = await _moneyRepository.GetTransactionByIdAsync(Id);
            return transactions;
        }
    }
}
