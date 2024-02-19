namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class InffleuntExperiment
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }
    }
}
