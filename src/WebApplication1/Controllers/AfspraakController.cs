using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapplicatie.Controllers
{
    public class AfspraakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Datum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Datum()
        {
            return View();
        }

        public IActionResult Tijd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Tijd()
        {
            return View();
        }

        public IActionResult Gegevens()
        {
            return View();
        }

        public IActionResult Controleer()
        {

        }
    }
}
