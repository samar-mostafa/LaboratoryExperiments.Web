namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Test
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public int ExperimentId { get; set; }
        public bool In_Eff { get; set; } //0 for in //1 for eff
        public bool Result { get; set; } 
        public float EnteredValue { get; set; }
        public DateTime Date { get; set; }
        public Station Station { get; set; }
        public Experiment  Experiment { get; set; }
    }
}
