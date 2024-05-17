using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace  ShopkeeperProject.Domain.Entities
{
    public class Transaction
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");


        [Required]
        public string CustomerId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public decimal Amount {get;set;} = 0m;
        public string UniqueNumber { get; set; } = Guid.NewGuid().ToString("N");
        
        public string? Remarks { get; set; }

         [Required]
        public string Type { get; set; }


        public decimal Balance { get; set; } = 0m;

        public decimal TotalAmount { get; set; } = 0m;






    }
}


