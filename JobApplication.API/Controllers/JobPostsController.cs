using AutoMapper;
using JobApplication.API.DTOs.Responses;
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
        private readonly IMapper _mapper;

        public JobPostsController(IJobPostRepository jobPostRepository, IMapper mapper)
        {
            this._jobPostRepository = jobPostRepository;
            this._mapper = mapper;
        }

        // GET /api/jobposts
        [HttpGet("")]
        public async Task<ActionResult<List<JobPostResponse>>> GetAllJobPostsAsync()
        {
            var jobPostList = await _jobPostRepository.GetAllAsync();

            List<JobPostResponse> response = new ();

            foreach (var jobPost in jobPostList)
            {
                response.Add (_mapper.Map<JobPostResponse>(jobPost));
            }

            return Ok(response);
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

        // GET /api/jobposts/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<JobPostResponse>> GetJobPostDetailsAsync(int id)
        {
            var jobPost = await _jobPostRepository.GetJobPostByIdAsync(id);

            JobPostResponse response = new()
            {
                Id = jobPost.Id,
                PositionName = jobPost.PositionName,
                Description = jobPost.Description,
                Location = jobPost.Location,
                CompanyName = jobPost.CompanyName,
                SeniorityLevel = jobPost.SeniorityLevel,
                EmploymentType = jobPost.EmploymentType,
                ActiveStatus = jobPost.ActiveStatus,
                IsRemote = jobPost.IsRemote,
                IndustryName = jobPost.Industry.Name
            };

            return Ok(response);
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
        public async Task<IActionResult> GetAllIndustriesAsync()
        {
            var industriesList = await _jobPostRepository.GetIndustries();
            return Ok(industriesList);
        }
    }
}
