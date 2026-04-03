using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Heroes
{
    public class CWarrior: AHeroes
    {
        public int Armor { get; set; }
        public CWarrior(string name, int health, int lvl, int armor) : base (name, health, lvl)
        {
            Armor = armor;
        }

        public void Present()
        {
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Level:{Lvl}");
            Console.WriteLine($"Health:{Health}");
            Console.WriteLine($"Armor:{Armor}");

            Console.WriteLine("Battle cry: Come on, you wanna live forever?");
        }

        //metodos
        public override void Attack(ACombatant target, int damage)
        {
            if (!IsAlive())
            {
                Console.WriteLine($"{Name} está derrotado y no puede atacar");
                return;
            }

            if (!target.IsAlive())
            {
                Console.WriteLine($"{target.Name} ya está derrotado");
                return;
            }

            Console.WriteLine($"{Name} ataca infligiendo {damage} de daño");
            target.TakeDamage(damage);
        }

        //poner -= es lo mismo que poner Health =
        //Health - reducedDamage

        /* el Health = Math.Max(0, Health) es lo mismo que el if (Health < 0)
        {
            Health = 0;
        }*/
        public override void TakeDamage(int damage)
        {
            if (!IsAlive())
                return;

            Health -= damage;
            Health = Math.Max(0, Health);

            Console.WriteLine($"{Name} ha recibido {damage} de daño, vida restante: {Health}");
        }
    
    }
}
