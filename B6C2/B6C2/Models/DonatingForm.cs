using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class DonatingForm
    {
        [Display(Name = "Center*")]
        [Required]
        public int idCenter { get; set; }

        [Required]
        [Display(Name = "First Name*")]
        public String firstName { get; set; }

        [Required]
        [Display(Name = "Last Name*")]
        public String lastName { get; set; }

        [Required]
        [Display(Name = "CNP*")]
        public String cnp { get; set; }

        [Required]
        [Display(Name = "Date of birth*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime birthDate { get; set; }

        [Required]
        [Display(Name = "Address from the Identity Card*")]
        public String address { get; set; }

        [Required]
        [Display(Name = "City*")]
        public String city { get; set; }

        [Required]
        [Display(Name = "County*")]
        public String county{ get; set; }

        [Required]
        [Display(Name = "Phone number*")]
        public String phoneNumber { get; set; }

        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public String email { get; set; }

        [Required]
        [Display(Name = "Age*")]
        [RegularExpression("^(?!0+$)[0-9]+$", ErrorMessage = "Quantity must be positive")]
        public int age { get; set;  }

        [Required]
        [Display(Name = "Weight*")]
        [RegularExpression("^(?!0+$)[0-9]+$", ErrorMessage = "Quantity must be positive")]
        public int weight { get; set; }

        [Required]
        [Display(Name = "Pulse*")]
        [RegularExpression("^(?!0+$)[0-9]+$", ErrorMessage = "Quantity must be positive")]
        public int pulse { get; set; }

        [Required]
        [Display(Name = "If woman, are you pregnant, after pregnancy or on period?*")]
        public Boolean womanProblems { get; set; }

        [Required]
        [Display(Name = "Have you drunk in the last 24 hours?*")]
        public Boolean drink { get; set; }

        [Required]
        [Display(Name = "Have you had any surgical intervention in the last 6 months?*")]
        public Boolean intervention { get; set; }

        [Required]
        [Display(Name = "Did you have any of the following affections:  hepatitis, TBC, syphilis, cancer?*")]
        public Boolean affections { get; set; }

        [Display(Name = "Patient first and last name, if you donate especially for him")]
        public String patientFullName { get; set; }

    }
}