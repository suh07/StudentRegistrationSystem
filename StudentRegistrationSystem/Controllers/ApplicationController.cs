using StudentRegistrationSystem.BusinessLogic;
using StudentRegistrationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static StudentRegistrationSystem.Models.Student;

namespace StudentRegistrationSystem.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IManageStudent _ManageStudent;
        public ApplicationController(IManageStudent manageStudent)
        {
            _ManageStudent = manageStudent;
        }
        public ActionResult ApplicationIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddStudentResult(resultModel result)
        {
            var Response = _ManageStudent.AddStudentResult(result.result, (int)Session["userId"]);
            return Json(new { result = Response });
        }
    }
}