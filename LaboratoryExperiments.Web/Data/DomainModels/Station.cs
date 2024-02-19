using LaboratoryExperiments.Web.Data.Const;

namespace LaboratoryExperiments.Web.Data.DomainModels
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfStages { get; set; }
        public int ProcessingType { get; set; }
        public int BranchId { get; set; }
        public int ProcessingSystemId { get; set; }       
        public float DesignEnergy { get; set; }
        public bool Status { get; set; }
        public Branch Branch { get; set; }
        public ProcessingSystem ProcessingSystem { get; set; }

    }
}

