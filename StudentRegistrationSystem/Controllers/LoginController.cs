using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Models;
using StudentRegistrationSystem.BusinessLogic;

namespace StudentRegistrationSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IManageUser _ManageUser;
        public LoginController(IManageUser manageUser)
        {
            _ManageUser = manageUser;
        }
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Auth(LoginModel model)
        {
            var IsAuthenticationValid = false;
            IsAuthenticationValid = _ManageUser.Authenticate(model);
            return Json(new { result = IsAuthenticationValid, url = "/HomePage/HomePageIndex" });
        }
    }
}