using System.ComponentModel.DataAnnotations;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class CreateStationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Number Of Stages")]
        public int NumberOfStages { get; set; }
        [Display(Name = "Processing Type")]
        public int ProcessingTypeId { get; set; }

        [Display(Name = "Branch")]
        public int BranchId { get; set; }
        [Display(Name = "Sanitary Drain")]
        public int SanitaryDrainId { get; set; }
        [Display(Name = "Processing System")]
        public int ProcessingSystemId { get; set; }
        [Display(Name = "Design Energy")]
        public float DesignEnergy { get; set; }
        [Display(Name = "Status")]
        public int StationStatusId { get; set; }
    }
}
