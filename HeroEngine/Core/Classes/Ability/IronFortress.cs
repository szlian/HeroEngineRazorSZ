using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Hability
{
    /// <summary>
    /// Class inherited from AbilityBase, represents the "Iron Fortress" ability, which is a defensive ability
    /// that increases the hero's defense when activated, using the power of stones to strengthen the hero's body.
    /// </summary>
    public class IronFortress : AbilityBase
    {
        private int _defense = 30;
        public override string Name => "Iron Fortress";

        public override AbilityType Type => AbilityType.Defense;

        public override Rarity Rarity => Rarity.Epic;

        public override int Cost => 25;

        public override void ExecuteAbility(string heroName)
        {
            int defense = _defense + (int)Rarity;
            Console.WriteLine($"Activating '{Name}' {Rarity}...");
            Console.WriteLine($"{heroName} 's will becomes stronger, enhances the body with the power of the stones");
        }
    }
}