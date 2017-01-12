using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using HoneymoonShop.Models.Bruid;
using Microsoft.EntityFrameworkCore;

namespace HoneymoonShop.Controllers
{
    public class BruidController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BruidController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorie()
        {
            var trouwjurk = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();
            return View(trouwjurk);
        }


        public async Task<IActionResult> Product(int? id)
        {
             if (id == null)
             {
                 return NotFound();
             }

             var trouwjurk = await _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).Include(x => x.Categorie).SingleOrDefaultAsync(t => t.Id == id);
            
             if (trouwjurk == null)
             {
                 return NotFound();
             }

            return View(trouwjurk);
        }
    }
}