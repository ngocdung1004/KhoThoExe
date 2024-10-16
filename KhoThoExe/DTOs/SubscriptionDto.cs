namespace KhoThoExe.DTOs
{
    public class SubscriptionDto
    {
        public int SubscriptionID { get; set; }
        public int WorkerID { get; set; }
        public string SubscriptionType { get; set; } // 'Monthly' hoặc 'Yearly'
        public string PaymentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string QRCode { get; set; }
    }

}
