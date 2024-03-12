using LaboratoryExperiments.Web.Data.DomainModels;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public string Branch { get; set; }
        public string SanitaryDrain { get; set; }
        public string Experiment { get; set; }
        public string ExperimentType { get; set; }
        public bool In_Eff { get; set; } //0 for in //1 for eff
        public bool Result { get; set; }
        public float? InffleuntValue { get; set; }
        public float? EffleuntValue { get; set; }
        public float? InffleuntValueTo { get; set; }
        public float? EffleuntValueTo { get; set; }
        public float EnteredValue { get; set; }
        public DateTime Date { get; set; }
       
    }

    public class FilteredTestViewModel:TestViewModel
    {
        public string In_EffWord { get; set; }
        public string ResultWord { get; set; }
        public string Datestring { get; set; }
        public string  ReferenceValue { get; set; }

    }

}
