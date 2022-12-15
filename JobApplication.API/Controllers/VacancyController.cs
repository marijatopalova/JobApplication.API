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
        public IActionResult GetVacancies()
        {
            return Ok(vacancyRepository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateVacancy(Vacancy vacancy)
        {
            vacancyRepository.AddVacancy(vacancy);
            return Ok(vacancy);
        }
    }
}
