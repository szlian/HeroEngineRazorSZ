using System;

namespace HeroEngine.Core.Classes
{
    public class CTurnBattle
    {
        private AHeroes heroe;
        private AEnemies enemigo;

        public CTurnBattle(AHeroes heroe, AEnemies enemigo)
        {
            this.heroe = heroe;
            this.enemigo = enemigo;
        }

        // El método espera los dos daños que se usarán en cada turno
        public void BattleStart(int heroDamage, int enemyDamage)
        {
            int turno = 1; // 1 = héroe, 2 = enemigo

            while (heroe.IsAlive() && enemigo.IsAlive())
            {
                if (turno == 1)
                {
                    Console.WriteLine($"\n{heroe.Name} ataca!");
                    heroe.Attack(enemigo, heroDamage);
                    turno = 2;
                }
                else
                {
                    Console.WriteLine($"\n{enemigo.Name} ataca!");
                    enemigo.Attack(heroe, enemyDamage);
                    turno = 1;
                }

                Console.WriteLine($"Heroe vida: {heroe.Health} | Enemigo vida: {enemigo.Health}");
                Console.ReadLine(); // pausa para ver el resultado
            }

            Console.WriteLine(heroe.IsAlive() ? "¡Has ganadi :]" : "Perdiste :[");
        }
    }
}