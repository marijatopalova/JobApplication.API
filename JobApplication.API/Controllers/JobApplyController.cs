using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobApplyController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplyController(IJobApplicationRepository jobApplicationRepository)
        {
            this._jobApplicationRepository = jobApplicationRepository;
        }

        // POST /api/jobapply/1
        [HttpPost("{id:int}")]
        public async Task<IActionResult> JobApply(int id, Candidate candidate)
        {
            await _jobApplicationRepository.ApplyForJob(id, candidate);

            return Ok();
        }

        // GET /api/jobapply/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCandidatesPerJobPost(int id)
        {
            return Ok(await _jobApplicationRepository.GetCandidatesByJobPostId(id));
        }
    }
}
