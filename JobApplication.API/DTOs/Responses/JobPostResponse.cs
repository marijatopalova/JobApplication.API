using JobApplication.API.Enums;

namespace JobApplication.API.DTOs.Responses
{
    public class JobPostResponse
    {
        public int Id { get; set; }

        public string PositionName { get; set; }

        public string Description { get; set; }

        public string CompanyName { get; set; }

        public string Location { get; set; }

        public bool IsRemote { get; set; }

        public SeniorityLevel SeniorityLevel { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public JobPostStatus ActiveStatus { get; set; }

        public string IndustryName { get; set; }
    }
}
