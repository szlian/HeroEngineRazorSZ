using HeroEngine.Core.Classes;
using HeroEngine.Core.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages.Heroes
{
    public class IndexModel : PageModel
    {
        private readonly HeroRepository _repo;
        public List<AHeroes> Heroes { get; set; } = new();
        public int HeroCount { get; set; }

        public IndexModel(HeroRepository repo) => _repo = repo;

        public void OnGet()
        {
            Heroes = _repo.LoadAll();
            HeroCount = Heroes.Count;
        }
    }
}