using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using StudentRegistrationSystem.BusinessLogic;
using StudentRegistrationSystem.DataAccessLayer;

namespace StudentRegistrationSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IManageUser, ManageUser>();
            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<IManageStudent, ManageStudent>();
            container.RegisterType<IConnectDatabase, ConnectDatabase>();
            container.RegisterType<IStudentDAL, StudentDAL>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}