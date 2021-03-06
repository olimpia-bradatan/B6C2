//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace B6C2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Medic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medic()
        {
            this.Patients = new HashSet<Patient>();
        }
        [Display(Name = "Medic id")]
       
        public int idMedic { get; set; }
        [Display(Name = "First name*")]
        [Required]
        public string firstName { get; set; }
        [Display(Name = "Last name*")]
        [Required]
        public string lastName { get; set; }
        [Display(Name = "Hospital id")]
        
        public Nullable<int> idHospital { get; set; }
        [Display(Name = "Email*")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    
        public virtual Hospital Hospital { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
