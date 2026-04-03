using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.HeroEngine.Core.Classes;

public class Program
{
       public static void Main()
    {
        // Create instances of heroes
        CWarrior warrior1 = new CWarrior("King Denas", 120, 100, 120);
        warrior1.Present();

        CMage mage1 = new CMage("Vez'Nan", 80, 150, 30, 300);
        mage1.Present();

        // Simulate an attack
        warrior1.Attack(mage1, 90);
        mage1.Attack(warrior1, 120);
    }
}