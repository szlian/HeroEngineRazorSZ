using System.Text;
using HeroEngine.Core.Models;
using HeroEngine.Core.Classes;

namespace HeroEngine.Core.Combat
{
    /// <summary>
    /// Servei de combat que retorna un log i un CombatResult,
    /// sense dependre de la consola.
    /// </summary>
    public class CombatService
    {
        public (string Log, CombatResult Result) Simulate(ACombatant hero, ACombatant enemy)
        {
            var log = new StringBuilder();
            var result = new CombatResult
            {
                Date = DateTime.Now,
                HeroName = hero.Name,
                EnemyName = enemy.Name
            };

            int turno = 1, rounds = 0, totalDamage = 0;

            while (hero.IsAlive() && enemy.IsAlive())
            {
                rounds++;
                if (turno == 1)
                {
                    log.AppendLine($"{hero.Name} attacks!");
                    // Guardem la salut de l'enemic abans de l'atac per calcular el dany
                    int hpBefore = enemy.Health;
                    hero.Attack(enemy);
                    int damageDealt = hpBefore - enemy.Health;
                    totalDamage += damageDealt;
                    turno = 2;
                }
                else
                {
                    log.AppendLine($"{enemy.Name} attacks!");
                    enemy.Attack(hero);
                    turno = 1;
                }
                log.AppendLine($"Hero health: {hero.Health} | Enemy health: {enemy.Health}");
            }

            log.AppendLine(hero.IsAlive() ? "You won :]" : "You lost :[");
            result.HeroWon = hero.IsAlive();
            result.TotalRounds = rounds;
            result.TotalDamageDealt = totalDamage;
            result.MostEffectiveHero = hero.Name; // en 1vs1 sempre és l'heroi

            return (log.ToString(), result);
        }
    }
}