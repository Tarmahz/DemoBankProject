using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoBankProject.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string TransactionReference { get; set; }
        [ForeignKey("Accounts")]
        public int AccountId { get; set; }
        public decimal TransactionAmount { get; set; }
        public TransStatus TransactionStatus { get; set; }
        public bool IsSuccessful => TransactionStatus.Equals(TransStatus.Success);
        public string SourceAccount { get; set; }
        public string DestinationAccount { get; set; }
        public string TransactionReceipt { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public TransType TransactionType { get; set; }
        public Account Account { get; set; }

        public Transaction()
        {
            TransactionReference = $"{Guid.NewGuid().ToString().Replace("-", "").Substring(1, 27)}";
        }

    }
    public enum TransStatus
    {
        Failed,
        Success,
        Pending

    }

    public enum TransType
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}


