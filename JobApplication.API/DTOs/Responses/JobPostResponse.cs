using JobApplication.API.DTOs.Common;

namespace JobApplication.API.DTOs.Responses
{
    public class JobPostResponse : JobPostDto
    {
        public string ActiveStatus { get; set; }

        public string IndustryName { get; set; }
    }
}
