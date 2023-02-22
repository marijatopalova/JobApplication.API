using JobApplication.API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.API.Models
{
    public class JobPost
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

        public int IndustryId { get; set; }

        [ForeignKey("IndustryId")]
        public virtual Industry? Industry { get; set; }
    }
}
