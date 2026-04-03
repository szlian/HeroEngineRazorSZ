using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Classes
{
    public abstract class AHeroes
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Lvl { get; set; }

        //constructor
        public AHeroes(string name, int health, int lvl)
        {
            Name = name;
            Health = health;
            Lvl = lvl;
        }
        
        public abstract void Attack(AHeroes targeted, int damage);
        public abstract void TakeDamage(int damage);


    }
}
