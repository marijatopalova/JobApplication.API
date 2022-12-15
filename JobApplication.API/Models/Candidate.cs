namespace JobApplication.API.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsRecommended { get; set; }
        public int YearsOfExperience { get; set; }
        public string Message { get; set; }
    }
}
