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
    public class JobApplyController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IMapper _mapper;

        public JobApplyController(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            this._jobApplicationRepository = jobApplicationRepository;
            this._mapper = mapper;
        }

        // POST /api/jobapply/1
        [HttpPost("{id:int}")]
        public async Task<IActionResult> JobApply(int id, CreateCandidateRequest request)
        {
            var candidate = _mapper.Map<CreateCandidateRequest, Candidate>(request);

            await _jobApplicationRepository.ApplyForJob(id, candidate);

            return Ok();
        }

        // GET /api/jobapply/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<CandidateResponse>>> GetAllCandidatesPerJobPost(int id)
        {
            var result = await _jobApplicationRepository.GetCandidatesByJobPostId(id);

            var candidates = _mapper.Map<List<Candidate>, List<CandidateResponse>>(result);

            return Ok(candidates);
        }
    }
}
