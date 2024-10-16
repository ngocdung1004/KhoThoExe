namespace KhoThoExe.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public int WorkerID { get; set; }
        public string SubscriptionType { get; set; } // 'Monthly' hoặc 'Yearly'
        public string PaymentStatus { get; set; } = "Pending"; // 'Pending', 'Completed', 'Failed'
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QRCode { get; set; }

        public virtual Worker Worker { get; set; } // Liên kết đến Worker
    }
}
