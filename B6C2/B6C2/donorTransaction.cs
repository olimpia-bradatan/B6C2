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
    
    public partial class donorTransaction
    {
        public int id { get; set; }
        public string cnpDonor { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> donationDate { get; set; }
        public string analysisStatus { get; set; }
        public Nullable<int> idPatient { get; set; }
        public Nullable<int> idCenter { get; set; }
    
        public virtual donationCenter donationCenter { get; set; }
        public virtual Donor Donor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
