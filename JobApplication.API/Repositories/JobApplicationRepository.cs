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
            var job = context.JobPosts.Where(x => x.Id == jobId).FirstOrDefault();

            if (job == null || job.ActiveStatus == JobPostStatus.Closed)
            {
                throw new Exception("You can't apply at this job because it might be deleted or closed.");
            }

            var newJobApplicant = new JobApplicant
            {
                JobPostId = jobId,
                Candidate = new Candidate
                {
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    Email = candidate.Email,
                    Phone = candidate.Phone,
                    YearsOfExperience = candidate.YearsOfExperience,
                    Message = candidate.Message,
                    DateOfApplication = DateTime.UtcNow
                }
            };

            context.JobApplicants.Add(newJobApplicant);
            await SaveChangesAsync();
        }

        public async Task<List<Candidate>> GetCandidatesByJobPostId(int jobPostId)
        {
            var candidateIds = context.JobApplicants.Where(x => x.JobPostId == jobPostId).Select(x => x.CandidateId);

            return await context.Candidates
                .Where(x => candidateIds
                .Any(v => v.Equals(x.Id)))
                .OrderByDescending(x => x.DateOfApplication)
                .ToListAsync();
        }
    }
}
