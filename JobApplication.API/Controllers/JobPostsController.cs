using AutoMapper;
using JobApplication.API.DTOs.Requests;
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
            var jobPostList = _mapper.Map<List<JobPost>, List<JobPostResponse>>(await _jobPostRepository.GetAllAsync());

            return Ok(jobPostList);
        }

        // GET /api/jobposts/active
        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveJobPostsAsync()
        {
            var activeJobPosts = await _jobPostRepository.GetActiveJobPostsAsync();

            return Ok(activeJobPosts);
        }

        // POST /api/jobposts
        [HttpPost]
        public async Task<ActionResult<JobPostResponse>> CreateJobPostAsync(CreateJobPostRequest request)
        {
            JobPost jobPost = _mapper.Map<CreateJobPostRequest, JobPost>(request);

            await _jobPostRepository.AddJobPostAsync(jobPost);

            return Ok(_mapper.Map<JobPost, JobPostResponse>(jobPost));
        }

        // GET /api/jobposts/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<JobPostResponse>> GetJobPostDetailsAsync(int id)
        {
            var jobPost = _mapper.Map<JobPost, JobPostResponse>(await _jobPostRepository.GetJobPostByIdAsync(id));

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
        public async Task<ActionResult<JobPostResponse>> UpdateJobPostAsync(int id, UpdateJobPostRequest request)
        {
            JobPost jobPost = _mapper.Map<UpdateJobPostRequest, JobPost>(request);

            await _jobPostRepository.UpdateJobPostAsync(id, jobPost);

            return Ok(_mapper.Map<JobPost, JobPostResponse>(jobPost));
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
