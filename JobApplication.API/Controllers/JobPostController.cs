using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostController : Controller
    {
        private readonly IJobPostRepository _jobPostRepository;

        public JobPostController(IJobPostRepository jobPostRepository)
        {
            this._jobPostRepository = jobPostRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActiveJobPostsAsync()
        {
            return Ok(await _jobPostRepository.GetActiveJobPostsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobPostAsync(Vacancy vacancy)
        {
            await _jobPostRepository.AddJobPostAsync(vacancy);
            return Ok(vacancy);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteJobPostAsync(int id)
        {
            await _jobPostRepository.DeleteJobPostAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobPostAsync(int id, Vacancy vacancy)
        {
            await _jobPostRepository.UpdateJobPostAsync(id, vacancy);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> CloseJobPostAsync(int id)
        {
            await _jobPostRepository.CloseJobPostAsync(id);
            return Ok();
        }
    }
}
