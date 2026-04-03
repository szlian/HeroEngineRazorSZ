using HeroEngine.Core.Classes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public abstract class AHeroes : ACombatant
    {
        // Dictionary para almacenar las habilidades del héroe, con el nombre de la habilidad como clave
        private Dictionary<string, IAbility> abilities = new Dictionary<string, IAbility>();


        // Este método permite agregar una habilidad al héroe, asegurándose de que no se dupliquen habilidades con el mismo nombre
        public void AddAbility(IAbility ability)
        {
            //El ConstainsKey verifica si el diccionario ya contiene una habilidad con el mismo nombre, evitando así agregar habilidades duplicadas
            if (!abilities.ContainsKey(ability.Name))
            {
                abilities.Add(ability.Name, ability);
            }
        }

        // Este método lista las habilidades del héroe ordenadas por rareza de mayor a menor, mostrando su nombre, tipo y costo
        public void ListAbilities()
        {
            var ordered = abilities.Values.OrderByDescending(a => a.Rarity);

            //Este foreach recorre la lista de habilidades ordenadas y muestra su información formateada, incluyendo la rareza en mayúsculas, el nombre, el tipo y el costo de cada habilidad
            foreach (var a in ordered)
            {
                Console.WriteLine($"[{a.Rarity}] {a.Name} | Type: {a.Type} | Cost: {a.Cost}");
            }
        }

        // Este sirve para ejecutar una habilidad específica del héroe, buscando la habilidad por su nombre y llamando a su método de ejecución
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
    


        //constructor
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
