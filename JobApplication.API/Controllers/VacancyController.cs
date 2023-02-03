using JobApplication.API.Models;
using JobApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JobApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyController : Controller
    {
        private readonly IVacancyRepository vacancyRepository;

        public VacancyController(IVacancyRepository vacancyRepository)
        {
            this.vacancyRepository = vacancyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetVacanciesAsync()
        {
            return Ok(await vacancyRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacancyAsync(Vacancy vacancy)
        {
            await vacancyRepository.AddVacancyAsync(vacancy);
            return Ok(vacancy);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVacancyAsync(int id)
        {
            await vacancyRepository.DeleteVacancyAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVacancyAsync(int id, Vacancy vacancy)
        {
            await vacancyRepository.UpdateVacancyAsync(id, vacancy);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> CloseJobPostAsync(int id)
        {
            await vacancyRepository.CloseJobPostAsync(id);
            return Ok();
        }
    }
}
