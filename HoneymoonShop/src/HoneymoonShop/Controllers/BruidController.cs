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

        public IActionResult Product(int? id)
        {
            /* if (id == null)
             {
                 return NotFound();
             }

             var trouwjurk = await _context.Trouwjurk.SingleOrDefaultAsync(t => t.Id == id);
             if (trouwjurk == null)
             {
                 return NotFound();
             }*/

            //var trouwjurk = new Product()
            //{
            //    Beschrijving = "asdafanfnas'gn'savkn akfn kadnf kadnf daf adnkf'nda'kf nad'gn ádn adn'f nadn 43t",
            //    ArtikelNummer = "123",
            //    Prijs = 10.20,
            //    Merk = new Merk() { naam = "Merknaam" },
            //    Categorie = new Categorie() { Naam = "cat1" },
            //    Kleuren = new List<Kleur>() {
            //                                    new Kleur() { naam = "blue", Kleurcode = "0000FF" },
            //                                    new Kleur() { naam = "rood", Kleurcode = "FF0000" }
            //                                },
            //    Kenmerken = new List<Kenmerk>() { new Kenmerk { Naam = "lange nek", KenmerkType = "Neklijn"},
            //            new Kenmerk { Naam = "korte nek", KenmerkType = "Neklijn"},
            //            new Kenmerk { Naam = "kort", KenmerkType = "Silhouette"},
            //            new Kenmerk { Naam = "kort", KenmerkType = "Stijl"},
            //            new Kenmerk { Naam = "lang", KenmerkType = "Stijl"},
            //    }
                
            //};
            return View();
        }
    }
}