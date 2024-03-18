namespace WAD._00014333.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; } 
        public ICollection<Job> Jobs { get; set; } 
    }
}
