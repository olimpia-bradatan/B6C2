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

    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            this.donorTransactions = new HashSet<donorTransaction>();
            this.Transactions = new HashSet<Transaction>();
        }
        [Display(Name = "Patient id")]
        public int idPatient { get; set; }
        [Display(Name = "First name*")]
        [Required]
        public string firstName { get; set; }
        [Display(Name = "Last name*")]
        [Required]
        public string lastName { get; set; }
        [Display(Name = "Blood type")]
       
        public string group { get; set; }
        [Display(Name = "RH")]
      
        public string RH { get; set; }
        [Display(Name = "Medic id")]
    
        public Nullable<int> idMedic { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donorTransaction> donorTransactions { get; set; }
        public virtual Medic Medic { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
