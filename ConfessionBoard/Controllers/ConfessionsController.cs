using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConfessionBoard.Data;
using ConfessionBoard.Models;

namespace ConfessionBoard.Controllers
{
    public class ConfessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConfessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Confessions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Confession.ToListAsync());
        }

        // GET: Confessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Confession == null)
            {
                return NotFound();
            }

            var confession = await _context.Confession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confession == null)
            {
                return NotFound();
            }

            return View(confession);
        }

        // GET: Confessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SenderID,Relationship,Message,RecipientLN,RecipientFN,GiftFK")] Confession confession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(confession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(confession);
        }

        // GET: Confessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Confession == null)
            {
                return NotFound();
            }

            var confession = await _context.Confession.FindAsync(id);
            if (confession == null)
            {
                return NotFound();
            }
            return View(confession);
        }

        // POST: Confessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SenderID,Relationship,Message,RecipientLN,RecipientFN,GiftFK")] Confession confession)
        {
            if (id != confession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfessionExists(confession.Id))
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
            return View(confession);
        }

        // GET: Confessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Confession == null)
            {
                return NotFound();
            }

            var confession = await _context.Confession
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confession == null)
            {
                return NotFound();
            }

            return View(confession);
        }

        // POST: Confessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Confession == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Confession'  is null.");
            }
            var confession = await _context.Confession.FindAsync(id);
            if (confession != null)
            {
                _context.Confession.Remove(confession);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfessionExists(int id)
        {
          return _context.Confession.Any(e => e.Id == id);
        }
    }
}
