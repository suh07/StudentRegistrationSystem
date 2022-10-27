using StudentRegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.DataAccessLayer;

namespace StudentRegistrationSystem.BusinessLogic
{
    public class ManageUser : IManageUser
    {
        private readonly IUserDAL _userDAL;

        public ManageUser(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool Authenticate(LoginModel model)
        {
            bool isUserValid = false;
            User validUser = _userDAL.GetUserByEmail(model.EmailAddress);

            if (validUser != null)
            {
                isUserValid=BCrypt.Net.BCrypt.Verify(model.Password, validUser.Password);
            }

            return isUserValid;

        }
    }
}