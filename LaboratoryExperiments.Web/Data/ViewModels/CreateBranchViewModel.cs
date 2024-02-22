using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaboratoryExperiments.Web.Data.ViewModels
{
    public class CreateBranchViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="this field is required!")]
        [MinLength(2,ErrorMessage ="you must enter more than 1 character!")]
        [Remote("AllowItem", null, ErrorMessage = "this name is allready exist!")]
        public string Name { get; set; }
    }
}
