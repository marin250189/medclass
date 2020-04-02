using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDCLASS.Models
{
    public class SubjectViewModel
    {
        [Required]
        [Display(Name = "Nombre de Asignatura")]
        public string Name { get; set; }
        [Required]
        public int Year { get; set; }
    }
}