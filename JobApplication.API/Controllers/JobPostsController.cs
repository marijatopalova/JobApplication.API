using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostsController : Controller
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostsController(IJobPostRepository jobPostRepository)
        {
            this._jobPostRepository = jobPostRepository;
        }

        // GET /api/jobposts
        [HttpGet("")]
        public async Task<IActionResult> GetAllJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetAllAsync());
        }

        // GET /api/jobposts/active
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetActiveJobPostsAsync());
        }

        // POST /api/jobposts
        [HttpPost]
        public async Task<IActionResult> CreateJobPostAsync(JobPost jobPost)
        {
            await _jobPostRepository.AddJobPostAsync(jobPost);
            return Ok(jobPost);
        }

        // DELETE /api/jobposts/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteJobPostAsync(int id)
        {
            await _jobPostRepository.DeleteJobPostAsync(id);
            return Ok();
        }

        // PUT /api/jobposts/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateJobPostAsync(int id, JobPost jobPost)
        {
            await _jobPostRepository.UpdateJobPostAsync(id, jobPost);
            return Ok(jobPost);
        }

        // PATCH /api/jobposts/1
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> CloseJobPostAsync(int id)
        {
            await _jobPostRepository.CloseJobPostAsync(id);
            return Ok();
        }

        // GET /api/jobposts/industries
        [HttpGet("industries")]
        public async Task<IActionResult> GetAllIndustries()
        {
            var industriesList = await _jobPostRepository.GetIndustries();
            return Ok(industriesList);
        }
    }
}
