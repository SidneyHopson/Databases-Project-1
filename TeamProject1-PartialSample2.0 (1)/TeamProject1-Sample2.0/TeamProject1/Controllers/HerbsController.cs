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
    public class HerbsController : Controller
    {
        private readonly TeamProject1Context _context;

        public HerbsController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: Herbs
        public async Task<IActionResult> Index()
        {
            var teamProject1Context = _context.Herbs.Include(h => h.Seasoning);
            return View(await teamProject1Context.ToListAsync());
        }

        // GET: Herbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbs = await _context.Herbs
                .Include(h => h.Seasoning)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (herbs == null)
            {
                return NotFound();
            }

            return View(herbs);
        }

        // GET: Herbs/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id");
            return View();
        }

        // POST: Herbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hotness")] Herbs herbs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(herbs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", herbs.Id);
            return View(herbs);
        }

        // GET: Herbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbs = await _context.Herbs.SingleOrDefaultAsync(m => m.Id == id);
            if (herbs == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", herbs.Id);
            return View(herbs);
        }

        // POST: Herbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hotness")] Herbs herbs)
        {
            if (id != herbs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(herbs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HerbsExists(herbs.Id))
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
            ViewData["Id"] = new SelectList(_context.Seasoning, "Id", "Id", herbs.Id);
            return View(herbs);
        }

        // GET: Herbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var herbs = await _context.Herbs
                .Include(h => h.Seasoning)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (herbs == null)
            {
                return NotFound();
            }

            return View(herbs);
        }

        // POST: Herbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var herbs = await _context.Herbs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Herbs.Remove(herbs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HerbsExists(int id)
        {
            return _context.Herbs.Any(e => e.Id == id);
        }
    }
}
