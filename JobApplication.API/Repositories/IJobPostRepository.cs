using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IJobPostRepository
    {
        Task<List<JobPost>> GetAllAsync();
        Task<JobPost> GetJobPostByIdAsync(int id);
        Task<List<JobPost>> GetActiveJobPostsAsync();
        Task AddJobPostAsync(JobPost vacancy);
        Task UpdateJobPostAsync(int id, JobPost vacancy);
        Task DeleteJobPostAsync(int id);
        Task SaveChangesAsync();
        Task CloseJobPostAsync(int id);  
    }
}
