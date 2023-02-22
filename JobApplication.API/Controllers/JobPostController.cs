using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JobPostController : Controller
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostController(IJobPostRepository jobPostRepository)
        {
            this._jobPostRepository = jobPostRepository;
        }

        [HttpGet]
        [ActionName("GetAllJobPostsAsync")]
        public async Task<IActionResult> GetAllJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetAllAsync());
        }

        [HttpGet]
        [ActionName("GetAllActiveJobPostsAsync")]
        public async Task<IActionResult> GetAllActiveJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetActiveJobPostsAsync());
        }

        [HttpPost]
        [ActionName("CreateJobPostAsync")]
        public async Task<IActionResult> CreateJobPostAsync(JobPost vacancy)
        {
            await _jobPostRepository.AddJobPostAsync(vacancy);
            return Ok(vacancy);
        }

        [HttpDelete]
        [ActionName("DeleteJobPostAsync")]
        public async Task<IActionResult> DeleteJobPostAsync(int id)
        {
            await _jobPostRepository.DeleteJobPostAsync(id);
            return Ok();
        }

        [HttpPut]
        [ActionName("UpdateJobPostAsync")]
        public async Task<IActionResult> UpdateJobPostAsync(int id, JobPost vacancy)
        {
            await _jobPostRepository.UpdateJobPostAsync(id, vacancy);
            return Ok();
        }

        [HttpPatch]
        [ActionName("CloseJobPostAsync")]
        public async Task<IActionResult> CloseJobPostAsync(int id)
        {
            await _jobPostRepository.CloseJobPostAsync(id);
            return Ok();
        }
    }
}
