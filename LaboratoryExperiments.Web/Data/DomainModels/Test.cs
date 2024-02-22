namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Test
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public int ExperimentId { get; set; }
        public bool In_Eff { get; set; }
        public bool Result { get; set; }
        public float EnteredValue { get; set; }
        public Station Station { get; set; }
        public Experiment  Experiment { get; set; }
    }
}
