using LaboratoryExperiments.Web.Data.DomainModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class CreateExperimentViewModel
    {
        public int Id { get; set; }
        [Required] 
        [MinLength(2, ErrorMessage = "you must enter more than 1 character!")]
        [Remote("AllowItem", null, ErrorMessage = "this name is allready exist!")]
        public string Name { get; set; }
        [Display(Name = "unit")]
        public int? UnitId { get; set; }
        [Display(Name = "Inffleunt Value")]
        public float? InffleuntValue { get; set; }

        [Display(Name = "Effleunt Value")]
        public float? EffleuntValue { get; set; }
        [Display(Name = "Experiment Type")]
        public int ExperimentTypeId { get; set; }
    }
}
