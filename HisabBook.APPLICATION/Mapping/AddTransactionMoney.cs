using HisabBook.APPLICATION.DTO;
using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.Mapping
{
    public  class  AddTransactionMoney
    {
        
        public  TransactionMoney ToTransactionMoney(TransactionMoneyDTOs _moneyDTOs)
        {
            return new TransactionMoney
            {
                Type =  _moneyDTOs.Type,
                //Amount = _moneyDTOs.Type == TransactionType.Expense
                //? -_moneyDTOs.Amount
                //: _moneyDTOs.Amount,
                Amount = _moneyDTOs.Amount,
                NameCategory = _moneyDTOs.NameCategory,
                Notes = _moneyDTOs.Notes
            };

        }
    }
}
