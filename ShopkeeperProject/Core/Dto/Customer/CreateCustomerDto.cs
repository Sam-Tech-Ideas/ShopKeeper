
using System;
using System.ComponentModel.DataAnnotations;

namespace ShopkeeperProject.Core.Dto.Customer
{
    public class CreateCustomerDto
    {


       


     [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }



        [Required]
        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public string? Email { get; set; }


        [Required]
        public string Phone { get; set; }

        public string? Address { get; set; }

        public decimal CurrentBalance { get; set; } = 0m;


        
    }
}