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
            //int ses = (int)Session["userId"];

           /*
           if (Session["userId"] == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
            }
            */
            return View();
        }
        [HttpPost]
        public JsonResult AddStudentResult(ResultModel result)
        {
            var response = _ManageStudent.AddStudentResult(new List<Result>(result.Results), (int)Session["userId"]);
            return Json(new { result = response });
        }
    }
}