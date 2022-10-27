using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentRegistrationSystem.DataAccessLayer;
using StudentRegistrationSystem.Entities;

namespace StudentRegistrationSystem.BusinessLogic
{
    public class ManageStudent : IManageStudent
    {

        private readonly IUserDAL _manageUser;
        private LoginModel _loginModel;

        public ManageStudent(IUserDAL userDAL)
        {
            this._manageUser = userDAL;
        }

        public bool CreateStudent(User user)
        {
            var isCreated = false;
        
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;
                isCreated = this._manageUser.CreateStudent(user);
            

            return isCreated;
        }

        public bool CreateStudent(Student Student, LoginModel loginMode)
        {
            throw new NotImplementedException();
        }



    }
}