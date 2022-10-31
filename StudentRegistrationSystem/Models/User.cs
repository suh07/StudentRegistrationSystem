using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string EmailAddress { get; set; }
        public string UserPassword { get; set; }
        public Student Student { get; set; }
    }

    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string UserPassword { get; set; }
    }
}