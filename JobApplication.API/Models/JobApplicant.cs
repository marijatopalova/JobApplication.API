using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.API.Models
{
    public class JobApplicant
    {
        public int Id { get; set; }

        public int JobPostId { get; set; }

        [ForeignKey("JobPostId")]
        public virtual JobPost? JobPost { get; set; }

        public int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate? Candidate { get; set; }
    }
}
