using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public class CRogue : AHeroes
    {
        public CRogue(string name, int health, int lvl) : base(name, health, lvl)
        {

        }

        public void Present()
        {
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Level:{Lvl}");
            Console.WriteLine($"Health:{Health}");

        }

        //metodos
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = damage;
            Console.WriteLine($"{Name} ha recibido {damage} de daño pero la armadura reduce {reducedDamage}, vida restante: {Health}");
        }
    }
}
