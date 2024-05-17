using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopkeeperProject.Core.Dto.Transaction
{
    public class CreateTransactionDto
    {
        [Required] public string CustomerId { get; set; }

        [Required] public DateTime TransactionDate { get; set; }

        [Required] public decimal Amount { get; set; }
        [JsonIgnore]

        public string UniqueNumber { get; set; } = Guid.NewGuid().ToString("N");

        //remarks
        public string? Remarks { get; set; }


        [Required]
        [RegularExpression("Invoice|Payment", ErrorMessage = "Invalid transaction type. Allowed values are Invoice, Payment.")]
        [AllowedValues("Invoice", "Payment", ErrorMessage = "Invalid transaction type. Allowed values are Invoice, Payment.")]
        public string Type { get; set; }
    }
}