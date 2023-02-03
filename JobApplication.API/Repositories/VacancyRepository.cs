using JobApplication.API.Enums;
using JobApplication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.API.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext context;

        public VacancyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddVacancyAsync(Vacancy vacancy)
        {
            var vacancyToAdd = new Vacancy();
            vacancyToAdd.PositionName = vacancy.PositionName;
            vacancyToAdd.Description = vacancy.Description;
            vacancyToAdd.CompanyName = vacancy.CompanyName;
            vacancyToAdd.Location = vacancy.Location;
            vacancyToAdd.IsRemote = vacancy.IsRemote;
            vacancyToAdd.SeniorityLevel = vacancy.SeniorityLevel;
            vacancyToAdd.EmploymentType = vacancy.EmploymentType;
            vacancyToAdd.ActiveStatus = JobPostStatus.Active;
            vacancyToAdd.IndustryId = vacancy.IndustryId;

            context.Add(vacancyToAdd);
            await SaveChangesAsync();
        }

        public async Task CloseJobPostAsync(int id)
        {
            var jobPost = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            jobPost.ActiveStatus = JobPostStatus.Closed;

            await SaveChangesAsync();
        }

        public async Task DeleteVacancyAsync(int id)
        {
            var vacancy = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (vacancy != null)
                context.Vacancies.Remove(vacancy);

            await SaveChangesAsync();
        }

        public async Task<List<Vacancy>> GetAllAsync()
        {
            return await context.Vacancies.Include(v => v.Industry).ToListAsync();
        }

        public async Task<Vacancy> GetVacancyByIdAsync(int id)
        {
            var vacancy = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (vacancy == null) return null;

            return vacancy;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateVacancyAsync(int id, Vacancy vacancy)
        {
            var vacancyToUpdate = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            vacancyToUpdate.PositionName = vacancy.PositionName;
            vacancyToUpdate.Description = vacancy.Description;
            vacancyToUpdate.CompanyName = vacancy.CompanyName;
            vacancyToUpdate.Location = vacancy.Location;
            vacancyToUpdate.IsRemote = vacancy.IsRemote;
            vacancyToUpdate.SeniorityLevel = vacancy.SeniorityLevel;
            vacancyToUpdate.EmploymentType = vacancy.EmploymentType;
            vacancyToUpdate.Industry = vacancy.Industry;

            await SaveChangesAsync();
        }
    }
}
