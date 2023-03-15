using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IJobApplicationRepository
    {
        Task ApplyForJob(int jobId, Candidate candidate);

        Task<IEnumerable<Candidate>> GetCandidatesByJobPostId(int jobPostId);

        Task SaveChangesAsync();
    }
}
