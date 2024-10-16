namespace KhoThoExe.Models
{
    public class WorkerJobType
    {
        // Thêm thuộc tính khóa chính
        public int WorkerJobTypeID { get; set; } // Khóa chính

        public int WorkerID { get; set; }
        public int JobTypeID { get; set; }

        public virtual Worker Worker { get; set; } // Liên kết đến Worker
        public virtual JobType JobType { get; set; } // Liên kết đến JobType
    }
}
