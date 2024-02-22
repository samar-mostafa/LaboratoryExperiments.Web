using LaboratoryExperiments.Web.Data.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        public DbSet<StationStatus> StationStatuses { get; set; }
        public DbSet<ExperimentType> ExperimentTypes { get; set; }
        public DbSet<SanitaryDrain> SanitaryDrain { get; set; }
        public DbSet<ProcessingType> ProcessingTypes { get; set; }

        public DbSet<Test> Tests { get; set; }

    }
}
