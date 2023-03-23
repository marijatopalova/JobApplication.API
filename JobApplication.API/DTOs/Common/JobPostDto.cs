namespace JobApplication.API.DTOs.Common
{
    public class JobPostDto : IdentityDto
    {
        public string PositionName { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public bool IsRemote { get; set; }

        public string SeniorityLevel { get; set; }

        public string EmploymentType { get; set; }

        public int IndustryId { get; set; }
    }
}
