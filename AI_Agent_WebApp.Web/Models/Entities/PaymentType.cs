using System.ComponentModel.DataAnnotations;

namespace AI_Agent_WebApp.Models.Entities
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
