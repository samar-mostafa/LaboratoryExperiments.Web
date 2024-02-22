using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    [Index(nameof(Name),IsUnique =true)]
    public class Branch
    {
        public int Id { get; set; }
        public string  Name { get; set; }
       
        public ICollection<Station> Stations { get; set; } = new List<Station>();
    }
}
