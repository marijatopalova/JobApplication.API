using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IJobPostRepository
    {
        Task<List<Vacancy>> GetAllAsync();
        Task<Vacancy> GetJobPostByIdAsync(int id);
        Task<List<Vacancy>> GetActiveJobPostsAsync();
        Task AddJobPostAsync(Vacancy vacancy);
        Task UpdateJobPostAsync(int id, Vacancy vacancy);
        Task DeleteJobPostAsync(int id);
        Task SaveChangesAsync();
        Task CloseJobPostAsync(int id);  
    }
}
