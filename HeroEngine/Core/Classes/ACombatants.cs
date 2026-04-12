using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    /// <summary>
    /// Base class that contains the common attributes and methods for all combatants,
    /// such as name, health, level, and functions to attack, check if alive, and take damage.
    /// All its children, heroes and enemies, must implement these behaviors.
    /// </summary>
    public abstract class ACombatant
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Lvl { get; set; }

        /// <summary>
        /// Constructor of the ACombatant class, responsible for initializing Name, Health, and Lvl.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public ACombatant(string name, int health, int lvl)
        {
            Name = name;
            Health = health * lvl;
            Lvl = lvl;
        }

        /// <summary>
        /// Function to check if the combatant is still alive, meaning its health is greater than 0.
        /// </summary>
        /// <returns>True if the combatant is alive, False otherwise.</returns>
        public bool IsAlive()
        {
            return Health > 0;
        }


        /// <summary>
        /// This function is used to attack. The target parameter specifies who will be attacked,
        /// and the damage parameter indicates the amount of damage to inflict.
        /// </summary>
        /// <param name="target">The combatant that will be attacked</param>
        public virtual void Attack(ACombatant target)
        {
            if (!IsAlive() || !target.IsAlive())
                return;

            int damage = CalculateDamage();

            target.TakeDamage(damage);
        }

        /// <summary>
        /// Calculates damage based on the level.
        /// </summary>
        /// <returns></returns>
        protected virtual int CalculateDamage()
        {
            return Lvl * 5;
        }

        /// <summary>
        /// The TakeDamage function handles receiving damage from an attack and subtracts it from the combatant's health.
        /// </summary>
        /// <param name="damage">The amount of damage received</param>
        public virtual void TakeDamage(int damage)
        {
            if (!IsAlive()) return;

            Health -= damage;
            Health = Math.Max(0, Health);
        }
    }
}