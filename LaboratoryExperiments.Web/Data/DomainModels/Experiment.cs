namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
