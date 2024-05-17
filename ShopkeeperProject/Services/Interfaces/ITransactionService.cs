using ShopkeeperProject.Core.Dto;
using ShopkeeperProject.Core.Dto.Transaction;
using ShopkeeperProject.Model;

namespace ShopkeeperProject.Services.Interfaces;

public interface ITransactionService
{
    Task<AppResponse<GetTransactionDto>> CreateTransaction(CreateTransactionDto createTransactionDto);
    Task<AppResponse<List<GetTransactionDto>>> GetTransactionsByCustomerId(string customerId);
    Task<AppResponse<List<GetTransactionDto>>> GetTransactions(BaseFilter filter);
}