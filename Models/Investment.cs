namespace PersonalFinanceManagementAPI.Models
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
