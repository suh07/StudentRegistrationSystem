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
                ValidatedUser = BCrypt.Net.BCrypt.Verify(model.UserPassword, validateUser.UserPassword);
            }
            return ValidatedUser;
        }

        public bool AddUser(User user)
        {
            bool isUserExist = _ManageUserDAL.CheckExistedUser(user.EmailAddress);
            if(!isUserExist)
            {
                _ManageUserDAL.AddUserDB(user);
                return true;
            }
            return false; ;
        }


            /*
            public bool AddUser(User User)
            {
                var isAddeded = false;
                if (IsNIDUnique(User.Student.NationalId))
                {
                    User.UserPassword = BCrypt.Net.BCrypt.HashPassword(User.UserPassword);
                    isAddeded = _ManageUserDAL.AddUser(User);
                }
                return isAddeded;
            }
            private bool IsNIDUnique(string NationalId)
            {
                var user = this._ManageUserDAL.GetAllUser().FirstOrDefault(u => u.Student.NationalId.Equals(NationalId));
                if (user == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            */
        }
}