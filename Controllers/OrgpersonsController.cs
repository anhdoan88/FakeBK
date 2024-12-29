using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FakeBK.Models;

namespace FakeBK.Controllers
{
    public class OrgpersonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrgpersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orgpersons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orgpeople.ToListAsync());
        }

        // GET: Orgpersons/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgperson = await _context.Orgpeople
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgperson == null)
            {
                return NotFound();
            }

            return View(orgperson);
        }

        // GET: Orgpersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orgpersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Orgperson orgperson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orgperson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orgperson);
        }

        // GET: Orgpersons/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgperson = await _context.Orgpeople.FindAsync(id);
            if (orgperson == null)
            {
                return NotFound();
            }
            return View(orgperson);
        }

        // POST: Orgpersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id")] Orgperson orgperson)
        {
            if (id != orgperson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orgperson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrgpersonExists(orgperson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orgperson);
        }

        // GET: Orgpersons/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orgperson = await _context.Orgpeople
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orgperson == null)
            {
                return NotFound();
            }

            return View(orgperson);
        }

        // POST: Orgpersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var orgperson = await _context.Orgpeople.FindAsync(id);
            if (orgperson != null)
            {
                _context.Orgpeople.Remove(orgperson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrgpersonExists(decimal id)
        {
            return _context.Orgpeople.Any(e => e.Id == id);
        }
    }
}
