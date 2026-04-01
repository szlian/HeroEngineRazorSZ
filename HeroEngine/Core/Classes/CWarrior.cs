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
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = damage - Armor;
            Console.WriteLine($"{Name} ha recibido {damage} de daño pero la armadura reduce {reducedDamage}, vida restante: {Health}");
        }
    }
}
