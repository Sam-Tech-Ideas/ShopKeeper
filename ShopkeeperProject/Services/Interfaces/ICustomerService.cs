using ShopkeeperProject.Core.Dto;
using ShopkeeperProject.Core.Dto.Customer;
using ShopkeeperProject.Model;

namespace ShopkeeperProject.Services.Interfaces;

public interface ICustomerService
{
    Task<AppResponse<GetCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto);
    Task<AppResponse<GetCustomerDto>> UpdateCustomer(string id, UpdateCustomerDto updateCustomerDto);
    Task<AppResponse<GetCustomerDto>> GetCustomerById(string id);
    Task<AppResponse<List<GetCustomerDto>>> GetCustomers();
    Task<AppResponse<GetCustomerDto>> DeleteCustomer(string id);
}