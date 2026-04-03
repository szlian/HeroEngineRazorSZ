using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
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
        public override void Attack(AHeroes targeted, int damage)
        {
            Console.WriteLine($"{Name} ataca infligiendo {damage} de daño");

            targeted.TakeDamage(damage);
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = damage - Armor;
            if (reducedDamage < 0) reducedDamage = 0;
            Health -= reducedDamage; //poner -= es lo mismo que poner Health =
                                     //Health - reducedDamage

            /* el Health = Math.Max(0, Health) es lo mismo que el if (Health < 0)
            {
                Health = 0;
            }*/
            Health = Math.Max(0, Health);

            Console.WriteLine($"{Name} ha recibido {damage} de daño pero la armadura reduce {Armor}, vida restante: {Health}");
        }
    }
}
