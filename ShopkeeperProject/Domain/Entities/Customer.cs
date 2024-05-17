using System.ComponentModel.DataAnnotations;


namespace ShopkeeperProject.Domain.Entities
{
    public class Customer
    {
        [Key] public string Id { get; set; } = Guid.NewGuid().ToString("N");


        [Required(AllowEmptyStrings = false)] public string Name { get; set; }


        [Required] public DateTime Date { get; set; }

        public string? Description { get; set; }


        public string? Email { get; set; }


        [Required] public string Phone { get; set; }

        public string? Address { get; set; }
        public decimal CurrentBalance { get; set; } = 0m;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}