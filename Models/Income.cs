namespace PersonalFinanceManagementAPI.Models
{
    public class Income
    {
        public int IncomeId { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
