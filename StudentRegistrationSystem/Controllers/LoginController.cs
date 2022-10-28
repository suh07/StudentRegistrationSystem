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
        private readonly IManageUser _manageUser;
        public LoginController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Auth(LoginModel model)
        {
            var IsAuthenticationValid = false;
            IsAuthenticationValid = _manageUser.Authenticate(model);
            return Json(new { result = IsAuthenticationValid, url = "/HomePage/HomePageIndex" });
        }
    }
}