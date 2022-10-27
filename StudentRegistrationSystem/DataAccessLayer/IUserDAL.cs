using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.Entities;
using StudentRegistrationSystem.Models.Entities;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public interface IUserDAL
    {
        User GetUserByEmail(string email);
        bool CreateStudent(User user);
    }
}