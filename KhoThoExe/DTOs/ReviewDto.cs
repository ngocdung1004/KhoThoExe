namespace KhoThoExe.DTOs
{
    public class ReviewDto
    {
        public int ReviewID { get; set; }
        public int WorkerID { get; set; }
        public int CustomerID { get; set; }
        public int Rating { get; set; } // Đánh giá từ 1 đến 5
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
