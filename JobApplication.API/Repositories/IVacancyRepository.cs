using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IVacancyRepository
    {
        Task<List<Vacancy>> GetAllAsync();
        Task<Vacancy> GetVacancyByIdAsync(int id);
        Task AddVacancyAsync(Vacancy vacancy);
        Task UpdateVacancyAsync(int id, Vacancy vacancy);
        Task DeleteVacancyAsync(int id);
        Task SaveChangesAsync();
        Task CloseJobPostAsync(int id);  
    }
}
