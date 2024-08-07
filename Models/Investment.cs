using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManagementAPI.Models
{
    public class Investment
    {
        public int InvestmentId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
