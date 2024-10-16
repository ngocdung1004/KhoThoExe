namespace KhoThoExe.DTOs
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }
        public int WorkerID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } // 'QR', 'BankTransfer', 'Other'
        public string PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }
    }

}
