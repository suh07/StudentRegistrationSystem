using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.BusinessLogic
{
    public interface IManageUser
    {
        User Authenticate(LoginModel model);
        bool AddUser(User User);
    }
}
