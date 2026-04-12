using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Enemies
{
    /// <summary>
    /// The CElites class represents elite enemies in the game. It inherits from the AEnemies class.
    /// </summary>
    public class CElites : AEnemies
    {

        /// <summary>
        /// Constructor of the CElites class, responsible for initializing the Name, Health, and Lvl attributes using the base class (AEnemies) constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public CElites(string name, int health, int lvl) : base(name, health, lvl)
        {
        }

        public void Present()
        {
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Level:{Lvl}");
            Console.WriteLine($"Health:{Health}");
        }

    }
}