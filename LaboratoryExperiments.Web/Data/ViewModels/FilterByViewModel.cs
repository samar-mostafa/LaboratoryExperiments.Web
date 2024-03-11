using System.ComponentModel.DataAnnotations;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class FilterByViewModel
    {
        [Display(Name ="Branch")]
        public int? BranchId { get; set; }
        [Display(Name = "Station")]
        public int? StationId { get; set; }
        public DateTime? Date { get; set; }
      
        [Display(Name = "Experiment")]
        public int? ExperimentId { get; set; }
        [Display(Name = "ExperimentType")]
        public int? ExperimentTypeId { get; set; }
      
    }

    
}
