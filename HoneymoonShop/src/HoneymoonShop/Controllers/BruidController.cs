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

        
        public IActionResult Index()
        {
            var filter = new Filter();
            var producten = _context.Product.Include(x => x.Merk).Include(x => x.Product_X_Kenmerk).ThenInclude(x => x.Kenmerk).Take(6).ToList();


            var productFilter = new ProductFilter()
            {
                Filter = filter,
                Producten = producten
            };


            return View(productFilter);
        }
        
        public IActionResult Categorie(ProductFilter productFilter)
        {
            var filterSelectie = new FilterSelectie();

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
            */

            /*sorteren*/

            /*paginanummering*/

            return View(new ProductFilter(_filter, filterSelectie, producten));
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