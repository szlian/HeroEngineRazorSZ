using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Hability;
using HeroEngine.Core.Classes.HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Heroes;
using HeroEngine.Core.Classes.Interface;

public class Program
{
       public static void Main()
    {
        // Create instances of heroes
        CWarrior warrior1 = new CWarrior("King Denas", 120, 1, 120);
        warrior1.Present();

        CMage mage1 = new CMage("Vez'Nan", 80, 1, 100, 300);
        mage1.Present();

        // Simulate an attack
        warrior1.Attack(mage1, 90);
        mage1.Attack(warrior1, 120);

        // Create an instance of an ability
        Console.WriteLine("-----------------------------------");
        IAbility ability1 = new ThunderSmash();
        IAbility ability2 = new IronFortress();
        IAbility ability3 = new WarTaunt();
        IAbility ability4 = new SecondWind();


        warrior1.AddAbility(ability1);
        warrior1.AddAbility(ability2);
        Console.WriteLine("----------------------------------------");
        warrior1.ListAbilities();
        Console.WriteLine("-------------------------------------");

        // Use the ability

        warrior1.UseAbility("Thunder Smash");
        warrior1.UseAbility("Iron Fortress");
    }
}