using Microsoft.EntityFrameworkCore;
using ShopkeeperProject.Data;
using ShopkeeperProject.Domain.Entities;
using ShopkeeperProject.Interfaces;

namespace ShopkeeperProject.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetById(string id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return transaction;
        }

        public async Task<Transaction?> GetLastTransactionByCustomerId(string customerId)
        {
            var transaction = await _context.Transactions.Where(t => t.CustomerId == customerId)
                .OrderByDescending(t => t.CreatedAt).FirstOrDefaultAsync();
            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetByCustomerId(string customerId)
        {
            var transactions = await _context.Transactions.Where(t => t.CustomerId == customerId).ToListAsync();
            return transactions;
        }

        public IQueryable<Transaction> GetAll()
        {
            return _context.Transactions;
        }

        public async Task<int> Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            return await _context.SaveChangesAsync();
        }
    }
}
