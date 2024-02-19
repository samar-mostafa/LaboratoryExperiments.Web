namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Test
    {
        public int Id { get; set; }
        public int StationId { get; set; }
        public int InffleuntExperimentId { get; set; }
        public int EffleuntExperimentId { get; set; }
        public bool Result { get; set; }
        public float EnteredValue { get; set; }
        public Station Station { get; set; }
        public InffleuntExperiment InffleuntExperiment { get; set; }
        public EffleuntExperiment EffleuntExperiment { get; set; }
    }
}
