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

        /// <summary>
        /// The CMage class represents a mage hero in the game. It inherits from the AHeroes class.
        /// </summary>
        public class CMage : AHeroes
        {

            public int LvlArcane { get; set; }
            public int Mana { get; set; }

            public CMage(string name, int health, int lvl, int lvlArcane, int mana) : base(name, health, lvl)
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



        }
    }
}