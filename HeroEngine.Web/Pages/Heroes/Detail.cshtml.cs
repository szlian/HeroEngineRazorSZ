using HeroEngine.Core.Data;
using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages.Heroes
{
    public class DetailModel : PageModel
    {
        private readonly HeroRepository _repo;

        public AHeroes? Hero { get; set; }
        public List<IAbility> HeroAbilities { get; set; } = new();

        public DetailModel(HeroRepository repo) => _repo = repo;

        public IActionResult OnGet(string name)
        {
            Hero = _repo.LoadAll().FirstOrDefault(h => h.Name == name);
            if (Hero == null)
                return NotFound();

            HeroAbilities = Hero.Abilities.ToList();
            return Page();
        }
    }
}