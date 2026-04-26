using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Enums;
using HeroEngine.Core.Classes.Interface;
using System.Text.RegularExpressions;

namespace HeroEngine.Core.Analytics
{
    /// <summary>
    /// Classe amb consultes LINQ i Regex per analitzar els herois.
    /// </summary>
    public static class HeroAnalytics
    {
        public static List<AHeroes> GetTopHeroesByLevel(IEnumerable<AHeroes> heroes, int n)
            => heroes.OrderByDescending(h => h.Lvl).Take(n).ToList();

        public static List<IAbility> GetAbilitiesByRarity(IEnumerable<AHeroes> heroes, Rarity rarity)
            => heroes.SelectMany(h => h.Abilities)
                     .Where(a => a.Rarity == rarity)
                     .ToList();

        public static List<AHeroes> GetHeroesWithAbilityCount(IEnumerable<AHeroes> heroes, int min)
            => heroes.Where(h => h.Abilities.Count() >= min).ToList();

        public static List<AHeroes> SearchHeroesByName(IEnumerable<AHeroes> heroes, string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return heroes.Where(h => regex.IsMatch(h.Name)).ToList();
        }

        public static Dictionary<string, double> GetAverageDamagePerClass(IEnumerable<AHeroes> heroes)
        {
            // Calcula el dany base mitjà per classe utilitzant el mètode protegit CalculateDamage
            var result = new Dictionary<string, double>();
            var groups = heroes.GroupBy(h => h.GetType().Name);
            foreach (var g in groups)
            {
                double avg = g.Average(h =>
                {
                    // Invocar CalculateDamage via reflexió perquè és protected
                    var method = h.GetType().GetMethod("CalculateDamage",
                        System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (method != null)
                        return (int)method.Invoke(h, null)!;
                    return 0;
                });
                result[g.Key] = avg;
            }
            return result;
        }
    }
}