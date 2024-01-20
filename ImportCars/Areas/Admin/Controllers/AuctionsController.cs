using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImportCars.Data;
using ImportCars.Models;

namespace ImportCars.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuctionsController : Controller
    {
        private readonly Context _context;

        public AuctionsController(Context context)
        {
            _context = context;
        }

        // GET: Admin/Auctions
        public async Task<IActionResult> Index()
        {
              return _context.Auctions != null ? 
                          View(await _context.Auctions.ToListAsync()) :
                          Problem("Entity set 'Context.Auctions'  is null.");
        }

        // GET: Admin/Auctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctions == null)
            {
                return NotFound();
            }

            return View(auctions);
        }

        // GET: Admin/Auctions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Auctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EndDate")] Auctions auctions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auctions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auctions);
        }

        // GET: Admin/Auctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions.FindAsync(id);
            if (auctions == null)
            {
                return NotFound();
            }
            return View(auctions);
        }

        // POST: Admin/Auctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EndDate")] Auctions auctions)
        {
            if (id != auctions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auctions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuctionsExists(auctions.Id))
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
            return View(auctions);
        }

        // GET: Admin/Auctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Auctions == null)
            {
                return NotFound();
            }

            var auctions = await _context.Auctions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auctions == null)
            {
                return NotFound();
            }

            return View(auctions);
        }

        // POST: Admin/Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Auctions == null)
            {
                return Problem("Entity set 'Context.Auctions'  is null.");
            }
            var auctions = await _context.Auctions.FindAsync(id);
            if (auctions != null)
            {
                _context.Auctions.Remove(auctions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuctionsExists(int id)
        {
          return (_context.Auctions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
