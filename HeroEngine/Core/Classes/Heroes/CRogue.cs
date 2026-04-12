using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Heroes
{
    /// <summary>
    /// The CRogue class represents a rogue hero in the game. It inherits from the AHeroes class.
    /// </summary>
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

        protected override int CalculateDamage()
        {
            return Lvl * 6 + 20; // rogue critical damage
        }
    }
}
