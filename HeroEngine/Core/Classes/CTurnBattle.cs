using System;

namespace HeroEngine.Core.Classes
{
    public class CTurnBattle
    {
        private AHeroes heroe;
        private AEnemies enemy;

        public CTurnBattle(AHeroes heroe, AEnemies enemigo)
        {
            this.heroe = heroe;
            this.enemy = enemigo;
        }

        /// <summary>
        /// This function BattleStart is used to start the turn-based battle between the hero and the enemy.
        /// </summary>
        public void BattleStart()
        {
            int turno = 1; // 1 = hero, 2 = enemy

            while (heroe.IsAlive() && enemy.IsAlive())
            {
                if (turno == 1)
                {
                    Console.WriteLine($"\n{heroe.Name} attacks!");
                    heroe.Attack(enemy);
                    turno = 2;
                }
                else
                {
                    Console.WriteLine($"\n{enemy.Name} attacks!");
                    enemy.Attack(heroe);
                    turno = 1;
                }

                Console.WriteLine($"Hero health: {heroe.Health} | Enemy health: {enemy.Health}");
                Console.ReadLine(); // pause to see the result
            }

            Console.WriteLine(heroe.IsAlive() ? "You won :]" : "You lost :[");
        }
    }
}