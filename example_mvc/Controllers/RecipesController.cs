using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using example_mvc.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;



namespace example_mvc.Controllers
{
    public class RecipesController : Controller
    {
        private readonly example_mvcContext _context;
        private readonly UserManager<IdentityUser> _userManager;

       
        public RecipesController(example_mvcContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string searchString, string SortRecipe)
        {

            var Recipe = from r in _context.Recipes
                         
                          .Include(c => c.RecipeTags)
                          .ThenInclude(c => c.Tag)
                          
                          
                         select r;




            if (!String.IsNullOrEmpty(searchString))
            {
                Recipe = Recipe.Where(s => s.Name.Contains(searchString));
            }
            
            switch (SortRecipe)
            {
                case "Easiest":
                    Recipe = Recipe.OrderBy(s => s.difficulty);
                    break;
                case "Hardest":
                    Recipe = Recipe.OrderByDescending(s => s.difficulty);
                    break;
                case "Alphabetically":
                    Recipe = Recipe.OrderBy(s => s.Name);
                    break;
                case "Newest":
                    Recipe = Recipe.OrderByDescending(s => s.Id);
                    break;
                case "Oldest":
                    Recipe = Recipe.OrderBy(s => s.Id);
                    break;

            }
            
            

            return View(await Recipe.ToListAsync());
        }
        
    

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        
        // GET: Recipes/Create
        [Authorize]
        public IActionResult Create()
        {

            CreateRecipeViewModel viewModel = new CreateRecipeViewModel();
            return View(viewModel);
        }
       
        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Recipe,RecipeTags")] CreateRecipeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {


                Recipe recipe = viewModel.Recipe;
                if(viewModel.RecipeTags == null)
                {
                    viewModel.RecipeTags = "";
                }
                recipe.CreatorId = _userManager.GetUserId(User);
                List<string> tags = viewModel.RecipeTags.Split(",")
                            .ToList();

                tags.ForEach(delegate (string t) {
                    t.ToLower();
                });

                List<Tag> existingTags = _context.Tags.ToList();

                foreach(string tag in tags)
                {
                 
                    var tagByName = from existingTag in existingTags
                                    where existingTag.Name == tag
                                    select existingTag;
                  
                    if(!tagByName.Any())
                    {
                        Tag tagObject = new Tag();
                        tagObject.Name = tag;
                        recipe.RecipeTags.Add((new RecipeTag { Recipe = recipe, Tag = tagObject }));
                    }
                    else
                    {
                        Tag tagObject = tagByName.First();
                        recipe.RecipeTags.Add((new RecipeTag { Recipe = recipe, Tag = tagObject }));
                    }


                }
            
                _context.Add(recipe);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);

        }
        [Authorize]
        public IActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddTag ([Bind("TagId,Name")] Tag newtag)
        {
            if(ModelState.IsValid)
            {
                _context.Add(newtag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(newtag);
        }

        // GET: Recipes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.FindAsync(id);
           

            if (recipe == null)
            {
                return NotFound();
            }
            if (_userManager.GetUserId(User) != (recipe.CreatorId))
            {
                return NotFound();


            }
            return View(recipe);

        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl,PreparationTime,difficulty")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    recipe.CreatorId = _userManager.GetUserId(User);
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
