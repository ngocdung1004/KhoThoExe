namespace KhoThoExe.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int WorkerID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // 'QR', 'BankTransfer', 'Other'
        public string PaymentStatus { get; set; } = "Pending"; // 'Pending', 'Completed', 'Failed'
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;

        public virtual Worker Worker { get; set; } // Liên kết đến Worker
    }
}
