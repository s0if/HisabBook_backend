using HisabBook.APPLICATION.DTO;
using HisabBook.DOMAIN.Interface;
using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.UseCase
{
    public class SalarySummary
    {
        private readonly ITransactionMoneyRepository _moneyRepository;

        public SalarySummary(ITransactionMoneyRepository moneyRepository)
        {
            _moneyRepository = moneyRepository;
        }
        public GetTransactionMoneyDTOs GetTotalSalary(IEnumerable<TransactionMoney> allTransactions)
        {
            decimal totalIncome = allTransactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);
            decimal totalExpense = allTransactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);
            decimal totalSalary= totalIncome - totalExpense;
            var result = new GetTransactionMoneyDTOs
            {
                TransactionMoney = allTransactions,
                TotalSalary = totalSalary
            };
            return result;
        }
    }
}
