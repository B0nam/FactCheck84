using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactCheck84.Models;

namespace FactCheck84.Controllers
{
    public class EditorOfficersController : Controller
    {
        private readonly FactCheck84Context _context;

        public EditorOfficersController(FactCheck84Context context)
        {
            _context = context;
        }

        // GET: EditorOfficers
        public async Task<IActionResult> Index()
        {
            var factCheck84Context = _context.EditorOfficers.Include(e => e.AccountStatus);
            return View(await factCheck84Context.ToListAsync());
        }

        // GET: EditorOfficers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EditorOfficers == null)
            {
                return NotFound();
            }

            var editorOfficer = await _context.EditorOfficers
                .Include(e => e.AccountStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorOfficer == null)
            {
                return NotFound();
            }

            return View(editorOfficer);
        }

        // GET: EditorOfficers/Create
        public IActionResult Create()
        {
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatuses, "Id", "Id");
            return View();
        }

        // POST: EditorOfficers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AccountStatusId,Name,Password,CreationDate,Address,SocialNum")] EditorOfficer editorOfficer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorOfficer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatuses, "Id", "Id", editorOfficer.AccountStatusId);
            return View(editorOfficer);
        }

        // GET: EditorOfficers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EditorOfficers == null)
            {
                return NotFound();
            }

            var editorOfficer = await _context.EditorOfficers.FindAsync(id);
            if (editorOfficer == null)
            {
                return NotFound();
            }
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatuses, "Id", "Id", editorOfficer.AccountStatusId);
            return View(editorOfficer);
        }

        // POST: EditorOfficers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AccountStatusId,Name,Password,CreationDate,Address,SocialNum")] EditorOfficer editorOfficer)
        {
            if (id != editorOfficer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorOfficer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorOfficerExists(editorOfficer.Id))
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
            ViewData["AccountStatusId"] = new SelectList(_context.AccountStatuses, "Id", "Id", editorOfficer.AccountStatusId);
            return View(editorOfficer);
        }

        // GET: EditorOfficers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EditorOfficers == null)
            {
                return NotFound();
            }

            var editorOfficer = await _context.EditorOfficers
                .Include(e => e.AccountStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (editorOfficer == null)
            {
                return NotFound();
            }

            return View(editorOfficer);
        }

        // POST: EditorOfficers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EditorOfficers == null)
            {
                return Problem("Entity set 'FactCheck84Context.EditorOfficers'  is null.");
            }
            var editorOfficer = await _context.EditorOfficers.FindAsync(id);
            if (editorOfficer != null)
            {
                _context.EditorOfficers.Remove(editorOfficer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorOfficerExists(int id)
        {
          return (_context.EditorOfficers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
