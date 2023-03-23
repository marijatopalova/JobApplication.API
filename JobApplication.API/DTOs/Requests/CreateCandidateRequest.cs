namespace JobApplication.API.DTOs.Requests
{
    public class CreateCandidateRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int YearsOfExperience { get; set; }

        public string Message { get; set; }
    }
}
