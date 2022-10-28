using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.DataAccessLayer;

namespace StudentRegistrationSystem.BusinessLogic
{
    public class ManageUser : IManageUser
    {
        private readonly IManageUserDAL _ManageUserDAL;

        public ManageUser(IManageUserDAL ManageUserDAL)
        {
            _ManageUserDAL = ManageUserDAL;
        }
        public bool Authenticate(LoginModel model)
        {
            bool ValidatedUser = false;
            User validateUser = _ManageUserDAL.GetUserByEmail(model.EmailAddress);
            if (validateUser != null)
            {
                ValidatedUser = BCrypt.Net.BCrypt.Verify(model.Password, validateUser.Password);
            }
            return ValidatedUser;
        }
    }
}