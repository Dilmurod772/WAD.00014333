namespace WAD._00014333.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; } 
        public DateTime PostedDate { get; set; }
        public int CompanyId { get; set; } 
        public Company Company { get; set; }
    }
}
