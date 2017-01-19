using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class YourCustomAuthorize : AuthorizeAttribute
    {
        
    }
    [Authorize]
    public class BeheerController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }

}
