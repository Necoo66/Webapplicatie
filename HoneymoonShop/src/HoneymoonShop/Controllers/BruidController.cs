using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using HoneymoonShop.Models.Bruid;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;

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
                // de toList bij merken komt de foutmelding
                Merken = _context.Merk.ToList(),
                CategorieŽn = _context.Categorie.ToList(),
                Stijlen = _context.Kenmerk.Where(x => x.Type.Equals("Stijl")).ToList(),
                KenmerkNamen = _context.Kenmerk.Where(x => !x.Type.Equals("Stijl")).Select(x => x.Type).Distinct().ToList(),
                Kenmerken = _context.Kenmerk.ToList()
            };
        }

        //index pagina waar er 6 producten worden getoond
        public IActionResult Index(FilterSelectie filterSelectie)
        {
            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).Take(6).ToList();

            return View(new ProductFilter(_filter, filterSelectie, producten));
        }

        //categorie pagina met filters
        public IActionResult Categorie(FilterSelectie filterSelectie)
        {
            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();

            _filter.MaxPrijs = producten.Max(x => x.Prijs);

            //elke if controleert of de filter was geselecteerd
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

            if (filterSelectie.Kenmerken.Count != 0)
            {
                producten = producten.FindAll(x => x.Product_X_Kenmerk.Any(y => filterSelectie.Kenmerken.Contains(y.KenmerkId)));
            }

            //bool om te controleren of er een kleur selected is
            filterSelectie.Kleurselected = filterSelectie.Kenmerken.Intersect(_context.Kenmerk.Where(x => x.Type.Equals("Kleur")).Select(x => x.Id)).Any();
            
            /*sorteren*/
            producten = sorteren(filterSelectie, producten);

            /*paginanummering*/
            paginanummering(filterSelectie, producten);

            List<Product> limitedProducts = producten.Skip((filterSelectie.Paginanummer - 1) * filterSelectie.AantalTonen).Take(filterSelectie.AantalTonen).ToList();
            
            return View(new ProductFilter(_filter, filterSelectie, limitedProducts));
        }

        //functie die de waardes voor paginanummering regelen
        private void paginanummering(FilterSelectie f, List<Product> p)
        {
            ViewBag.aantalPagina = Math.Ceiling(Double.Parse(p.Count + "") / f.AantalTonen);
            ViewBag.huidigePagina = f.Paginanummer;
            ViewBag.aantalTonen = f.AantalTonen;
        }

        //functie om producten te sorteren
        private List<Product> sorteren(FilterSelectie f, List<Product> p)
        {
            switch (f.SortingOptie)
            {
                case "PrijsLH":
                    return p.OrderByDescending(x => x.Prijs).ToList();
                case "PrijsHL":
                    return p.OrderBy(x => x.Prijs).ToList();
                case "MerkAZ":
                    return p.OrderBy(x => x.Merk.Naam).ToList();
                case "MerkZA":
                    return p.OrderByDescending(x => x.Merk.Naam).ToList();
            }
            return p;

        }

        //product pagina toont 1 product met details
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

            //haalt bijpassende producten op aan de hand van het merk
            var bijpassend = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).ToList();
            bijpassend = bijpassend.Where(x => x.Merk == trouwjurk.Merk).Take(4).ToList();
            ViewBag.bijpassend = bijpassend;

            return View(trouwjurk);
        }
    }
}