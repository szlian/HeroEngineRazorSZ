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
    /// Define la funcionalidad base para una habilidad que puede ser utilizada por un héroe
    /// </summary>
    /// <remarks>Esta clase abstracta proporciona la interfaz común para todas las habilidades, incluyendo
    /// propiedades para el nombre, tipo, rareza y coste, así como un método para ejecutar la habilidad</remarks>
    public abstract class AbilityBase : IAbility
    {
        public abstract string Name { get; }
        public abstract AbilityType Type { get; }
        public abstract Rarity Rarity { get; }
        public abstract int Cost { get; }


        /// <summary>
        /// Este funcion es para ejecutar la habilidad, y se implementará en cada clase hijo
        /// </summary>
        /// <param name="heroAName"></param>
        public abstract void ExecuteAbility(string heroAName);
    }
}
