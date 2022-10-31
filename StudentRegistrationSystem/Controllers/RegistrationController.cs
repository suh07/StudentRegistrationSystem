﻿using StudentRegistrationSystem.BusinessLogic;
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
        private readonly IManageUser _ManageUser;
        public RegistrationController(IManageUser manageUser)
        {
            _ManageUser = manageUser;
        }
        public ActionResult RegistrationIndex()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddUser(User User)
        {
            //var response = _ManageUser.AddUser(User);

            bool isUserAdded = _ManageUser.AddUser(User);
            return Json(new { result = isUserAdded, url = Url.Action("LoginIndex","User") });
        }
    }
}