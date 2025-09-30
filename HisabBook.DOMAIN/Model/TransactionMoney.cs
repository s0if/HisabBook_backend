using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.DOMAIN.Model
{
    public enum TransactionType
    {
        Expense,
        Income
    }
    public class TransactionMoney
    {
        private readonly TimeZoneInfo _palestineTimeZone;
        public TransactionMoney()
        {
            _palestineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Gaza");
            Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _palestineTimeZone);
        }
        public Guid Id { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string NameCategory { get; set; } = string.Empty;
        public string Notes { get; set; }=string.Empty;
        public DateTime Date { get; set; }
    }
    
}
