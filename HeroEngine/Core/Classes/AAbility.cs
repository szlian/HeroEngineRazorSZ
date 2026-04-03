using HeroEngine.Core.Classes.Enums;
using HeroEngine.Core.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public abstract class AbilityBase : IAbility
    {
        public abstract string Name { get; }
        public abstract AbilityType Type { get; }
        public abstract Rarity Rarity { get; }
        public abstract int Cost { get; }

        public abstract void ExecuteAbility(string heroAName);
    }
}
