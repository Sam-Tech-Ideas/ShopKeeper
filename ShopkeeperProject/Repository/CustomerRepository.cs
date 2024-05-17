using Microsoft.EntityFrameworkCore;
using ShopkeeperProject.Data;
using ShopkeeperProject.Domain.Entities;
using ShopkeeperProject.Interfaces;

namespace ShopkeeperProject.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetById(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer is null) return 0;
            
            _context.Customers.Remove(customer);
            return await _context.SaveChangesAsync();
        }
    }
}