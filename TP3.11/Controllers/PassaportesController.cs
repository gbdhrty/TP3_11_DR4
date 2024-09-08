using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3._11.DAL;
using TP3._11.Models;

namespace TP3._11.Controllers
{
    public class PassaportesController : Controller
    {
        private readonly Contexto _context;

        public PassaportesController(Contexto context)
        {
            _context = context;
        }

        // GET: Passaportes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Passaportes.Include(p => p.Pessoa);
            return View(await contexto.ToListAsync());
        }

        // GET: Passaportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passaporte = await _context.Passaportes
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passaporte == null)
            {
                return NotFound();
            }

            return View(passaporte);
        }

        // GET: Passaportes/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Pessoas, "Id", "Id");
            return View();
        }

        // POST: Passaportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero")] Passaporte passaporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passaporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Pessoas, "Id", "Id", passaporte.Id);
            return View(passaporte);
        }

        // GET: Passaportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passaporte = await _context.Passaportes.FindAsync(id);
            if (passaporte == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Pessoas, "Id", "Id", passaporte.Id);
            return View(passaporte);
        }

        // POST: Passaportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero")] Passaporte passaporte)
        {
            if (id != passaporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passaporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassaporteExists(passaporte.Id))
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
            ViewData["Id"] = new SelectList(_context.Pessoas, "Id", "Id", passaporte.Id);
            return View(passaporte);
        }

        // GET: Passaportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passaporte = await _context.Passaportes
                .Include(p => p.Pessoa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passaporte == null)
            {
                return NotFound();
            }

            return View(passaporte);
        }

        // POST: Passaportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passaporte = await _context.Passaportes.FindAsync(id);
            if (passaporte != null)
            {
                _context.Passaportes.Remove(passaporte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassaporteExists(int id)
        {
            return _context.Passaportes.Any(e => e.Id == id);
        }
    }
}
