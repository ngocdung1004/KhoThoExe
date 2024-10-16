namespace KhoThoExe.DTOs
{
    public class WorkerDto
    {
        public int WorkerID { get; set; }
        public int UserID { get; set; }
        public string JobType { get; set; } // Loại nghề nghiệp
        public int ExperienceYears { get; set; }
        public float Rating { get; set; }
        public string Bio { get; set; }
        public bool Verified { get; set; }
    }

}
