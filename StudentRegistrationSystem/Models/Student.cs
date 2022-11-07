using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace StudentRegistrationSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string StudentAddress { get; set; }
        public string GuardianName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StudentStatus { get; set; }
        public List<Subject> subjects { get; set; }
        public List<Result> result { get; set; }
        public int TotalPoints { get; set; }
        public Student()
        {
            result = new List<Result>();
        }
    }

    public class ResultModel
    {
        public Result[] Results { get; set; }
    }
}