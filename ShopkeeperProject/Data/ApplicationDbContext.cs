using Microsoft.EntityFrameworkCore;
using ShopkeeperProject.Domain.Entities;

namespace ShopkeeperProject.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}