using JobApplication.API.Enums;
using JobApplication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.API.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private readonly ApplicationDbContext context;

        public JobApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task ApplyForJob(int jobId, Candidate candidate)
        {
            var job = context.Vacancies.Where(x => x.Id == jobId).FirstOrDefault();

            if (job == null || job.ActiveStatus == JobPostStatus.Closed)
            {
                throw new Exception("You can't apply at this job because it might be deleted or closed.");
            }

            var newJobApplicant = new JobApplicant
            {
                VacancyId = jobId,
                Candidate = new Candidate
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    Phone = candidate.Phone,
                    YearsOfExperience = candidate.YearsOfExperience,
                    Message = candidate.Message
                }
            };

            context.JobApplicants.Add(newJobApplicant);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Vacancy>> GetVacanciesByUserId(int userId)
        {
            var vacancyIds = context.JobApplicants.Where(x => x.CandidateId == userId).Select(x => x.VacancyId);

            return await context.Vacancies.Where(x => vacancyIds.Any(v => v.Equals(x.Id))).ToListAsync();
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesByVacancyId(int vacancyId)
        {
            var candidateIds = context.JobApplicants.Where(x => x.VacancyId == vacancyId).Select(x => x.CandidateId);

            return await context.Candidates.Where(x => candidateIds.Any(v => v.Equals(x.Id))).ToListAsync();
        }
    }
}
