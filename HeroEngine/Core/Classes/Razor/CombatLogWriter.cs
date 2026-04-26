using HeroEngine.Core.Models;

namespace HeroEngine.Core.Data
{
    /// <summary>
    /// Gestiona el log de combat en fitxer de text (.txt).
    /// </summary>
    public class CombatLogWriter
    {
        private readonly string _filePath;

        public CombatLogWriter(string filePath) => _filePath = filePath;

        public void AppendLog(string logText, CombatResult result)
        {
            using var writer = new StreamWriter(_filePath, append: true);
            writer.WriteLine("==============================");
            writer.WriteLine($"Combat Date: {result.Date:yyyy-MM-dd HH:mm}");
            writer.WriteLine($"{result.HeroName} vs {result.EnemyName}");
            writer.WriteLine($"Result: {(result.HeroWon ? "Victory" : "Defeat")}");
            writer.WriteLine("==============================");
            writer.WriteLine(logText);
            writer.WriteLine();
        }

        public string ReadAllText()
        {
            if (!File.Exists(_filePath)) return "No s'ha registrat cap combat.";
            return File.ReadAllText(_filePath);
        }
    }
}