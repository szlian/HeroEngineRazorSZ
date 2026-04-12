using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{

    /// <summary>
    /// Child class of ACombatant. Unlike heroes, at least for now, they do not have abilities.
    /// </summary>
    public abstract class AEnemies : ACombatant
    {

        /// <summary>
        /// Constructor of the AEnemies class, responsible for initializing Name, Health, and Lvl using the base class (ACombatant) constructor.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public AEnemies(string name, int health, int lvl) : base(name, health, lvl)
        {
            // Remember that the constructor of the parent class ACombatant is responsible
            // for initializing the Name, Health, and Lvl attributes,
            // so it is not necessary to redeclare them here. We simply
            // call the base class constructor with the corresponding parameters.
        }
    }
}