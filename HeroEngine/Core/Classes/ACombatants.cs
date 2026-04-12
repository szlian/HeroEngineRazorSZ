using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    /// <summary>
    /// Clase padre, tiene los atributos y métodos comunes para todos los combatientes, 
    /// como el nombre, la salud, el nivel, y las funciones para atacar, saber si esta vivo y recibir daño
    /// todo sus hijos, los heroes y los enemigos deberan de implementar 
    /// </summary>
    public abstract class ACombatant
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Lvl { get; set; }

        /// <summary>
        /// Constructor de la clase ACombatant, se encarga de inicializar los atributos Name, Health y Lvl
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public ACombatant(string name, int health, int lvl)
        {
            Name = name;
            Health = health * lvl;
            Lvl = lvl;
        }

        /// <summary>
        /// Funcion para verificar si el combatiente sigue vivo, es decir, si su salud es mayor a 0
        /// </summary>
        /// <returns>True si el combatiente sigue vivo, False en caso contrario </returns>
        public bool IsAlive()
        {
            return Health > 0;
        }


        /// <summary>
        /// Este funcion sirve para atacar, el variable target es para elegir a quien atacar,
        /// y el parametro damage indica la cantidad de daño que se desea infligir.
        /// </summary>
        /// <param name="target">El combatiente que será atacado</param>
        public virtual void Attack(ACombatant target)
        {
            if (!IsAlive() || !target.IsAlive())
                return;

            int damage = CalculateDamage();

            target.TakeDamage(damage);
        }

        /// <summary>
        /// Calcular el daño a proporcion del nivel
        /// </summary>
        /// <returns></returns>
        protected virtual int CalculateDamage()
        {
            return Lvl * 5;
        }
        /// <summary>
        /// La funcion TakeDamage se encarga de recibir el daño infligido por un ataque, y restarlo a la salud del combatiente.
        /// </summary>
        /// <param name="damage">La cantidad de daño que se recibe</param>
        public virtual void TakeDamage(int damage)
        {
            if (!IsAlive()) return;

            Health -= damage;
            Health = Math.Max(0, Health);
        }
    }
}
