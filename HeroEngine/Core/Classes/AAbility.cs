using HeroEngine.Core.Classes.Enums;
using HeroEngine.Core.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{

    /// <summary>
    /// Defines the base functionality for an ability that can be used by a hero.
    /// </summary>
    /// <remarks>
    /// This abstract class provides the common interface for all abilities, including
    /// properties for name, type, rarity, and cost, as well as a method to execute the ability.
    /// </remarks>
    public abstract class AbilityBase : IAbility
    {
        public abstract string Name { get; }
        public abstract AbilityType Type { get; }
        public abstract Rarity Rarity { get; }
        public abstract int Cost { get; }


        /// <summary>
        /// This function is used to execute the ability, and it will be implemented in each child class.
        /// </summary>
        /// <param name="heroAName"></param>
        public abstract void ExecuteAbility(string heroAName);
    }
}