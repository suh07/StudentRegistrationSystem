using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.DataAccessLayer;

namespace StudentRegistrationSystem.BusinessLogic
{
    public class ManageUser : IManageUser
    {
        private readonly IManageUserDAL _manageUserDAL;

        public ManageUser(IManageUserDAL managerUserDAL)
        {
            _manageUserDAL = managerUserDAL;
        }
        public User Authenticate(LoginModel model)
        {
            User user = _manageUserDAL.GetUserByEmail(model.EmailAddress);

            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(model.UserPassword, user.UserPassword))
            {
                return null;
            }

            return user;
        }
        public bool AddUser(User user)
        {
            bool userExists = _manageUserDAL.CheckExistedUser(user);
            if (!userExists)
            {
                _manageUserDAL.AddUserDB(user);
                return true;
            }
            return false; ;
        }
    }
}