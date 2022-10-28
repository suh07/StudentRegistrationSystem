using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult HomePageIndex()
        {
            return View();
        }
    }
}