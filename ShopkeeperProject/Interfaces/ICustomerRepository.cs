using ShopkeeperProject.Domain.Entities;

namespace ShopkeeperProject.Interfaces
{
    public interface ICustomerRepository 
    {
        

        Task<Customer?> GetById(string id);
        Task<IEnumerable<Customer>> GetAll();
    
        Task<int> CreateCustomer(Customer customer);
        Task<int> UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(string id);
    }
}