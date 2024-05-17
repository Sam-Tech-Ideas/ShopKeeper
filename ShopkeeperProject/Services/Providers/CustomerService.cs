using AutoMapper;
using ShopkeeperProject.Core.Dto;
using ShopkeeperProject.Core.Dto.Customer;
using ShopkeeperProject.Domain.Entities;
using ShopkeeperProject.Interfaces;
using ShopkeeperProject.Model;
using ShopkeeperProject.Services.Interfaces;

namespace ShopkeeperProject.Services.Providers;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<AppResponse<GetCustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
    {
        try
        {
            var newCustomer = _mapper.Map<Customer>(createCustomerDto);
            var added = await _customerRepository.CreateCustomer(newCustomer);

            if (added < 1)
            {
                return new AppResponse<GetCustomerDto>("Sorry, Couldn't create customer",
                    StatusCodes.Status424FailedDependency, false);
            }

            var response = _mapper.Map<GetCustomerDto>(newCustomer);

            return new AppResponse<GetCustomerDto>("Customer saved", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<GetCustomerDto>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<GetCustomerDto>> UpdateCustomer(string id, UpdateCustomerDto updateCustomerDto)
    {
        try
        {
            var customer = await _customerRepository.GetById(id);
            if (customer is null)
            {
                return new AppResponse<GetCustomerDto>("Customer not found", StatusCodes.Status404NotFound, false);
            }

            _mapper.Map(updateCustomerDto, customer);
            var updated = await _customerRepository.UpdateCustomer(customer);

            if (updated < 1)
            {
                return new AppResponse<GetCustomerDto>("Sorry, Couldn't update customer",
                    StatusCodes.Status424FailedDependency, false);
            }

            var response = _mapper.Map<GetCustomerDto>(customer);

            return new AppResponse<GetCustomerDto>("Customer updated", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<GetCustomerDto>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<GetCustomerDto>> GetCustomerById(string id)
    {
        try
        {
            var customer = await _customerRepository.GetById(id);
            if (customer is null)
            {
                return new AppResponse<GetCustomerDto>("Customer not found", StatusCodes.Status404NotFound, false);
            }

            var response = _mapper.Map<GetCustomerDto>(customer);

            return new AppResponse<GetCustomerDto>("Customer found", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<GetCustomerDto>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<List<GetCustomerDto>>> GetCustomers()
    {
        try
        {
            var customers = await _customerRepository.GetAll();
            var response = _mapper.Map<List<GetCustomerDto>>(customers);

            return new AppResponse<List<GetCustomerDto>>("Customers found", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<List<GetCustomerDto>>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<GetCustomerDto>> DeleteCustomer(string id)
    {
        try
        {
            var customer = await _customerRepository.GetById(id);
            if (customer is null)
            {
                return new AppResponse<GetCustomerDto>("Customer not found", StatusCodes.Status404NotFound, false);
            }

            var deleted = await _customerRepository.DeleteCustomer(id);

            if (deleted < 1)
            {
                return new AppResponse<GetCustomerDto>("Sorry, Couldn't delete customer",
                    StatusCodes.Status424FailedDependency, false);
            }

            var response = _mapper.Map<GetCustomerDto>(customer);

            return new AppResponse<GetCustomerDto>("Customer deleted", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<GetCustomerDto>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }
}