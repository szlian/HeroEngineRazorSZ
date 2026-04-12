using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes.Enemies
{
    /// <summary>
    /// La clase CBosses representa a los jefes enemigos en el juego. Hereda de la clase AEnemies
    /// </summary>
    public class CBosses : AEnemies
    {

        /// <summary>
        /// Constructor de la clase CBosses, se encarga de inicializar los atributos Name, Health y Lvl utilizando el constructor de la clase padre AEnemies
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public CBosses(string name, int health, int lvl) : base(name, health, lvl)
        {
        }
        public void Present()
        {
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Level:{Lvl}");
            Console.WriteLine($"Health:{Health}");
        }
    }
}

