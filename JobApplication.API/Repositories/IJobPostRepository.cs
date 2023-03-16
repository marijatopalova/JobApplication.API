using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IJobPostRepository
    {
        Task<List<JobPost>> GetAllAsync();
        Task<JobPost> GetJobPostByIdAsync(int id);
        Task<List<JobPost>> GetActiveJobPostsAsync();
        Task<List<Industry>> GetIndustries();
        Task AddJobPostAsync(JobPost jobPost);
        Task UpdateJobPostAsync(int id, JobPost jobPost);
        Task DeleteJobPostAsync(int id);
        Task SaveChangesAsync();
        Task CloseJobPostAsync(int id);  
    }
}
