using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistrationSystem.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please enter your email address! ")]
        [Display(Name = "Enter email address : ")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Please enter your password! ")]
        [Display(Name = "Enter password : ")]
        public string Password {get; set;}
    }
}