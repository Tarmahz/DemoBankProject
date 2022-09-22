using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBankProject.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        
        public string AccountNumber { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public string AccountName { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        public AccountType AccountType { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateLastUpdated { get; set; } = DateTime.Now;
        public Customer Customer{ get; set; }
        public ICollection<Transaction> Transactions
        {
            get; set; 
        }

        Random random = new Random();
        public Account()
        {
            //AccountNumber = Convert.ToString((long)random.NextDouble() * 9_000_000_000L + 1_000_000_000L);
            AccountNumber = Convert.ToString((long)random.Next(2) * 9_000_000_000L);
            //AccountName = $"{FirstName} {LastName}";
        }
    }
    public enum AccountType
    {
        Savings,
        Current
    }

}

