using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopkeeperProject.Core.Dto;
using ShopkeeperProject.Core.Dto.Customer;
using ShopkeeperProject.Core.Dto.Transaction;
using ShopkeeperProject.Domain.Entities;

namespace Note.API.Core.Automapper
{
    public class AutomapperConfigProfile : AutoMapper.Profile
    {

        public AutomapperConfigProfile()
        {
            //Customer
        CreateMap<CreateCustomerDto, Customer>().ReverseMap();
        CreateMap<Customer, GetCustomerDto>().ReverseMap();
        CreateMap<UpdateCustomerDto, Customer>().ReverseMap();

        //Transaction
        CreateMap<CreateTransactionDto, Transaction>().ReverseMap();
        CreateMap<Transaction, GetTransactionDto>().ReverseMap();
        }

    }

    
}