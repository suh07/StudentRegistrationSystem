using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.DataAccessLayer
{
    public interface IManageUserDAL
    {
        User GetUserByEmail(string email);
    }
}