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
    public class GrainsController : Controller
    {
        private readonly TeamProject1Context _context;

        public GrainsController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: Grains
        public async Task<IActionResult> Index()
        {
            var teamProject1Context = _context.Grain.Include(g => g.Ingredient);
            return View(await teamProject1Context.ToListAsync());
        }

        // GET: Grains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .Include(g => g.Ingredient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // GET: Grains/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Ingredient, "Id", "Id");
            return View();
        }

        // POST: Grains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Calories")] Ingredient ingredient, [Bind("Carbs")] Grain grain)
        {
            if (ModelState.IsValid)
            {
                _context.Ingredient.Add(ingredient);
                grain.Id = ingredient.Id;
                _context.Add(grain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Ingredient, "Id", "Id", grain.Id);
            return View(grain);
        }

        // GET: Grains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain.SingleOrDefaultAsync(m => m.Id == id);
            if (grain == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Ingredient, "Id", "Id", grain.Id);
            return View(grain);
        }

        // POST: Grains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name, Calories")] Ingredient ingredient, [Bind("Id,Carbs")] Grain grain)
        {
            if (id != grain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrainExists(grain.Id))
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
            ViewData["Id"] = new SelectList(_context.Ingredient, "Id", "Id", grain.Id);
            return View(grain);
        }

        // GET: Grains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grain = await _context.Grain
                .Include(g => g.Ingredient)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (grain == null)
            {
                return NotFound();
            }

            return View(grain);
        }

        // POST: Grains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grain = await _context.Grain.SingleOrDefaultAsync(m => m.Id == id);
            _context.Grain.Remove(grain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrainExists(int id)
        {
            return _context.Grain.Any(e => e.Id == id);
        }
    }
}
