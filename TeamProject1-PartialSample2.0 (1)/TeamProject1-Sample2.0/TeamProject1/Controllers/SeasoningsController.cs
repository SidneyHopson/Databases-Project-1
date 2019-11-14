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
    public class SeasoningsController : Controller
    {
        private readonly TeamProject1Context _context;

        public SeasoningsController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: Seasonings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seasoning.ToListAsync());
        }

        // GET: Seasonings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasoning = await _context.Seasoning
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seasoning == null)
            {
                return NotFound();
            }

            return View(seasoning);
        }

        // GET: Seasonings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seasonings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Origin,Calories")] Seasoning seasoning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seasoning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seasoning);
        }

        // GET: Seasonings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasoning = await _context.Seasoning.SingleOrDefaultAsync(m => m.Id == id);
            if (seasoning == null)
            {
                return NotFound();
            }
            return View(seasoning);
        }

        // POST: Seasonings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Origin,Calories")] Seasoning seasoning)
        {
            if (id != seasoning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seasoning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeasoningExists(seasoning.Id))
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
            return View(seasoning);
        }

        // GET: Seasonings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seasoning = await _context.Seasoning
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seasoning == null)
            {
                return NotFound();
            }

            return View(seasoning);
        }

        // POST: Seasonings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seasoning = await _context.Seasoning.SingleOrDefaultAsync(m => m.Id == id);
            _context.Seasoning.Remove(seasoning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeasoningExists(int id)
        {
            return _context.Seasoning.Any(e => e.Id == id);
        }
    }
}
