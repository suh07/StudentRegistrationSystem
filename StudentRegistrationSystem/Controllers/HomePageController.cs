﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRegistrationSystem.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Home()
        {
            return View();
        }
    }
}