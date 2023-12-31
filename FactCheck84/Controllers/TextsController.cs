﻿using System;
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
    public class TextsController : Controller
    {
        private readonly FactCheck84Context _context;
        private readonly CensorshipService _censorshipService;

        public TextsController(FactCheck84Context context, CensorshipService censorshipService)
        {
            _context = context;
            _censorshipService = censorshipService;
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

        // GET: Texts
        public async Task<IActionResult> Index()
        {
            var factCheck84Context = _context.Texts.Include(t => t.Author).Include(t => t.TextStatus);
            return View(await factCheck84Context.ToListAsync());
        }

        // GET: Texts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Texts == null)
            {
                return NotFound();
            }

            var text = await _context.Texts
                .Include(t => t.Author)
                .Include(t => t.TextStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (text == null)
            {
                return NotFound();
            }

            return View(text);
        }

        // GET: Texts/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id");
            ViewData["TextStatusId"] = new SelectList(_context.TextStatuses, "Id", "Id");
            return View();
        }

        // POST: Texts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Texts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Content")] TextCreateModel textModel, int authorId, int textStatusId)
        {

            if (ModelState.IsValid)
            {
                var text = new Text
                {
                    Title = textModel.Title,
                    Description = textModel.Description,
                    Content = textModel.Content,
                    AuthorId = authorId,
                    TextStatusId = textStatusId,
                    CensoredContent = textModel.Content
                };

                _context.Add(text);

                await CensorContent();
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", authorId);
            ViewData["TextStatusId"] = new SelectList(_context.TextStatuses, "Id", "Id", textStatusId);

            return View(textModel); // Aqui você retorna o model original com os campos preenchidos pelo usuário
        }

        // GET: Texts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Texts == null)
            {
                return NotFound();
            }

            var text = await _context.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", text.AuthorId);
            ViewData["TextStatusId"] = new SelectList(_context.TextStatuses, "Id", "Id", text.TextStatusId);
            return View(text);
        }

        // POST: Texts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Content,AuthorId,TextStatusId")] Text text)
        {
            if (id != text.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(text);
                    await _context.SaveChangesAsync();

                    await CensorContent();
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextExists(text.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "Id", "Id", text.AuthorId);
            ViewData["TextStatusId"] = new SelectList(_context.TextStatuses, "Id", "Id", text.TextStatusId);
            return View(text);
        }

        // GET: Texts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Texts == null)
            {
                return NotFound();
            }

            var text = await _context.Texts
                .Include(t => t.Author)
                .Include(t => t.TextStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (text == null)
            {
                return NotFound();
            }

            return View(text);
        }

        // POST: Texts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Texts == null)
            {
                return Problem("Entity set 'FactCheck84Context.Texts'  is null.");
            }
            var text = await _context.Texts.FindAsync(id);
            if (text != null)
            {
                _context.Texts.Remove(text);
            }

            await CensorContent();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextExists(int id)
        {
          return (_context.Texts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
