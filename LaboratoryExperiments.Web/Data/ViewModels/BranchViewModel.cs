namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IdNameViewModel> Stations { get; set; }
    }
}

public class IdNameViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}