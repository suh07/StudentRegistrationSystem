using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class User
    {
        public int UserId { get; private set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public Student Student { get; set; }
        public User(int userId)
        {
            UserId = userId;
        }
    }
    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

}