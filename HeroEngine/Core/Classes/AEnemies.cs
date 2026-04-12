using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{

    /// <summary>
    /// Clase hijo de ACombatant, a diferencia de los heroes de momento al menos no tienene habilidades
    /// </summary>
    public abstract class AEnemies : ACombatant
    {

        /// <summary>
        /// Constructor de la clase AEnemies, se encarga de inicializar los atributos Name, Health y Lvl utilizando el constructor de la clase padre ACombatant
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public AEnemies(string name, int health, int lvl) : base(name, health, lvl)
        {
            //Recordar que el constructor de la clase padre ACombatant se encarga
            //de inicializar los atributos Name, Health y Lvl,
            //por lo que no es necesario volver a declararlos aquí. Simplemente
            //llamamos al constructor de la clase padre con los parámetros correspondientes.
        }
    }
}
