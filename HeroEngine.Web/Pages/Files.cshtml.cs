using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages
{
    public class FilesModel : PageModel
    {
        private readonly CombatLogWriter _logWriter;
        private readonly CsvStatsWriter _statsWriter;
        private readonly GameConfig _config;
        private readonly string _configPath;

        public string CombatLogText { get; set; } = "";
        public List<CombatResult> CombatStats { get; set; } = new();

        [BindProperty]
        public double LevelMultiplier { get; set; }
        [BindProperty]
        public double CriticalHitChance { get; set; }
        [BindProperty]
        public int MaxCombatRounds { get; set; }
        [BindProperty]
        public int MaxHeroesPerBattle { get; set; }

        public FilesModel(CombatLogWriter logWriter, CsvStatsWriter statsWriter, GameConfig config)
        {
            _logWriter = logWriter;
            _statsWriter = statsWriter;
            _config = config;
            _configPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "game_config.xml");
        }

        public void OnGet()
        {
            CombatLogText = _logWriter.ReadAllText();
            CombatStats = _statsWriter.ReadAll()
                                      .OrderByDescending(s => s.Date)
                                      .Take(10)
                                      .ToList();

            LevelMultiplier = _config.LevelMultiplier;
            CriticalHitChance = _config.CriticalHitChance;
            MaxCombatRounds = _config.MaxCombatRounds;
            MaxHeroesPerBattle = _config.MaxHeroesPerBattle;
        }

        public IActionResult OnPostConfig()
        {
            _config.LevelMultiplier = LevelMultiplier;
            _config.CriticalHitChance = CriticalHitChance;
            _config.MaxCombatRounds = MaxCombatRounds;
            _config.MaxHeroesPerBattle = MaxHeroesPerBattle;
            _config.Save(_configPath);
            return RedirectToPage();
        }
    }
}