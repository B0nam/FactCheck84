using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FactCheck84.Models;
using FactCheck84.Services;

namespace FactCheck84.Controllers
{
    public class RedactedWordsController : Controller
    {
        private readonly FactCheck84Context _context;
        private readonly CensorshipService _censorshipService;

        public RedactedWordsController(FactCheck84Context context, CensorshipService censorshipService)
        {
            _context = context;
            _censorshipService = censorshipService;
        }

        // GET: RedactedWords
        public async Task<IActionResult> Index()
        {
            return _context.RedactedWords != null ?
                        View(await _context.RedactedWords.ToListAsync()) :
                        Problem("Entity set 'FactCheck84Context.RedactedWords'  is null.");
        }

        // TASK: CENSORSHIP
        public async Task CensorContent()
        {
            var allTexts = await _context.Texts.ToListAsync();

            foreach (var text in allTexts)
            {
                text.CensoredContent = text.Content;
                text.CensoredContent = _censorshipService.ApplyCensorship(text.Content);
            }

            await _context.SaveChangesAsync();
        }

        // GET: RedactedWords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RedactedWords == null)
            {
                return NotFound();
            }

            var redactedWord = await _context.RedactedWords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redactedWord == null)
            {
                return NotFound();
            }

            return View(redactedWord);
        }

        // GET: RedactedWords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RedactedWords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Word,NewWord,IsHidden,CreationDate")] RedactedWord redactedWord)
        {
            if (ModelState.IsValid)
            {
                if (redactedWord.NewWord == null)
                {
                    redactedWord.IsHidden = true;
                }
                if (redactedWord.IsHidden)
                {
                    redactedWord.NewWord = "[--REDACTED---]";
                }
                _context.Add(redactedWord);
                await _context.SaveChangesAsync();

                await CensorContent();
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(redactedWord);
        }

        // GET: RedactedWords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RedactedWords == null)
            {
                return NotFound();
            }

            var redactedWord = await _context.RedactedWords.FindAsync(id);
            if (redactedWord == null)
            {
                return NotFound();
            }
            return View(redactedWord);
        }

        // POST: RedactedWords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Word,NewWord,IsHidden,CreationDate")] RedactedWord redactedWord)
        {
            if (id != redactedWord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (redactedWord.NewWord == null)
                {
                    redactedWord.IsHidden = true;
                }
                if (redactedWord.IsHidden)
                {
                    redactedWord.NewWord = "[--REDACTED---]";
                }
                try
                {
                    _context.Update(redactedWord);
                    await _context.SaveChangesAsync();

                    await CensorContent();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RedactedWordExists(redactedWord.Id))
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
            return View(redactedWord);
        }

        // GET: RedactedWords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RedactedWords == null)
            {
                return NotFound();
            }

            var redactedWord = await _context.RedactedWords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (redactedWord == null)
            {
                return NotFound();
            }

            return View(redactedWord);
        }

        // POST: RedactedWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RedactedWords == null)
            {
                return Problem("Entity set 'FactCheck84Context.RedactedWords'  is null.");
            }
            var redactedWord = await _context.RedactedWords.FindAsync(id);
            if (redactedWord != null)
            {
                _context.RedactedWords.Remove(redactedWord);
            }

            await _context.SaveChangesAsync();

            await CensorContent();
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool RedactedWordExists(int id)
        {
            return (_context.RedactedWords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}