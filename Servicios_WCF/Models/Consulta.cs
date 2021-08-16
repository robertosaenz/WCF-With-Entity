//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Servicios_WCF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Consulta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Consulta()
        {
            this.ConsultaMedicamentoes = new HashSet<ConsultaMedicamento>();
        }
    
        public int IIDCONSULTA { get; set; }
        public Nullable<int> IIDPACIENTE { get; set; }
        public Nullable<decimal> PESO { get; set; }
        public Nullable<decimal> ESTATURA { get; set; }
        public string EXAMENFISICO { get; set; }
        public string EXAMENLABORATORIO { get; set; }
        public string DIAGNOSTICO { get; set; }
        public Nullable<System.DateTime> FECHACITA { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual Paciente Paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConsultaMedicamento> ConsultaMedicamentoes { get; set; }
    }
}
