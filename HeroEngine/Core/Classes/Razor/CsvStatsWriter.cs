// Fitxer: HeroEngine.Core/Data/CsvStatsWriter.cs
using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HeroEngine.Core.Data
{
    public class CsvStatsWriter
    {
        private readonly string _filePath;

        public CsvStatsWriter(string filePath) => _filePath = filePath;

        public void AppendCombatStats(CombatResult result)
        {
            bool exists = File.Exists(_filePath);
            using var writer = new StreamWriter(_filePath, append: true);
            if (!exists)
            {
                // capçalera del CSV
                writer.WriteLine("Date,Hero,Enemy,Result,Rounds,TotalDamage,MostEffective");
            }
            writer.WriteLine($"{result.Date:yyyy-MM-dd HH:mm}," +
                             $"{result.HeroName},{result.EnemyName}," +
                             $"{(result.HeroWon ? "Victory" : "Defeat")}," +
                             $"{result.TotalRounds},{result.TotalDamageDealt},{result.MostEffectiveHero}");
        }

        public List<CombatResult> ReadAll()
        {
            var results = new List<CombatResult>();
            if (!File.Exists(_filePath)) return results;

            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines.Skip(1)) // saltem capçalera
            {
                var parts = line.Split(',');
                if (parts.Length >= 7)
                {
                    results.Add(new CombatResult
                    {
                        Date = DateTime.Parse(parts[0]),
                        HeroName = parts[1],
                        EnemyName = parts[2],
                        HeroWon = parts[3] == "Victory",
                        TotalRounds = int.Parse(parts[4]),
                        TotalDamageDealt = int.Parse(parts[5]),
                        MostEffectiveHero = parts[6]
                    });
                }
            }
            return results;
        }
    }
}