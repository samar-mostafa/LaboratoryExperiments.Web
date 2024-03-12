using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Experiment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }
        public float? InffleuntValue { get; set; }
        public float? InffleuntValueTo { get; set; }
        public float? EffleuntValue { get; set; }
        public float? EffleuntValueTo { get; set; }
        public int ExperimentTypeId { get; set; }
        public ExperimentType ExperimentType { get; set; }
    }
}
