using System.ComponentModel.DataAnnotations;

namespace KhoThoExe.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public int UserID { get; set; }
        public string JobType { get; set; } // Loại nghề nghiệp
        public int ExperienceYears { get; set; }
        public float Rating { get; set; } = 0;
        public string Bio { get; set; }
        public bool Verified { get; set; } = false;

        public virtual User User { get; set; } // Liên kết đến User
    }

}
