using HisabBook.APPLICATION.DTO;
using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.Mapping
{
    public class EditTransactionMoney
    {
        public TransactionMoney ToTransactionMoney(TransactionMoneyDTOs _moneyDTOs, TransactionMoney _money)
        {
            if (_moneyDTOs.Type!=null)
                _money.Type = _moneyDTOs.Type;
            if (_moneyDTOs.Amount != 0)
                //_money.Amount = _moneyDTOs.Type == TransactionType.Expense
                //? -_moneyDTOs.Amount
                //: _moneyDTOs.Amount;
                _money.Amount = _moneyDTOs.Amount;
            if (!string.IsNullOrEmpty(_moneyDTOs.NameCategory))
                _money.NameCategory = _moneyDTOs.NameCategory;
            if (!string.IsNullOrEmpty(_moneyDTOs.Notes))
                _money.Notes = _moneyDTOs.Notes;
            return _money;

        }
    }
}
