using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentRegistrationSystem.Entities;
using StudentRegistrationSystem.Models.Entities;
using StudentRegistrationSystem.BusinessLogic;

namespace StudentRegistrationSystem.Controllers
{
    public class LoginsController : Controller
    {
        private readonly IManageUser _manageUser;
        public LoginsController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        // GET: Logins
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Auth(LoginModel model)
        {


            var isValid = false;
            var url = "/HomePage/Home";

            isValid = _manageUser.Authenticate(model);

            return Json(new { result = isValid, url = url });
        }
    }
}