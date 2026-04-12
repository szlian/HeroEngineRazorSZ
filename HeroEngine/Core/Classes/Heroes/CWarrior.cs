using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Heroes
{
    // Using AHeroes instead of ACombatants is because AHeroes inherits from ACombatants,
    // so you can use the methods from ACombatants in AHeroes,
    // but not the other way around, since ACombatants does not have the methods of AHeroes.


    /// <summary>
    /// The CWarrior class represents a warrior hero in the game. It inherits from the AHeroes class.
    /// </summary>
    public class CWarrior : AHeroes
    {
        public int Armor { get; set; }

        public CWarrior(string name, int health, int lvl, int armor) : base(name, health, lvl)
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

        // Using -= is the same as writing Health = Health - reducedDamage

        /* Health = Math.Max(0, Health) is the same as:
        if (Health < 0)
        {
            Health = 0;
        }*/
        public override void TakeDamage(int damage)
        {
            if (!IsAlive()) return;

            // Damage reduction from armor (for example, subtract armor, minimum 1 damage)
            int reducedDamage = Math.Max(1, damage - Armor);
            Health -= reducedDamage;
            Health = Math.Max(0, Health);

            Console.WriteLine($"{Name} takes {reducedDamage} damage (armor {Armor} reduced {damage - reducedDamage}). Remaining health: {Health}");
        }

    }
}