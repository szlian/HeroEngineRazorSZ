using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Interface
{
    public interface IAbility
    {
        string Name { get; }
        AbilityType Type { get; }
        Rarity Rarity { get; }
        int Cost { get; }

        void ExecuteAbility(string heroName);
    }
}
