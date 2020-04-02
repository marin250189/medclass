using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEDCLASS.Models
{
    public class StudentViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string firstName { get; set; }
        [Required]  
        public string lastName { get; set; }
        public string gender { get; set; }
        public Nullable<int> age { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "El número de caracteres de {0} debe ser de  10.")]
        [Display(Name = "Número de Teléfono")]
        public string phoneNumber { get; set; }
    }
}