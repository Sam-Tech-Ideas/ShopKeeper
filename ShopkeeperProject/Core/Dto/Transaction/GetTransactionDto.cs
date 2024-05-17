using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopkeeperProject.Core.Dto;

namespace ShopkeeperProject.Core.Dto
{
    public class GetTransactionDto
    {
     
        public string Id { get; set; } 
        

        public DateTime TransactionDate { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string UniqueNumber { get; set; }
        //remarks
        public string? Remarks { get; set; }

        public string Type { get; set; }

        //balance{derived by subtracting debit from credit}
        public decimal Balance { get; set; }

        public decimal? TotalAmount { get; set; }

    }
}