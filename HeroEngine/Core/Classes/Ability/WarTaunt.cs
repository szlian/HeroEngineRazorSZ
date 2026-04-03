using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Hability
{
    public class WarTaunt : AbilityBase
    {
        private int _agro = 20;
        public override string Name => "WarTaunt";

        public override AbilityType Type => AbilityType.Support;

        public override Rarity Rarity => Rarity.Common;

        public override int Cost => 5;

        public override void ExecuteAbility(string heroName)
        {
            int agro = _agro + (int)Rarity;
            Console.WriteLine($"Activating '{Name}' {Rarity}...");
            Console.WriteLine($"{heroName} Provoke all enemies");
        }
    }
}
