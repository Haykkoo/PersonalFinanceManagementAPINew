using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManagementAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //public ICollection<Income> Incomes { get; set; }
        //public ICollection<Expense> Expenses { get; set; }
        //public ICollection<Investment> Investments { get; set; }
    }
}
