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
    
    public partial class Quiz
    {
        public Quiz()
        {
            this.Quiz_Students = new HashSet<Quiz_Students>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public System.DateTime date { get; set; }
        public int subjectId { get; set; }
    
        public virtual ICollection<Quiz_Students> Quiz_Students { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
