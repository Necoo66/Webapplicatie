using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Data;
using HoneymoonShop.Models.GebruikerModels;
using Microsoft.AspNetCore.Authorization;

namespace HoneymoonShop.Controllers
{
    [Authorize]
    public class BeheerAfspraakController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<SoortAfspraak> AfspraakSoort;
        private List<Gebruiker> Gebruikers;
        private List<SelectListItem> listItems;
        
        public BeheerAfspraakController(ApplicationDbContext context)
        {
            _context = context;   
            AfspraakSoort = new List<SoortAfspraak>()
            {
                SoortAfspraak.Afspeldafspraak,
                SoortAfspraak.Trouwjurken,
                SoortAfspraak.Trouwpakken
            };


            Gebruikers = new List<Gebruiker>();
            listItems = new List<SelectListItem>();
            VulGebruikers();
            VulSelectListItems();
        }

        private void VulSelectListItems()
        {
            foreach (var item in Gebruikers)
            {
                listItems.Add(new SelectListItem() {  Text = item.Email.ToString(), Value = item.Id.ToString() });
            }
        }

        private void VulGebruikers()
        {
            
                foreach (var item in _context.Gebruiker)
                {
                        Gebruikers.Add(item);
                }
            
        }

        // GET: Beheer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afspraak.ToListAsync());
        }

        // GET: Beheer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // GET: Beheer/Create
        public IActionResult Create()
        {
            ViewBag.SoortAfspraak = new SelectList(AfspraakSoort);
            ViewBag.Gebruikers = listItems;
            return View();
        }


        // POST: Beheer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AfspraakSoort,Datum,Tijd,Gebruiker")] Afspraak afspraak)
        {
            var gebruiker = Gebruikers.Single(x => x.Id == afspraak.Gebruiker.Id);
            afspraak.Gebruiker = gebruiker;
            //afspraak.Gebruiker.Email = gebruiker.Email;
            afspraak.Gebruiker.EmailBevestiging = gebruiker.Email;
            //afspraak.Gebruiker.Telefoonnummer = gebruiker.Telefoonnummer;
            //afspraak.Gebruiker.Trouwdatum = gebruiker.Trouwdatum;
            //afspraak.Gebruiker.VoornaamAchternaam = gebruiker.VoornaamAchternaam;
            //afspraak.Gebruiker.Nieuwsbrief = gebruiker.Nieuwsbrief;
            ViewBag.SoortAfspraak = new SelectList(AfspraakSoort);
            ViewBag.Gebruikers = listItems;
            if (true)
            {
                var email = afspraak.Gebruiker.Email;
                _context.Add(afspraak);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(afspraak);
        }

        // GET: Beheer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.SoortAfspraak = new SelectList(AfspraakSoort);
            ViewBag.Gebruikers = listItems;
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }
            return View(afspraak);
        }

        // POST: Beheer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AfspraakSoort,Datum,Tijd,Gebruiker")] Afspraak afspraak)
        {
            if (id != afspraak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afspraak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(afspraak.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(afspraak);
        }

        // GET: Beheer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // POST: Beheer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            _context.Afspraak.Remove(afspraak);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AfspraakExists(int id)
        {
            return _context.Afspraak.Any(e => e.Id == id);
        }
    }
}
