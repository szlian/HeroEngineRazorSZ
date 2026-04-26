// Fitxer: HeroEngine.Core/Models/CombatResult.cs
namespace HeroEngine.Core.Models
{
    /// <summary>
    /// Guarda el resum d'un combat. Serveix per omplir el CSV i el log.
    /// </summary>
    public class CombatResult
    {
        public DateTime Date { get; set; }
        public string HeroName { get; set; }
        public string EnemyName { get; set; }
        public bool HeroWon { get; set; }
        public int TotalRounds { get; set; }
        public int TotalDamageDealt { get; set; }
        public string MostEffectiveHero { get; set; }
    }
}