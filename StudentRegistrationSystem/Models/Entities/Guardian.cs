using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationSystem.Models.Entities
{
    public class Guardian
    {
        public int guardianId { get; set; }
        public string firstName { get; set; }
        public string lastName{get; set; } 
    }
}