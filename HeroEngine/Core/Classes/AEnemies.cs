using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public abstract class AEnemies : ACombatant
    {
        public AEnemies(string name, int health, int lvl) : base(name, health, lvl)
        {
            //Recordemos que el constructor de la clase padre ACombatant se encarga
            //de inicializar los atributos Name, Health y Lvl,
            //por lo que no es necesario volver a declararlos aquí. Simplemente
            //llamamos al constructor de la clase padre con los parámetros correspondientes.
        }
    }
}
