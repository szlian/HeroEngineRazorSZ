using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Hability
{
    /// <summary>
    /// Clase heredado de AbilityBase, representa la habilidad "Second Wind"
    /// </summary>
    public class SecondWind : AbilityBase
    {
        private int _healing = 50;
        public override string Name => "Second Wind";

        public override AbilityType Type => AbilityType.Healing;

        public override Rarity Rarity => Rarity.Rare;

        public override int Cost => 15;

        public override void ExecuteAbility(string heroName)
        {
            int healing = _healing + (int)Rarity;
            Console.WriteLine($"Activating '{Name}' {Rarity}...");
            Console.WriteLine($"{heroName} Heals an ally granting the nature blessing");
        }
    }
}
