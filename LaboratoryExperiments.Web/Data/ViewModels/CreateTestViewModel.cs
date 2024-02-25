using System.ComponentModel.DataAnnotations;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class CreateTestViewModel
    {
        [Display(Name = "Station")]
        public int StationId { get; set; }
        [Display(Name = "Experiment")]
        public int ExperimentId { get; set; }
        [Display(Name = "Inffleunt/Effleunt")]
        public bool In_Eff { get; set; } //0 for in //1 for eff

        [Display(Name = "Value")]
        public float EnteredValue { get; set; }
        public DateTime Date { get; set; }
        public bool Result { get; set; }
    }
}
