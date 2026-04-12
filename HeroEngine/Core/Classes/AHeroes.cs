using HeroEngine.Core.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    /// <summary>
    /// Class inherited from ACombatant, represents the heroes in the game, and contains a dictionary to store their abilities.
    /// </summary>
    public abstract class AHeroes : ACombatant
    {
        // Dictionary to store the hero's abilities, using the ability name as the key
        private Dictionary<string, IAbility> abilities = new Dictionary<string, IAbility>();


        /// <summary>
        /// The AddAbility function adds an ability to the hero, first checking if the hero already has
        /// an ability with the same name to avoid duplicates.
        /// If the ability does not exist, it is added to the hero's ability dictionary using the ability name as the key.
        /// </summary>
        /// <param name="ability">The ability to be added to the hero</param>
        public void AddAbility(IAbility ability)
        {
            // ContainsKey checks if the dictionary already contains an ability with the same name, preventing duplicates
            if (!abilities.ContainsKey(ability.Name))
            {
                abilities.Add(ability.Name, ability);
            }
        }


        /// <summary>
        /// Displays a list of the hero's abilities ordered by rarity, from rarest to most common.
        /// </summary>
        public void ListAbilities()
        {
            var ordered = abilities.Values.OrderByDescending(a => a.Rarity);

            // This foreach iterates through the ordered abilities list and displays their information, including rarity, name, type, and cost
            foreach (var a in ordered)
            {
                Console.WriteLine($"[{a.Rarity}] {a.Name} | Type: {a.Type} | Cost: {a.Cost}");
            }
        }


        /// <summary>
        /// The UseAbility function executes a specific ability of the hero, identified by its name.
        /// </summary>
        /// <param name="abilityName">The name of the ability to execute</param>
        public void UseAbility(string abilityName)
        {
            // TryGetValue attempts to retrieve the ability from the dictionary using the provided name, and if it exists, it executes its ExecuteAbility method passing the hero's name as an argument
            if (abilities.TryGetValue(abilityName, out IAbility ability))
            {
                // Instead of just Name, we pass the whole hero, so the ability can interact with the hero's properties such as health, level, etc.
                ability.ExecuteAbility(this.Name);
            }
        }

        // This was previously declared because AHeroes used to be the parent class,
        // now it is hidden because we are already using another parent class, ACombatant.


        /// <summary>
        /// The constructor of the AHeroes class initializes the attributes inherited from the ACombatant class, such as name, health, and level of the hero.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public AHeroes(string name, int health, int lvl) : base(name, health, lvl)
        {
            /* We ignore attributes here because the parent already handles initialization,
            and we use base to call the parent class constructor.

            Name = name;
            Health = health * lvl ;
            Lvl = lvl;
            */
        }

    }
}