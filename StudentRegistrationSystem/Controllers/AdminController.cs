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
        private readonly IAdminAccess _adminAccess;
        public AdminController(IAdminAccess adminaccess)
        {
            _adminAccess = adminaccess;
        }
        public ActionResult AdminIndex()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetStudentInfo()
        {
            var response = _adminAccess.GetTopFifteenStudent();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}