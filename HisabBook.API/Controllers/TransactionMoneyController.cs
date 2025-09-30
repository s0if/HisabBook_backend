using HisabBook.APPLICATION.DTO;
using HisabBook.APPLICATION.UseCase;
using HisabBook.DOMAIN.Interface;
using HisabBook.DOMAIN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HisabBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionMoneyController : ControllerBase
    {
        private readonly CreateTransactionMoney _createTransaction;
        private readonly UpdateTransactionMoney _updateTransaction;
        private readonly DeleteTransactionMoney _deleteTransaction;
        private readonly GetAllTransactionMoney _getAllTransaction;

        public TransactionMoneyController(CreateTransactionMoney createTransaction,
            UpdateTransactionMoney updateTransaction,
            DeleteTransactionMoney deleteTransaction,
            GetAllTransactionMoney getAllTransaction)
        {
            _createTransaction = createTransaction;
            _updateTransaction = updateTransaction;
            _deleteTransaction = deleteTransaction;
            _getAllTransaction = getAllTransaction;
        }
        [HttpPost]
        public async Task<ActionResult<TransactionMoneyDTOs>> CreateTransaction([FromBody] TransactionMoneyDTOs transaction)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _createTransaction.ExecuteAsync(transaction);
            return Ok(result);
        }
        [HttpPut("{ID}")]
        public async Task<ActionResult<TransactionMoneyDTOs>> UpdateTransaction([FromBody] TransactionMoneyDTOs transaction,Guid ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _updateTransaction.ExecuteAsync(ID,transaction);
            return Ok(result);
        }
        [HttpDelete("{ID}")]
        public async Task<ActionResult<TransactionMoneyDTOs>> DeleteTransaction( Guid ID)
        {

            if(ID == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }
             await _deleteTransaction.ExecuteAsync(ID);
            return Ok();
        }
        [HttpGet("All")]
        public async Task<ActionResult<GetTransactionMoneyDTOs>> GetAllTransactions()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transactions = await _getAllTransaction.ExecuteAsync();
            return Ok(transactions);
        }
        [HttpGet("{ID}")]
        public async Task<ActionResult<TransactionMoney>> GetTransactionsById(Guid ID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transactions = await _getAllTransaction.ExecuteAsync(ID);
            return Ok(transactions);
        }
        [HttpGet("{Month}/{Year}")]
        public async Task<ActionResult<TransactionMoney>> GetTransactionsByMonthAndYear(int Month, int Year)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var transactions = await _getAllTransaction.ExecuteAsync(Month, Year);
            return Ok(transactions);
        }
       

    }
}
