using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProcessingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
