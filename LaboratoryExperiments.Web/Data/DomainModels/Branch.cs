namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Branch
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int MyProperty { get; set; }
        public ICollection<Station> Stations { get; set; } = new List<Station>();
    }
}
