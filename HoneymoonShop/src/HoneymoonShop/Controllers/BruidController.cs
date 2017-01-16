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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Categorie(FilterOpties filter)
        {


            //ViewBag.CategorieLijst = _context.Categorie.ToList();
            //ViewBag.Merklijst = _context.Merk;
            //ViewBag.StijlLijst = _context.Kenmerk.Where(x => x.Type.Equals("Stijl"));
            //ViewBag.NeklijnLijst = _context.Kenmerk.Where(x => x.Type.Equals("Neklijn"));
            //ViewBag.SilhouetteLijst = _context.Kenmerk.Where(x => x.Type.Equals("Silhouette"));
            //ViewBag.KleurLijst = _context.Kenmerk.Where(x => x.Type.Equals("Kleur"));

            var trouwjurk = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();
            //var ProductXKenmerk = _context.Product_X_Kenmerk.Select(x=>x.ProductId).ToList();
            trouwjurk = trouwjurk.Where(x => x.Prijs > filter.MinPrijs && x.Prijs > filter.MaxPrijs).ToList();


            if (filter.Categorie != null)
            {
                trouwjurk = trouwjurk.Where(x => x.Categorie.Id == filter.Categorie.Id).ToList();
            }

            if (filter.Merk != null)
            {
                var merken = new List<Product>();
                foreach (var m in filter.Merk)
                {
                    merken = merken.Union(trouwjurk.Where(x => x.Merk.Id == m.Id).ToList()).ToList();
                }
                trouwjurk = merken;
            }

            if (filter.Kenmerken != null)
            {
                trouwjurk = trouwjurk.FindAll(x => x.Product_X_Kenmerk.Any(y => filter.Kenmerken.Contains(y.Kenmerk)));
            }

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