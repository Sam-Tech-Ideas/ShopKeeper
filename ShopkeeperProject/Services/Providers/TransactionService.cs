using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopkeeperProject.Core.Dto;
using ShopkeeperProject.Core.Dto.Transaction;
using ShopkeeperProject.Domain.Entities;
using ShopkeeperProject.Interfaces;
using ShopkeeperProject.Model;
using ShopkeeperProject.Services.Interfaces;

namespace ShopkeeperProject.Services.Providers;

public class TransactionService : ITransactionService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public TransactionService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }

    public async Task<AppResponse<GetTransactionDto>> CreateTransaction(CreateTransactionDto createTransactionDto)
    {
        try
        {
            var customer = await _customerRepository.GetById(createTransactionDto.CustomerId);
            if (customer is null)
            {
                return new AppResponse<GetTransactionDto>("Customer not found", StatusCodes.Status404NotFound, false);
            }

            var transaction = _mapper.Map<Transaction>(createTransactionDto);

            switch (transaction.Type)
            {
                case "Invoice":
                    customer.CurrentBalance += transaction.Amount;
                    transaction.Balance = customer.CurrentBalance;
                    break;
                case "Payment":
                    if (customer.CurrentBalance < transaction.Amount)
                    {
                        return new AppResponse<GetTransactionDto>("Insufficient balance",
                            StatusCodes.Status424FailedDependency, false);
                    }

                    customer.CurrentBalance -= transaction.Amount;
                    transaction.Balance = customer.CurrentBalance;
                    break;
            }

            var lastTransaction = await _transactionRepository.GetLastTransactionByCustomerId(customer.Id);

            if (lastTransaction != null)
            {
                transaction.TotalAmount = lastTransaction.TotalAmount + transaction.Amount;
            }
            else
            {
                transaction.TotalAmount = transaction.Amount;
            }

            var added = await _transactionRepository.Add(transaction);

            if (added < 1)
            {
                return new AppResponse<GetTransactionDto>("Sorry, Couldn't create transaction",
                    StatusCodes.Status424FailedDependency, false);
            }

            await _customerRepository.UpdateCustomer(customer);

            var response = _mapper.Map<GetTransactionDto>(transaction);

            return new AppResponse<GetTransactionDto>("Transaction saved", StatusCodes.Status200OK, true, response);
        }
        catch (Exception ex)
        {
            return new AppResponse<GetTransactionDto>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<List<GetTransactionDto>>> GetTransactionsByCustomerId(string customerId)
    {
        try
        {
            var customer = await _customerRepository.GetById(customerId);
            if (customer is null)
            {
                return new AppResponse<List<GetTransactionDto>>("Customer not found", StatusCodes.Status404NotFound,
                    false);
            }

            var transactions = await _transactionRepository.GetByCustomerId(customerId);

            var response = _mapper.Map<List<GetTransactionDto>>(transactions);

            return new AppResponse<List<GetTransactionDto>>("Transactions found", StatusCodes.Status200OK, true,
                response);
        }
        catch (Exception ex)
        {
            return new AppResponse<List<GetTransactionDto>>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }

    public async Task<AppResponse<List<GetTransactionDto>>> GetTransactions(BaseFilter filter)
    {
        try
        {
            var queryable = _transactionRepository.GetAll().OrderBy(t => t.CreatedAt);
            
            if(!string.IsNullOrEmpty(filter.CustomerId))
            {
                queryable = queryable.Where(t => t.CustomerId == filter.CustomerId).OrderBy(t => t.CreatedAt);
            }

            if (filter.StartDate is null && filter.EndDate is null)
            {
                queryable = queryable.Where(t => t.TransactionDate <= DateTime.UtcNow).OrderBy(t => t.CreatedAt);
            }

            if (filter.StartDate is not null)
            {
                queryable = queryable.Where(t => t.TransactionDate >= filter.StartDate).OrderBy(t => t.CreatedAt);
            }

            if (filter.EndDate is not null)
            {
                queryable = queryable.Where(t => t.TransactionDate <= filter.EndDate).OrderBy(t => t.CreatedAt);
            }

            var transactions = await queryable.ToListAsync();

            var response = _mapper.Map<List<GetTransactionDto>>(transactions);

            return new AppResponse<List<GetTransactionDto>>("Transactions found", StatusCodes.Status200OK, true,
                response);
        }
        catch (Exception ex)
        {
            return new AppResponse<List<GetTransactionDto>>("Failed", StatusCodes.Status500InternalServerError, false);
        }
    }
}