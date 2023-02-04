using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IJobApplicationRepository
    {
        Task ApplyForJob(int jobId, Candidate candidate);

        Task<IEnumerable<Vacancy>> GetVacanciesByUserId(int userId);

        Task<IEnumerable<Candidate>> GetCandidatesByVacancyId(int vacancyId);

        Task SaveChangesAsync();
    }
}
