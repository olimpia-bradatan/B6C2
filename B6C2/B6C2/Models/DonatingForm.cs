using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class DonatingForm
    {
        [Display(Name = "Center")]
        public int idCenter { get; set; }

        [Display(Name = "First Name")]
        public String firstName { get; set; }

        [Display(Name = "Last Name")]
        public String lastName { get; set; }

        [Display(Name = "CNP")]
        public String cnp { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime birthDate { get; set; }

        [Display(Name = "Address from the Identity Card")]
        public String address { get; set; }

        [Display(Name = "City")]
        public String city { get; set; }

        [Display(Name = "County")]
        public String county{ get; set; }

        [Display(Name = "Address (if it is different than the one from the Identity Card")]
        public String actualAddress { get; set; }

        [Display(Name = "Phone number")]
        public String phoneNumber { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String email { get; set; }

        [Display(Name = "Age")]
        public int age { get; set;  }

        [Display(Name = "Weight")]
        public int weight { get; set; }

        [Display(Name = "Pulse")]
        public int pulse { get; set; }

        [Display(Name = "If woman, are you pregnant, after pregnancy or on period?")]
        public Boolean womanProblems { get; set; }
         
        [Display(Name = "Have you drunk in the last 24 hours?")]
        public Boolean drink { get; set; }

        [Display(Name = "Have you had any surgical intervention in the last 6 months?")]
        public Boolean intervention { get; set; }

        [Display(Name = "Did you have any of the following affections:  hepatitis, TBC, syphilis, cancer?")]
        public Boolean affections { get; set; }


    }
}