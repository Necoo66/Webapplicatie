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
            var filter = new Filter();
            var trouwjurk = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).Take(6).ToList();


            var productFilter = new ProductFilter()
            {
                Filter = filter,
                Producten = trouwjurk
            };


            return View(productFilter);
        }

        public IActionResult Categorie()
        {
            var filter = new Filter()
            {
                Merken = _context.Merk.ToList(),
                Categorieën = _context.Categorie.ToList(),
                Stijlen = _context.Kenmerk.Where(x => x.Type.Equals("Stijl")).ToList(),
                KenmerkNamen = _context.Kenmerk.Where(x => !x.Type.Equals("Stijl")).Select(x => x.Type).Distinct().ToList(),
                Kenmerken = _context.Kenmerk.ToList()
            };

            var filterOpties = new FilterSelectie();
            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();


            return View(filter);
        }

        [HttpPost]
        public IActionResult Categorie(FilterSelectie filter)
        {
            //ViewBag.CategorieLijst = _context.Categorie.ToList();
            //ViewBag.Merklijst = _context.Merk;
            //ViewBag.StijlLijst = _context.Kenmerk.Where(x => x.Type.Equals("Stijl"));
            //ViewBag.NeklijnLijst = _context.Kenmerk.Where(x => x.Type.Equals("Neklijn"));
            //ViewBag.SilhouetteLijst = _context.Kenmerk.Where(x => x.Type.Equals("Silhouette"));
            //ViewBag.KleurLijst = _context.Kenmerk.Where(x => x.Type.Equals("Kleur"));

            //var producten = productFilter.Producten;
            ////var ProductXKenmerk = _context.Product_X_Kenmerk.Select(x=>x.ProductId).ToList();
            //producten = producten.Where(x => x.Prijs > productFilter.FilterOpties.MinPrijs && x.Prijs > productFilter.FilterOpties.MaxPrijs).ToList();


            //if (productFilter.FilterOpties.Categorie != null)
            //{
            //    producten = producten.Where(x => x.Categorie.Id == productFilter.FilterOpties.Categorie.Id).ToList();
            //}

            //if (productFilter.FilterOpties.Merk != null)
            //{
            //    var merken = new List<Product>();
            //    foreach (var m in productFilter.FilterOpties.Merk)
            //    {
            //        merken = merken.Union(producten.Where(x => x.Merk.Id == m.Id).ToList()).ToList();
            //    }
            //    producten = merken;
            //}

            //if (productFilter.FilterOpties.Kenmerken != null)
            //{
            //    producten = producten.FindAll(x => x.Product_X_Kenmerk.Any(y => productFilter.FilterOpties.Kenmerken.Contains(y.Kenmerk)));
            //}

            return View(filter);
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