using Microsoft.AspNetCore.Mvc;
using ShopkeeperProject.Core.Dto.Customer;
using ShopkeeperProject.Services.Interfaces;

namespace ShopkeeperProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    [Route("create-customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
    {
        var response = await _customerService.CreateCustomer(createCustomerDto);
        return StatusCode(response.Code, response);
    }

    [HttpGet]
    [Route("get-customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var response = await _customerService.GetCustomers();
        return StatusCode(response.Code, response);
    }


    //Get Customer by id
    [HttpGet]
    [Route("get-customer/{id}")]
    public async Task<IActionResult> GetCustomer([FromRoute] string id)
    {
        var response = await _customerService.GetCustomerById(id);
        return StatusCode(response.Code, response);
    }

    //Update Customer
    [HttpPut]
    [Route("update-customer/{id}")]
    public async Task<IActionResult> UpdateCustomer([FromRoute] string id,
        [FromBody] UpdateCustomerDto updateCustomerDto)
    {
        var response = await _customerService.UpdateCustomer(id, updateCustomerDto);
        return StatusCode(response.Code, response);
    }

    //Delete Customer
    [HttpDelete]
    [Route("delete-customer/{id}")]
    public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
    {
        var response = await _customerService.DeleteCustomer(id);
        return StatusCode(response.Code, response);
    }
}