using StudentRegistrationSystem.BusinessLogic;
using StudentRegistrationSystem.DataAccessLayer;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IManageUser _manageUser;
        public RegistrationController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        public ActionResult RegistrationIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddUser(User User)
        {
            bool userAdded = _manageUser.AddUser(User);
            return Json(new { result = userAdded, url = Url.Action("LoginIndex", "Login") });
        }
    }
}