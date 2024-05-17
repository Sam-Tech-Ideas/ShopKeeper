using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopkeeperProject.Core.Dto
{
    public class GetCustomerDto
    {
     

        public string Id { get; set; } 


        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }


         public string? Email { get; set; }


    
        public string Phone { get; set; }

        public string? Address { get; set; }
         public decimal CurrentBalance { get; set; } 




    }
}