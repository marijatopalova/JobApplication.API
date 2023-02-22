using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JobApplyController : Controller
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;

        public JobApplyController(IJobApplicationRepository jobApplicationRepository)
        {
            this._jobApplicationRepository = jobApplicationRepository;
        }

        [HttpPost]
        [ActionName("JobApply")]
        public async Task<IActionResult> JobApply([FromQuery]int id, Candidate candidate)
        {
            await _jobApplicationRepository.ApplyForJob(id, candidate);

            return Ok();
        }

        [HttpGet]
        [ActionName("GetAllCandidatesPerVacancy")]
        public async Task<IActionResult> GetAllCandidatesPerVacancy(int vacancyId)
        {
            return Ok(await _jobApplicationRepository.GetCandidatesByVacancyId(vacancyId));
        }

        [HttpGet]
        [ActionName("GetAllVacanciesPerUser")]
        public async Task<IActionResult> GetAllVacanciesPerUser(int userId)
        {
            return Ok(await _jobApplicationRepository.GetVacanciesByUserId(userId));
        }
    }
}
