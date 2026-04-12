using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Hability
{
    /// <summary>
    /// Clase heredado de AbilityBase, representa la habilidad "Iron Fortress", que es una habilidad de
    /// defensa que aumenta la defensa del héroe al activarse
    /// utilizando el poder de las piedras para fortalecer el cuerpo del héroe.
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


