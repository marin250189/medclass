//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quiz_Students
    {
        public int quizId { get; set; }
        public int studentId { get; set; }
        public int grade { get; set; }
    
        public virtual Quiz Quiz { get; set; }
        public virtual Students Students { get; set; }
    }
}
