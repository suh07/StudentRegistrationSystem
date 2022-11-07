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
        private readonly IManageStudent _manageStudent;
        public ApplicationController(IManageStudent manageStudent)
        {
            _manageStudent = manageStudent;
        }
        public ActionResult ApplicationIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddStudentResult(ResultModel result)
        {
            var response = _manageStudent.AddStudentResult(new List<Result>(result.Results), (int)Session["userId"]);
            return Json(new { result = response, url = "/HomePage/HomePageIndex" });
        }
    }
}