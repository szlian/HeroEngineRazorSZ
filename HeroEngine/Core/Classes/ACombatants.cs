using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public abstract class ACombatant
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Lvl { get; set; }

        public ACombatant(string name, int health, int lvl)
        {
            Name = name;
            Health = health * lvl;
            Lvl = lvl;
        }

        public bool IsAlive()
        {
            return Health > 0;
        }

        public abstract void Attack(ACombatant target, int damage);
        public abstract void TakeDamage(int damage);
    }
}
