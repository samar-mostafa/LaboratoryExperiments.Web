namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class SanitaryDrain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Station> Stations { get; set; } = new List<Station>();
    }
}
