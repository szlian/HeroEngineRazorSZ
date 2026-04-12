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

        /// <summary>
        /// El método espera los dos daños que se usarán en cada turno, el turno se alternará entre el héroe y el enemigo, y cada uno atacará al otro utilizando el daño especificado. El método continuará hasta que uno de los combatientes quede sin salud, momento en el cual se declarará al ganador. Además, después de cada ataque, 
        /// se mostrará la salud actual de ambos combatientes para que el jugador pueda seguir el progreso de la batalla.
        /// </summary>
        /// <param name="heroDamage">El daño que infligirá el héroe en su turno</param>
        /// <param name="enemyDamage">El daño que infligirá el enemigo en su turno</param>
        public void BattleStart()
        {
            int turno = 1; // 1 = héroe, 2 = enemigo

            while (heroe.IsAlive() && enemigo.IsAlive())
            {
                if (turno == 1)
                {
                    Console.WriteLine($"\n{heroe.Name} ataca!");
                    heroe.Attack(enemigo);
                    turno = 2;
                }
                else
                {
                    Console.WriteLine($"\n{enemigo.Name} ataca!");
                    enemigo.Attack(heroe);
                    turno = 1;
                }

                Console.WriteLine($"Heroe vida: {heroe.Health} | Enemigo vida: {enemigo.Health}");
                Console.ReadLine(); // pausa para ver el resultado
            }

            Console.WriteLine(heroe.IsAlive() ? "¡Has ganadi :]" : "Perdiste :[");
        }
    }
}

