using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
