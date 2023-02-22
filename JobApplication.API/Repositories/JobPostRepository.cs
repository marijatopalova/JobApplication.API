using JobApplication.API.Enums;
using JobApplication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.API.Repositories
{
    public class JobPostRepository : IJobPostRepository
    {
        private readonly ApplicationDbContext context;

        public JobPostRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddJobPostAsync(JobPost vacancy)
        {
            var vacancyToAdd = new JobPost();
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

        public async Task DeleteJobPostAsync(int id)
        {
            var vacancy = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (vacancy != null)
                context.Vacancies.Remove(vacancy);

            await SaveChangesAsync();
        }

        public Task<List<JobPost>> GetActiveJobPostsAsync()
        {
            return context.Vacancies.Where(x => x.ActiveStatus == JobPostStatus.Active).ToListAsync();
        }

        public async Task<List<JobPost>> GetAllAsync()
        {
            return await context.Vacancies.Include(v => v.Industry).ToListAsync();
        }

        public async Task<JobPost> GetJobPostByIdAsync(int id)
        {
            var vacancy = await context.Vacancies.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (vacancy == null) return null;

            return vacancy;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateJobPostAsync(int id, JobPost vacancy)
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
