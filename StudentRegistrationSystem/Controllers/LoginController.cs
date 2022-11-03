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
            User user = _ManageUser.Authenticate(model);

            if (user == null)
            {
                return Json(new { result = false });
            }

          //  Session["userId"] = user.UserId;

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
            return Json(new { result = true, url = "/Login/LoginIndex" });


        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["userId"] = null;

            return RedirectToAction("LoginIndex");
        }
    }
}