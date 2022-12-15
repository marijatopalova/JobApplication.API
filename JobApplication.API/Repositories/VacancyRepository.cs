using JobApplication.API.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.API.Repositories
{
    public class VacancyRepository : IVacancyRepository
    {
        private readonly ApplicationDbContext context;

        public VacancyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddVacancy(Vacancy vacancy)
        {
            var vacancyToAdd = new Vacancy();
            vacancyToAdd.PositionName = vacancy.PositionName;
            vacancyToAdd.Description = vacancy.Description;
            vacancyToAdd.CompanyName = vacancy.CompanyName;
            vacancyToAdd.Location = vacancy.Location;
            vacancyToAdd.IsRemote = vacancy.IsRemote;
            vacancyToAdd.SeniorityLevel = vacancy.SeniorityLevel;
            vacancyToAdd.EmploymentType = vacancy.EmploymentType;
            vacancyToAdd.IndustryId = vacancy.IndustryId;

            context.Add(vacancyToAdd);
            SaveChanges();
        }

        public void DeleteVacancy(int id)
        {
            var vacancy = context.Vacancies.Where(v => v.Id == id).FirstOrDefault();

            if (vacancy != null)
                context.Vacancies.Remove(vacancy);
        }

        public List<Vacancy> GetAll()
        {
            return context.Vacancies.Include(v => v.Industry).ToList();
        }

        public Vacancy GetVacancyById(int id)
        {
            var vacancy = context.Vacancies.Where(v => v.Id == id).FirstOrDefault();

            if (vacancy == null) return null;

            return vacancy;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void UpdateVacancy(int id, Vacancy vacancy)
        {
            var vacancyToUpdate = context.Vacancies.Where(v => v.Id == id).FirstOrDefault();

            vacancyToUpdate.PositionName = vacancy.PositionName;
            vacancyToUpdate.Description = vacancy.Description;
            vacancyToUpdate.CompanyName = vacancy.CompanyName;
            vacancyToUpdate.Location = vacancy.Location;
            vacancyToUpdate.IsRemote = vacancy.IsRemote;
            vacancyToUpdate.SeniorityLevel = vacancy.SeniorityLevel;
            vacancyToUpdate.EmploymentType = vacancy.EmploymentType;
            vacancyToUpdate.Industry = vacancy.Industry;

            SaveChanges();
        }
    }
}
