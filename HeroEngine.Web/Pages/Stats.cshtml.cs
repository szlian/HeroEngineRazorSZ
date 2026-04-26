using HeroEngine.Core.Analytics;
using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Enums;
using HeroEngine.Core.Classes.Interface;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages
{
    public class StatsModel : PageModel
    {
        private readonly HeroRepository _repo;
        private readonly CsvStatsWriter _statsWriter;

        public List<AHeroes> AllHeroes { get; set; } = new();
        public List<CombatResult> CombatHistory { get; set; } = new();

        public List<AHeroes> TopHeroes { get; set; } = new();
        public Dictionary<string, int> HeroesByClass { get; set; } = new();
        public Dictionary<string, int> AbilitiesByType { get; set; } = new();
        public List<IAbility> LegendaryAbilities { get; set; } = new();
        public Dictionary<string, double> AvgDamagePerClass { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? FilterResult { get; set; } // "Victory" o "Defeat"

        public StatsModel(HeroRepository repo, CsvStatsWriter statsWriter)
        {
            _repo = repo;
            _statsWriter = statsWriter;
        }

        public void OnGet()
        {
            AllHeroes = _repo.LoadAll();
            var allStats = _statsWriter.ReadAll();

            CombatHistory = string.IsNullOrEmpty(FilterResult)
                ? allStats
                : allStats.Where(s => (s.HeroWon && FilterResult == "Victory") ||
                                      (!s.HeroWon && FilterResult == "Defeat")).ToList();

            TopHeroes = HeroAnalytics.GetTopHeroesByLevel(AllHeroes, 3);

            HeroesByClass = AllHeroes.GroupBy(h => h.GetType().Name)
                                     .ToDictionary(g => g.Key, g => g.Count());

            AbilitiesByType = AllHeroes.SelectMany(h => h.Abilities)
                                       .GroupBy(a => a.Type.ToString())
                                       .ToDictionary(g => g.Key, g => g.Count());

            LegendaryAbilities = HeroAnalytics.GetAbilitiesByRarity(AllHeroes, Rarity.Legendary);

            AvgDamagePerClass = HeroAnalytics.GetAverageDamagePerClass(AllHeroes);
        }
    }
}