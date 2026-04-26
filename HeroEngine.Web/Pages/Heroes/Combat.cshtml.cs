using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Enemies;
using HeroEngine.Core.Combat;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HeroEngine.Web.Pages
{
    public class CombatModel : PageModel
    {
        private readonly HeroRepository _repo;
        private readonly CombatService _combatService;
        private readonly CombatLogWriter _logWriter;
        private readonly CsvStatsWriter _statsWriter;

        [BindProperty]
        public string SelectedHero { get; set; } = "";

        [BindProperty, Required]
        public string EnemyName { get; set; } = "Goblin";

        [BindProperty, Range(1, 100)]
        public int EnemyLevel { get; set; } = 1;

        public string? CombatLog { get; set; }
        public CombatResult? LastResult { get; set; }
        public List<AHeroes> Heroes { get; set; } = new();

        public CombatModel(HeroRepository repo, CombatService combatService,
            CombatLogWriter logWriter, CsvStatsWriter statsWriter)
        {
            _repo = repo;
            _combatService = combatService;
            _logWriter = logWriter;
            _statsWriter = statsWriter;
        }

        public void OnGet()
        {
            Heroes = _repo.LoadAll();
        }

        public IActionResult OnPost()
        {
            Heroes = _repo.LoadAll();
            if (!ModelState.IsValid)
                return Page();

            var hero = Heroes.FirstOrDefault(h => h.Name == SelectedHero);
            if (hero == null)
            {
                ModelState.AddModelError("", "Hero not found.");
                return Page();
            }

            var enemy = new CMinions(EnemyName, 10, EnemyLevel);

            var (log, result) = _combatService.Simulate(hero, enemy);
            CombatLog = log;
            LastResult = result;

            _logWriter.AppendLog(log, result);
            _statsWriter.AppendCombatStats(result);

            return Page();
        }
    }
}