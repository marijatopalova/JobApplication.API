using System.ComponentModel.DataAnnotations.Schema;

namespace JobApplication.API.Models
{
    public class JobApplicant
    {
        public int Id { get; set; }

        public int VacancyId { get; set; }

        [ForeignKey("VacancyId")]
        public virtual JobPost? Vacancy { get; set; }

        public int CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate? Candidate { get; set; }
    }
}
