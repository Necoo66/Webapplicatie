using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class BruidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailPagina(int id)
        {

            return View();
        }
    }
}