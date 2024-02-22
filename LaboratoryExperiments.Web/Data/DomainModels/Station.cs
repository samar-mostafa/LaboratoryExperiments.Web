
using Microsoft.EntityFrameworkCore;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStages { get; set; }
        public int ProcessingTypeId { get; set; }
        public int BranchId { get; set; }
        public int SanitaryDrainId { get; set; }
        public int ProcessingSystemId { get; set; }       
        public float DesignEnergy { get; set; }
        public int StationStatusId { get; set; }
        public ProcessingType ProcessingType  { get; set; }
        public StationStatus StationStatus { get; set; }
        public Branch Branch { get; set; }
        public SanitaryDrain SanitaryDrain { get; set; }
        public ProcessingSystem ProcessingSystem { get; set; }

    }
}

