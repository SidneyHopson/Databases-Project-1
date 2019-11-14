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
    public class MyRecipe_SeasoningController : Controller
    {
        private readonly TeamProject1Context _context;

        public MyRecipe_SeasoningController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: MyRecipe_Seasoning
        public async Task<IActionResult> Index()
        {
            var teamProject1Context = _context.MyRecipe_Seasoning.Include(m => m.Ingredient).Include(m => m.MyRecipe);
            return View(await teamProject1Context.ToListAsync());
        }

        // GET: MyRecipe_Seasoning/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe_Seasoning = await _context.MyRecipe_Seasoning
                .Include(m => m.Ingredient)
                .Include(m => m.MyRecipe)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (myRecipe_Seasoning == null)
            {
                return NotFound();
            }

            return View(myRecipe_Seasoning);
        }

        // GET: MyRecipe_Seasoning/Create
        public IActionResult Create()
        {
            ViewData["I_id"] = new SelectList(_context.Ingredient, "Id", "Id");
            ViewData["R_id"] = new SelectList(_context.MyRecipe, "Id", "Id");
            return View();
        }

        // POST: MyRecipe_Seasoning/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,R_id,Weight,I_id")] MyRecipe_Seasoning myRecipe_Seasoning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myRecipe_Seasoning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["I_id"] = new SelectList(_context.Ingredient, "Id", "Id", myRecipe_Seasoning.I_id);
            ViewData["R_id"] = new SelectList(_context.MyRecipe, "Id", "Id", myRecipe_Seasoning.R_id);
            return View(myRecipe_Seasoning);
        }

        // GET: MyRecipe_Seasoning/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe_Seasoning = await _context.MyRecipe_Seasoning.SingleOrDefaultAsync(m => m.Id == id);
            if (myRecipe_Seasoning == null)
            {
                return NotFound();
            }
            ViewData["I_id"] = new SelectList(_context.Ingredient, "Id", "Id", myRecipe_Seasoning.I_id);
            ViewData["R_id"] = new SelectList(_context.MyRecipe, "Id", "Id", myRecipe_Seasoning.R_id);
            return View(myRecipe_Seasoning);
        }

        // POST: MyRecipe_Seasoning/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,R_id,Weight,I_id")] MyRecipe_Seasoning myRecipe_Seasoning)
        {
            if (id != myRecipe_Seasoning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myRecipe_Seasoning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyRecipe_SeasoningExists(myRecipe_Seasoning.Id))
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
            ViewData["I_id"] = new SelectList(_context.Ingredient, "Id", "Id", myRecipe_Seasoning.I_id);
            ViewData["R_id"] = new SelectList(_context.MyRecipe, "Id", "Id", myRecipe_Seasoning.R_id);
            return View(myRecipe_Seasoning);
        }

        // GET: MyRecipe_Seasoning/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe_Seasoning = await _context.MyRecipe_Seasoning
                .Include(m => m.Ingredient)
                .Include(m => m.MyRecipe)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (myRecipe_Seasoning == null)
            {
                return NotFound();
            }

            return View(myRecipe_Seasoning);
        }

        // POST: MyRecipe_Seasoning/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myRecipe_Seasoning = await _context.MyRecipe_Seasoning.SingleOrDefaultAsync(m => m.Id == id);
            _context.MyRecipe_Seasoning.Remove(myRecipe_Seasoning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyRecipe_SeasoningExists(int id)
        {
            return _context.MyRecipe_Seasoning.Any(e => e.Id == id);
        }
    }
}
