using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using HoneymoonShop.Models.GebruikerModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HoneymoonShop.Controllers
{
    public class AfspraakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Afspraak
        public IActionResult Index()
        {
            return View();
        }

        // GET: Afspraak/Maken
        public IActionResult Maken(SoortAfspraak soortAfspraak)
        {
            return View(new AfspraakMaken {Afspraak = {AfspraakSoort = soortAfspraak}});
        }

        // POST: Afspraak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Maken([Bind("Afspraak,Gebruiker")] AfspraakMaken afspraakMaken)
        {
            if (ModelState.IsValid)
            {
                afspraakMaken.Afspraak.Gebruiker = afspraakMaken.Gebruiker;
                _context.Afspraak.Add(afspraakMaken.Afspraak);
                _context.Gebruiker.Add(afspraakMaken.Gebruiker);
                await _context.SaveChangesAsync();
                //Email verzenden
                await Mail.VerzendAfspraak(afspraakMaken);
                return RedirectToAction("Voltooid");
            }
            return View(afspraakMaken);
        }
        
        //haalt de datums op die vol gepland zijn
        public DateTime[] GetAvalibleDates(int month, int year)
        {
          return _context.Afspraak
                .Select(x => x.Datum.Date)
                .Where(x => x.Month == month && x.Year == year)
                .GroupBy(x => x)
                .Where(g => g.Count() > 2)
                .Select(g => g.Key)
                .ToArray();
        }

        //haalt de tijden op die niet beschikbaar zijn op geselecteerde datum
        public string[] GetTakenTimes(int day, int month, int year)
        {
            return _context.Afspraak.Where(x => x.Datum.Day == day && x.Datum.Month == month && x.Datum.Year == year)
                .Select(x => x.Tijd)
                .ToArray();
        }

        public IActionResult Voltooid()
        {
            return View();
        }
    }
}