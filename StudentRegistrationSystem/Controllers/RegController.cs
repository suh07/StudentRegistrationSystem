using StudentRegistrationSystem.BusinessLogic;
using StudentRegistrationSystem.DataAccessLayer;
using StudentRegistrationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class RegController : Controller
    {

        // GET: Reg
        public ActionResult RegIndex()
        {
            return View();
        }

    }
}