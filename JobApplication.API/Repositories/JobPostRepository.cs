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

        public async Task AddJobPostAsync(JobPost jobPost)
        {
            var jobPostToAdd = new JobPost();
            jobPostToAdd.PositionName = jobPost.PositionName;
            jobPostToAdd.Description = jobPost.Description;
            jobPostToAdd.CompanyName = jobPost.CompanyName;
            jobPostToAdd.Location = jobPost.Location;
            jobPostToAdd.IsRemote = jobPost.IsRemote;
            jobPostToAdd.SeniorityLevel = jobPost.SeniorityLevel;
            jobPostToAdd.EmploymentType = jobPost.EmploymentType;
            jobPostToAdd.ActiveStatus = JobPostStatus.Active;
            jobPostToAdd.IndustryId = jobPost.IndustryId;

            context.Add(jobPostToAdd);
            await SaveChangesAsync();
        }

        public async Task CloseJobPostAsync(int id)
        {
            var jobPost = await context.JobPosts.Where(v => v.Id == id).FirstOrDefaultAsync();

            jobPost.ActiveStatus = JobPostStatus.Closed;

            await SaveChangesAsync();
        }

        public async Task DeleteJobPostAsync(int id)
        {
            var jobPost = await context.JobPosts.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (jobPost != null)
                context.JobPosts.Remove(jobPost);

            await SaveChangesAsync();
        }

        public Task<List<JobPost>> GetActiveJobPostsAsync()
        {
            return context.JobPosts.Where(x => x.ActiveStatus == JobPostStatus.Active).ToListAsync();
        }

        public async Task<List<JobPost>> GetAllAsync()
        {
            return await context.JobPosts.Include(v => v.Industry).ToListAsync();
        }

        public async Task<JobPost> GetJobPostByIdAsync(int id)
        {
            var jobPost = await context.JobPosts.Where(v => v.Id == id).FirstOrDefaultAsync();

            if (jobPost == null) return null;

            return jobPost;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateJobPostAsync(int id, JobPost jobPost)
        {
            var jobPostToUpdate = await context.JobPosts.Where(v => v.Id == id).FirstOrDefaultAsync();

            jobPostToUpdate.PositionName = jobPost.PositionName;
            jobPostToUpdate.Description = jobPost.Description;
            jobPostToUpdate.CompanyName = jobPost.CompanyName;
            jobPostToUpdate.Location = jobPost.Location;
            jobPostToUpdate.IsRemote = jobPost.IsRemote;
            jobPostToUpdate.SeniorityLevel = jobPost.SeniorityLevel;
            jobPostToUpdate.EmploymentType = jobPost.EmploymentType;
            jobPostToUpdate.Industry = jobPost.Industry;

            await SaveChangesAsync();
        }
    }
}
