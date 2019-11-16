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
    public class MyRecipesController : Controller
    {
        private readonly TeamProject1Context _context;

        public MyRecipesController(TeamProject1Context context)
        {
            _context = context;
        }

        // GET: MyRecipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyRecipe.ToListAsync());
        }

        public async Task<IActionResult> Show(string id)
        {
            var recipes = from m in _context.MyRecipe
                           join n in _context.MyRecipe_Ingredient
                           on m.Id equals n.R_id
                           join o in _context.Ingredient
                           on n.I_id equals o.Id
                           join p in _context.MyRecipe_Seasoning
                           on m.Id equals p.R_id
                           join q in _context.Seasoning
                           on p.S_id equals q.Id
                           orderby m.Name, o.Name, q.Name
                           select new
                           {
                               MyRecipe = m,
                               Ingred = o,
                               InWeight = n.Weight,
                               Season  = q,
                               SeWeight = p.Weight
                           };

            if (!String.IsNullOrEmpty(id))
            {
                recipes = recipes.Where(m => m.MyRecipe.Name.Contains(id));
            }
            recipes = recipes.OrderBy(m => m.Ingred.Name).OrderBy(m => m.MyRecipe.Name);

            var tmp = await recipes.ToListAsync();
            List<RecipeDetails> lrd = new List<RecipeDetails>();
            foreach (var item in tmp)
            {
                int rid = item.MyRecipe.Id;
                RecipeDetails rd = (lrd.Count > 0) ? lrd.ElementAt(lrd.Count - 1) : null;
                if (rd != null && rd.MyRecipe.Id == rid)
                {
                    Ingredient_W cew = new Ingredient_W { Ingredient = item.Ingred, Weight = item.InWeight };
                    rd.I_common.Add(cew);
                    rd.Total_calories += item.Ingred.Calories * item.InWeight;
                    Seasoning_W sew = new Seasoning_W { Seasoning = item.Season, Weight = item.SeWeight };
                    rd.S_common.Add(sew);
                    rd.Total_calories += item.Season.Calories * item.SeWeight;
                }
                else
                {
                    List<Ingredient_W> my_lce = new List<Ingredient_W>();
                    Ingredient_W cew = new Ingredient_W { Ingredient = item.Ingred, Weight = item.InWeight };
                    my_lce.Add(cew);
                    List<Seasoning_W> my_lse = new List<Seasoning_W>();
                    Seasoning_W sew = new Seasoning_W { Seasoning = item.Season, Weight = item.SeWeight };
                    my_lse.Add(sew);
                    rd = new RecipeDetails
                    {
                        MyRecipe = item.MyRecipe,
                        I_common = my_lce,
                        S_common = my_lse
                    };
                    rd.Total_calories += item.Ingred.Calories * item.InWeight;
                    rd.Total_calories += item.Season.Calories * item.SeWeight;
                    lrd.Add(rd);
                }
            }
            ViewData["TypesArray"] = new string[] { "Ingredient", "Seasoning" };
            return View(lrd);
        }
        
        // GET: MyRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe = await _context.MyRecipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRecipe == null)
            {
                return NotFound();
            }

            return View(myRecipe);
        }

        // GET: MyRecipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyRecipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] MyRecipe myRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myRecipe);
        }

        // GET: MyRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe = await _context.MyRecipe.FindAsync(id);
            if (myRecipe == null)
            {
                return NotFound();
            }
            return View(myRecipe);
        }

        // POST: MyRecipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MyRecipe myRecipe)
        {
            if (id != myRecipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyRecipeExists(myRecipe.Id))
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
            return View(myRecipe);
        }

        // GET: MyRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myRecipe = await _context.MyRecipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myRecipe == null)
            {
                return NotFound();
            }

            return View(myRecipe);
        }

        // POST: MyRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myRecipe = await _context.MyRecipe.FindAsync(id);
            _context.MyRecipe.Remove(myRecipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyRecipeExists(int id)
        {
            return _context.MyRecipe.Any(e => e.Id == id);
        }
    }
}
