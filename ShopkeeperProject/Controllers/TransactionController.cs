using Microsoft.AspNetCore.Mvc;
using ShopkeeperProject.Core.Dto.Transaction;
using ShopkeeperProject.Interfaces;
using ShopkeeperProject.Model;
using ShopkeeperProject.Services.Interfaces;

namespace ShopkeeperProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto transaction)
        {
            var response = await _transactionService.CreateTransaction(transaction);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            var response = await _transactionService.GetTransactionsByCustomerId(customerId);
            return StatusCode(response.Code, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter)
        {
            var response = await _transactionService.GetTransactions(filter);
            return StatusCode(response.Code, response);
        }


    }
}