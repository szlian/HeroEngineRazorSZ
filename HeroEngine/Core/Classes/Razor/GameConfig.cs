using System.Xml.Linq;

namespace HeroEngine.Core.Data
{
    /// <summary>
    /// Llegeix i desa la configuració del joc des d'un fitxer XML.
    /// </summary>
    public class GameConfig
    {
        public double LevelMultiplier { get; set; } = 1.15;
        public double CriticalHitChance { get; set; } = 0.20;
        public int MaxCombatRounds { get; set; } = 20;
        public int MaxHeroesPerBattle { get; set; } = 4;

        public static GameConfig Load(string filePath)
        {
            var config = new GameConfig();
            if (!File.Exists(filePath)) return config;

            var doc = XDocument.Load(filePath);
            var root = doc.Element("GameConfig");
            if (root == null) return config;

            config.LevelMultiplier = double.TryParse(root.Element("LevelMultiplier")?.Value, out var lm) ? lm : 1.0;
            config.CriticalHitChance = double.TryParse(root.Element("CriticalHitChance")?.Value, out var cc) ? cc : 0.1;
            config.MaxCombatRounds = int.TryParse(root.Element("MaxCombatRounds")?.Value, out var mr) ? mr : 20;
            config.MaxHeroesPerBattle = int.TryParse(root.Element("MaxHeroesPerBattle")?.Value, out var mh) ? mh : 4;
            return config;
        }

        public void Save(string filePath)
        {
            var doc = new XDocument(
                new XElement("GameConfig",
                    new XElement("LevelMultiplier", LevelMultiplier),
                    new XElement("CriticalHitChance", CriticalHitChance),
                    new XElement("MaxCombatRounds", MaxCombatRounds),
                    new XElement("MaxHeroesPerBattle", MaxHeroesPerBattle)
                )
            );
            doc.Save(filePath);
        }
    }
}