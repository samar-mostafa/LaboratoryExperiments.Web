using LaboratoryExperiments.Web.Data.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Branch> Branches { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ProcessingSystem> ProcessingSystems { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<EffleuntExperiment> EffleuntExperiments { get; set; }
        public DbSet<InffleuntExperiment> InffleuntExperiments { get; set; }
        public DbSet<Test> Tests { get; set; }

    }
}
