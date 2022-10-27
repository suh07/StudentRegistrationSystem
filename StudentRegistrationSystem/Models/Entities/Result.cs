using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Entities
{
    public class Result
    {
        public int ResultId { get; set; }

        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        public string Grade { get; set; }
    }
}