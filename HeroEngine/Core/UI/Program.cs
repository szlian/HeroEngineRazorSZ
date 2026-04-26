using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Enemies;
using HeroEngine.Core.Classes.Hability;
using HeroEngine.Core.Classes.HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.Heroes;
using HeroEngine.Core.Classes.Interface;
using HeroEngine.Core.Data;
using HeroEngine.Core.Combat;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("       HERO ENGINE TEST SUITE        ");
        Console.WriteLine("=====================================\n");

        // ================= HEROES =================
        Console.WriteLine("----- HERO CREATION TESTS -----");

        CWarrior warrior = new CWarrior("King Denas", 120, 1, 20);
        CRogue rogue = new CRogue("Luna", 100, 10);
        CMage mage = new CMage("Vez'Nan", 80, 1, 100, 300);

        warrior.Present();
        rogue.Present();
        mage.Present();

        // ================= ENEMIES =================
        Console.WriteLine("\n----- ENEMY CREATION TESTS -----");

        CBosses boss = new CBosses("Asgore", 150, 20);
        CMinions minion = new CMinions("Kortz", 50, 1);
        CElites elite = new CElites("Redd White", 120, 5);

        boss.Present();
        minion.Present();
        elite.Present();

        // ================= BASIC ATTACK TESTS =================
        Console.WriteLine("\n----- BASIC ATTACK TESTS -----");

        warrior.Attack(mage);
        mage.Attack(warrior);
        rogue.Attack(boss);

        Console.WriteLine($"\nAfter attacks:");
        Console.WriteLine($"Warrior HP: {warrior.Health}");
        Console.WriteLine($"Mage HP: {mage.Health}");
        Console.WriteLine($"Boss HP: {boss.Health}");

        // ================= ABILITY SYSTEM TESTS =================
        Console.WriteLine("\n----- ABILITY SYSTEM TESTS -----");

        warrior.AddAbility(new ThunderSmash());
        warrior.AddAbility(new IronFortress());
        warrior.AddAbility(new WarTaunt()); // duplicate test
        warrior.AddAbility(new WarTaunt()); // should be ignored

        Console.WriteLine("\n--- Warrior Ability List ---");
        warrior.ListAbilities();

        Console.WriteLine("\n--- Using Abilities ---");
        warrior.UseAbility("Thunder Smash");
        warrior.UseAbility("Iron Fortress");
        warrior.UseAbility("WarTaunt");

        // ================= EDGE CASE TESTS =================
        Console.WriteLine("\n----- EDGE CASE TESTS -----");

        Console.WriteLine("Testing invalid ability:");
        warrior.UseAbility("NonExistingAbility"); // should do nothing safely

        Console.WriteLine("\nTesting dead combatant:");
        mage.TakeDamage(9999);
        mage.Attack(warrior); // should not attack if dead

        Console.WriteLine($"Mage alive? {mage.IsAlive()}");

        // ================= TURN BATTLE TESTS =================
        Console.WriteLine("\n----- TURN BATTLE TESTS -----");

        CRogue duelRogue = new CRogue("Phoenix Wright", 100, 1);
        CBosses duelBoss = new CBosses("Flowey", 150, 5);

        duelRogue.Present();
        duelBoss.Present();

        CTurnBattle battle1 = new CTurnBattle(duelRogue, duelBoss);
        battle1.BattleStart();

        // ================= SECOND BATTLE =================
        Console.WriteLine("\n----- EPIC BATTLE 2 -----");

        CWarrior guts = new CWarrior("Sonaris", 150, 1, 25);
        CBosses doom = new CBosses("Doom", 200, 10);

        CTurnBattle battle2 = new CTurnBattle(guts, doom);
        battle2.BattleStart();

        // ================= FINAL SUMMARY =================
        Console.WriteLine("\n=====================================");
        Console.WriteLine("            TESTS FINISHED           ");
        Console.WriteLine("=====================================");


    }
}