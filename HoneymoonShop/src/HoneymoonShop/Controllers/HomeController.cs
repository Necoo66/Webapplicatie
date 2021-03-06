﻿using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Bruid()
        {
            return View();
        }

        public IActionResult Bruidegom()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
