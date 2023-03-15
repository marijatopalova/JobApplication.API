using JobApplication.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<JobApplicant> JobApplicants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Industry>().HasData(
                new Industry
                {
                    Id = 1,
                    Name = "Information Technology and Services"
                },
                new Industry
                {
                    Id = 2,
                    Name = "Hospital & Health Care"
                }, 
                new Industry
                {
                    Id = 3,
                    Name = "Construction"
                }, 
                new Industry
                {
                    Id = 4,
                    Name = "Retail"
                }, 
                new Industry
                {
                    Id = 5,
                    Name = "Education Management"
                },
                new Industry
                {
                    Id = 6,
                    Name = "Financial Services"
                },
                new Industry
                {
                    Id = 7,
                    Name = "Computer Software"
                },
                new Industry
                {
                    Id = 8,
                    Name = "Higher Education"
                },
                new Industry
                {
                    Id = 9,
                    Name = "Automotive"
                });
        }
    }
}
