using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamProject1.Models;

namespace TeamProject1.Controllers
{
    public class SpicesController : Controller
    {
        private readonly TeamProject1Context _context;

        public SpicesController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: Spices
        public async Task<IActionResult> Index()
        {
            var teamProject1Context = _context.Spices.Include(s => s.Seasoning);
            return View(await teamProject1Context.ToListAsync());
        }

        // GET: Spices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spices = await _context.Spices
                .Include(s => s.Seasoning)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spices == null)
            {
                return NotFound();
            }

            return View(spices);
        }

        // GET: Spices/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id");
            return View();
        }

        // POST: Spices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Calories, Origin")] Seasoning seasoning, [Bind("Hotness")] Spices spices)
        {
            if (ModelState.IsValid)
            {
                _context.Seasoning.Add(seasoning);
                spices.Id = seasoning.Id;
                _context.Add(spices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", spices.Id);
            return View(spices);
        }

        // GET: Spices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spices = await _context.Spices.FindAsync(id);
            var seasoning = await _context.Seasoning.FindAsync(id);
            if (spices == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", spices.Id);
            return View(spices);
        }

        // POST: Spices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Calories, Origin")] Seasoning seasoning, [Bind("Id,Hotness")] Spices spices)
        {
            if (id != spices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    seasoning.Id = id;
                    _context.Seasoning.Update(seasoning);
                    _context.Update(spices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpicesExists(spices.Id))
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
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", spices.Id);
            return View(spices);
        }

        // GET: Spices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spices = await _context.Spices
                .Include(s => s.Seasoning)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spices == null)
            {
                return NotFound();
            }

            return View(spices);
        }

        // POST: Spices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seasoning = await _context.Seasoning.FindAsync(id);
            _context.Seasoning.Remove(seasoning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpicesExists(int id)
        {
            return _context.Spices.Any(e => e.Id == id);
        }
    }
}
