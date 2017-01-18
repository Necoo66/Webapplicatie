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
        private readonly Filter _filter;

        public BruidController(ApplicationDbContext context)
        {
            _context = context;
            _filter = new Filter()
            {
                Merken = _context.Merk.ToList(),
                Categorieën = _context.Categorie.ToList(),
                Stijlen = _context.Kenmerk.Where(x => x.Type.Equals("Stijl")).ToList(),
                KenmerkNamen = _context.Kenmerk.Where(x => !x.Type.Equals("Stijl")).Select(x => x.Type).Distinct().ToList(),
                Kenmerken = _context.Kenmerk.ToList()
            };
        }

        public IActionResult Index(FilterSelectie filterSelectie)
        {
            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).Take(6).ToList();

            return View(new ProductFilter(_filter, filterSelectie, producten));
        }

        public IActionResult Categorie(FilterSelectie filterSelectie)
        {

            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();


            if (filterSelectie.Categorie != null && filterSelectie.Categorie != 0)
            {
                producten = producten.Where(x => x.Categorie.Id == filterSelectie.Categorie).ToList();
            }

            if (filterSelectie.MinPrijs != null && filterSelectie.MaxPrijs != null)
            {
                producten = producten.Where(x => x.Prijs >= filterSelectie.MinPrijs && x.Prijs <= filterSelectie.MaxPrijs).ToList();
            }

            if (filterSelectie.Merken.Count() != 0)
            {
                producten = producten.Where(x => filterSelectie.Merken.Contains(x.Merk.Id)).ToList();
            }

            /* niet af
            if (filterSelectie.Kenmerken != null)
            {
                producten = producten.FindAll(x => x.Product_X_Kenmerk.Any(y => filterSelectie.Kenmerken.Contains(y.KenmerkId)));
            }
            

            /*sorteren*/
            producten = sorteren(filterSelectie, producten);
            /*paginanummering*/
            
            paginanummering(filterSelectie, producten);

            var limitedProducts = producten.Skip( (filterSelectie.Paginanummer - 1) * filterSelectie.AantalTonen).Take(filterSelectie.AantalTonen).ToList();

            //ViewBag.url(filterSelectie.geefUrl());
            return View(new ProductFilter(_filter, filterSelectie, limitedProducts));
        }

        private void paginanummering(FilterSelectie f, List<Product> p)
        {
            ViewBag.aantalPagina = Math.Ceiling(Double.Parse(p.Count + "") / f.AantalTonen);
            ViewBag.huidigePagina = f.Paginanummer;
            ViewBag.aantalTonen = f.AantalTonen;
        }
        
        private List<Product> sorteren(FilterSelectie f, List<Product> p)
        {
            switch (f.SortingOptie)
            {
                case "PrijsLH":
                    return p.OrderByDescending(x => x.Prijs).ToList();
                case "PrijsHL":
                    return p.OrderBy    (x => x.Prijs).ToList();
                case "MerkAZ":
                    return p.OrderBy(x => x.Merk.Naam).ToList();
                case "MerkZA":
                    return p.OrderByDescending(x => x.Merk.Naam).ToList();
            }
            return p;
            
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