using StudentRegistrationSystem.BusinessLogic;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class AdminController : Controller
    {

        private readonly IManageStudent _manageStudent;
        public AdminController(IManageStudent manageStudent)
        {
            _manageStudent = manageStudent;
        }
        // GET: Admin
        public ActionResult AdminIndex()
        {
            return View();
        }
        /*
        [HttpPost]
        public JsonResult Auth(LoginModel model)
        {
           User user = _manageStudent.GetStudentResult(model);

           Session["userId"] = user.UserId;
            return Json(new { result = true, url = "/Login/LoginIndex" });


        }
        */
    }
}