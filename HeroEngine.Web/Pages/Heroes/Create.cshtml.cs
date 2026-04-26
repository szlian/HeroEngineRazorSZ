using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Heroes;
using HeroEngine.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HeroEngine.Web.Pages.Heroes
{
    public class CreateModel : PageModel
    {
        private readonly HeroRepository _repo;

        [BindProperty, Required]
        public string Name { get; set; } = "";

        [BindProperty, Required, Range(1, 100)]
        public int HealthBase { get; set; } = 10;

        [BindProperty, Required, Range(1, 100)]
        public int Level { get; set; } = 1;

        [BindProperty, Required]
        public string ClassType { get; set; } = "CWarrior";

        [BindProperty]
        public int? Armor { get; set; }

        public CreateModel(HeroRepository repo) => _repo = repo;

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            AHeroes hero = ClassType switch
            {
                "CWarrior" => new CWarrior(Name, HealthBase, Level, Armor ?? 0),
                "CRogue" => new CRogue(Name, HealthBase, Level),
                _ => null!
            };

            if (hero == null)
            {
                ModelState.AddModelError("", "Invalid class type.");
                return Page();
            }

            _repo.Add(hero);
            return RedirectToPage("/Heroes/Index");
        }
    }
}