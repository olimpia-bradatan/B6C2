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

    public partial class centerEmployee
    {
      
        [Display(Name = "Employee id")]
        public int idEmployee { get; set; }

        [Display(Name = "Centre id")]
        public Nullable<int> idCenter { get; set; }
      
        [Display(Name = "First name*")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last name*")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
    
        public virtual donationCenter donationCenter { get; set; }
    }
}
