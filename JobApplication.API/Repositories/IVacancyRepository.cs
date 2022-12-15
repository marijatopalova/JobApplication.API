using JobApplication.API.Models;

namespace JobApplication.API.Repositories
{
    public interface IVacancyRepository
    {
        List<Vacancy> GetAll();
        Vacancy GetVacancyById(int id);
        void AddVacancy(Vacancy vacancy);
        void UpdateVacancy(int id, Vacancy vacancy);
        void DeleteVacancy(int id);
        void SaveChanges();
    }
}
