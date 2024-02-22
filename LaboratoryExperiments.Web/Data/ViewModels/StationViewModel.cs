

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class StationViewModel
    {
          public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStages { get; set; }
        public string ProcessingType { get; set; }
        public string Branch { get; set; }
        public string SanitaryDrain { get; set; }
        public string ProcessingSystem { get; set; }
        public float DesignEnergy { get; set; }
        public string StationStatus { get; set; }
    }
}
