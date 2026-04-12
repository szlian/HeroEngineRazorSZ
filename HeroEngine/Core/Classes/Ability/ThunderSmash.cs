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
    /// Class inherited from AbilityBase, represents the "Thunder Smash" ability.
    /// </summary>
    public class ThunderSmash : AbilityBase
    {
        private int _damage = 95;
        public override string Name => "Thunder Smash";

        public override AbilityType Type => AbilityType.Attack;

        public override Rarity Rarity => Rarity.Legendary;

        public override int Cost => 40;

        public override void ExecuteAbility(string heroName)
        {
            int damage = _damage + (int)Rarity;

            Console.WriteLine($"Activating {Name} '' {Rarity}...");
            Console.WriteLine($"{heroName} channels the storm! {damage} lightning damage to all enemies!");
        }
    }
}