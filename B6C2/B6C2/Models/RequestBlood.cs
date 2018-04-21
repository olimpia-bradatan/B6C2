using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public partial class RequestBlood
    {
        
        public int idHospital { get; set; }

        [Required]
        [Display(Name = "Blood quantity ")]

        public int quantity { get; set; }
        [Required]
        public  int idBlood { get; set; }

        [Required]
        [Display(Name = "Patient first name ")]
        public string firstName { get; set; }


        [Required]
        [Display(Name = "Last name patient")]
        public string lastName { get; set; }
      

       
    }
}