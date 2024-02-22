using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class CreateProcessingSystemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "this field is required!")]
        [MinLength(2, ErrorMessage = "you must enter more than 1 character!")]
        [Remote("AllowItem", null, ErrorMessage = "this name is allready exist!")]
        public string Name { get; set; }
    }
}
