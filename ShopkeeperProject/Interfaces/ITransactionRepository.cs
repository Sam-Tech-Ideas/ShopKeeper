using Microsoft.EntityFrameworkCore;
using ShopkeeperProject.Domain.Entities;

namespace ShopkeeperProject.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction?> GetById(string id);
        Task<Transaction?> GetLastTransactionByCustomerId(string customerId);
        Task<IEnumerable<Transaction>> GetByCustomerId(string customerId);
        IQueryable<Transaction> GetAll();
        Task<int> Add(Transaction transaction);
    }
}
