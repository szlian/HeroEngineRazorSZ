using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Interface
{

    /// <summary>
    /// The IAbility interface defines the base functionality for an ability that can be used by a hero, including properties for name, type, rarity, and cost, as well as a method to execute the ability.
    /// </summary>
    public interface IAbility
    {
        string Name { get; }
        AbilityType Type { get; }
        Rarity Rarity { get; }
        int Cost { get; }

        void ExecuteAbility(string heroName);
    }
}