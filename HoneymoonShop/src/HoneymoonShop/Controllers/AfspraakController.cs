using System.Linq;
using System.Threading.Tasks;
using HoneymoonShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Models.GebruikerModels;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afspraak.ToListAsync());
        }

        // GET: Afspraak/Details/5
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

        // GET: Afspraak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afspraak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Tijd")] Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afspraak);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(afspraak);
        }

        // GET: Afspraak/Maken
        public IActionResult Maken()
        {
            return View();
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
                _context.Add(afspraakMaken.Afspraak);
                _context.Add(afspraakMaken.Gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(afspraakMaken);
        }

        // GET: Afspraak/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Afspraak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Tijd")] Afspraak afspraak)
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

        // GET: Afspraak/Delete/5
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

        // POST: Afspraak/Delete/5
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