using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace HeroEngine.Core.Classes
    {
        public class CMage : AHeroes 
        {

            public int LvlArcane { get; set; }
            public int Mana { get; set; }

            public CMage (string name, int health, int lvl, int lvlArcane, int mana) : base(name, health, lvl)
            {
                LvlArcane = lvlArcane;
                Mana = mana;
            }

            public void Present()
            {
                Console.WriteLine($"Name:{Name}");
                Console.WriteLine($"Level:{Lvl}");
                Console.WriteLine($"Health:{Health}");
                Console.WriteLine($"Arcane level:{LvlArcane}");
                Console.WriteLine($"Mana:{Mana}");
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

}
