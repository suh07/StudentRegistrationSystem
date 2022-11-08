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
            User user = _manageUser.Authenticate(model);
            if (user == null)
            {
                return Json(new { result = false });
            }
            if (user.RoleId == "2")
            {
                Session["userId"] = user.UserId;
                return Json(new { result = true, url = "/HomePage/HomePageIndex" });
            }
            if (user.RoleId == "1")
            {
                Session["userId"] = user.UserId;
                return Json(new { result = true, url = "/Admin/AdminIndex" });
            }
            Session["userId"] = user.UserId;
            return Json(new { result = true, url = "/Registration/RegistrationIndex" });
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session["userId"] = null;
            return RedirectToAction("LoginIndex");
        }
    }
}