using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Hability;
using HeroEngine.Core.Classes.HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Heroes;
using HeroEngine.Core.Classes.Enemies;

using HeroEngine.Core.Classes.Interface;

public class Program
{
       public static void Main()
    {
        // Create instances of heroes
        CWarrior warrior1 = new CWarrior("King Denas", 120, 1, 120);
        warrior1.Present();
        CRogue rogue1 = new CRogue("Luna", 100, 10);
        rogue1.Present();
        // Create instances of enemies
        CBosses boss1 = new CBosses("Asgore", 150, 20);
        boss1.Present();

        CMage mage1 = new CMage("Vez'Nan", 80, 1, 100, 300);
        mage1.Present();

        // Simulate an attack
        Console.WriteLine("-------- Attack Heroes Phase -------");
        warrior1.Attack(mage1);
        mage1.Attack(warrior1);
        rogue1.Attack(boss1);

        Console.WriteLine("-------- Attack Enemy Phase -------");
        warrior1.Attack(boss1);

        // Create an instance of an ability
        Console.WriteLine("-----------------------------------");
        IAbility ability1 = new ThunderSmash();
        IAbility ability2 = new IronFortress();
        IAbility ability3 = new WarTaunt();
        IAbility ability4 = new SecondWind();


        warrior1.AddAbility(ability1);
        warrior1.AddAbility(ability2);
        Console.WriteLine("-----------Hability List -----------");
        warrior1.ListAbilities();
        Console.WriteLine("-------------------------------------");

        // Use the ability

        warrior1.UseAbility("Thunder Smash");
        warrior1.UseAbility("Iron Fortress");


        CRogue Rogue1 = new CRogue ("Phoenix Wright", 100, 1);
        CBosses Boss2 = new CBosses ("Flowey", 150, 50);

        CWarrior Warrior2 = new CWarrior ("Guts", 150, 1, 150);
        CBosses Boss3 = new CBosses ("Doom", 200, 70);

        //Duelo entre Rogue1 y Boss2, 1 vs 1
        /*Console.WriteLine("----------- Duel Phase, fight for your honor ------------");
        CTurnBattle battle = new CTurnBattle(Rogue1, Boss2);
        Rogue1.Present();
        Boss2.Present();
        battle.BattleStart(100, 30);*/
        Console.WriteLine("----------- Duel Phase, fight for your honor ------------");
        CTurnBattle battle2 = new CTurnBattle(rogue1, Boss3);
        rogue1.Present();
        Boss3.Present();
        battle2.BattleStart();
    }
}