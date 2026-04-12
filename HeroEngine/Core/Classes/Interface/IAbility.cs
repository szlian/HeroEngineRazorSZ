using HeroEngine.Core.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Interface
{

    /// <summary>
    /// El interfaz de IAbility define la funcionalidad base para una habilidad que puede ser utilizada por un héroe, incluyendo propiedades para el nombre, tipo, rareza y coste, así como un método para ejecutar la habilidad.
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
