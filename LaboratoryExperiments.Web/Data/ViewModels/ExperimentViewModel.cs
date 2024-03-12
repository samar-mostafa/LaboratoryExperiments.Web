namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class ExperimentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public float? InffleuntValue { get; set; }
        public float? EffleuntValue { get; set; }
        public float? InffleuntValueTo { get; set; }
        public float? EffleuntValueTo { get; set; }
        public string ExperimentType { get; set; }
    }
}
