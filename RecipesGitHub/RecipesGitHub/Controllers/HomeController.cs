﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipesGitHub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeeRecipe()
        {
            return View();
        }

        public ActionResult CreateRecipe()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
    }
}