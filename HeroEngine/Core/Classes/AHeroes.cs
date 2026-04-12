using HeroEngine.Core.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{

    /// <summary>
    /// Clase heredado de ACombatant, representa a los héroes del juego, y tiene un diccionario para almacenar sus habilidades,
    /// </summary>
    public abstract class AHeroes : ACombatant
    {
        // Dictionary para almacenar las habilidades del héroe, con el nombre de la habilidad como clave
        private Dictionary<string, IAbility> abilities = new Dictionary<string, IAbility>();


        /// <summary>
        /// La funcion AddAbility se encarga de agregar una habilidad al héroe, verificando primero si el
        /// héroe ya tiene una habilidad con el mismo nombre para evitar duplicados. 
        /// Si la habilidad no existe, se agrega al diccionario de habilidades del héroe utilizando el nombre de la habilidad como clave.
        /// </summary>
        /// <param name="ability">La habilidad que se desea agregar al héroe</param>
        public void AddAbility(IAbility ability)
        {
            //El ConstainsKey verifica si el diccionario ya contiene una habilidad con el mismo nombre, evitando así agregar habilidades duplicadas
            if (!abilities.ContainsKey(ability.Name))
            {
                abilities.Add(ability.Name, ability);
            }
        }


        /// <summary>
        /// Muestra una lista de las habilidades del héroe ordenadas por rareza, desde la más rara hasta la más común.
        /// </summary>
        public void ListAbilities()
        {
            var ordered = abilities.Values.OrderByDescending(a => a.Rarity);

            //Este foreach recorre la lista de habilidades ordenadas y muestra su información, incluyendo la rareza, el nombre, el tipo y el costo de cada habilidad
            foreach (var a in ordered)
            {
                Console.WriteLine($"[{a.Rarity}] {a.Name} | Type: {a.Type} | Cost: {a.Cost}");
            }
        }


        /// <summary>
        /// La funcion de UseAbility se encarga de ejecutar una habilidad específica del héroe, identificada por su nombre.
        /// </summary>
        /// <param name="abilityName">El nombre de la habilidad que se desea ejecutar</param>
        public void UseAbility(string abilityName)
        {
            //El TryGetValue intenta obtener la habilidad del diccionario utilizando el nombre proporcionado, y si la habilidad existe, se ejecuta su método ExecuteAbility pasando el nombre del héroe como argumento
            if (abilities.TryGetValue(abilityName, out IAbility ability))
            {
                //En vez de solo Name, pasemos todo el héroe, para que la habilidad pueda interactuar con las propiedades del héroe, como su salud, nivel, etc.
                ability.ExecuteAbility(this.Name);
            }
        }

        //esto lo tenia declarado ya que AHeroes antes era el clase padre,
        //ahora lo oculto porque ya se esta accediendo a otra clase padre, el ACombatant



        /// <summary>
        /// El constructor de la clase AHeroes se encarga de inicializar los atributos heredados de la clase ACombatant, como el nombre, la salud y el nivel del héroe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="lvl"></param>
        public AHeroes (string name, int health, int lvl) : base(name, health, lvl)
        {
            /*Ignoramos atributo ya que el padre ya se encarga de inicializarlo, y lo hacemos con el base para llamar al constructor de la clase padre
            Name = name;
            Health = health * lvl ;
            Lvl = lvl;
            */

        }

    }
}
