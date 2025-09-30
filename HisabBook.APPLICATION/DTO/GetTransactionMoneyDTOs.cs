using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.DTO
{
    public class GetTransactionMoneyDTOs
    {
        public decimal TotalSalary { get; set; }
        public IEnumerable<TransactionMoney> TransactionMoney { get; set; }=new HashSet<TransactionMoney>();
    }
}
