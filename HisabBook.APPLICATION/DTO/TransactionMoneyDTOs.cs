using HisabBook.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HisabBook.APPLICATION.DTO
{
    
    public class TransactionMoneyDTOs
    {
        //[Required(ErrorMessage = "Transaction type is required.")]
        [RegularExpression("^(?:Expense|Income)$", ErrorMessage = "Transaction type must be either 'Expense' or 'Income'.")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string NameCategory { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "Notes cannot exceed 250 characters.")]
        public string Notes { get; set; } = string.Empty;
    }
}
