using HeroEngine.Core.Classes;
using HeroEngine.Core.Classes.HeroEngine.Core.Classes;

public class Program
{
       public static void Main()
    {
        CWarrior warrior1 = new CWarrior("King Denas", 120, 100, 20);
        warrior1.Present();

        CMage mage1 = new CMage("Vez'Nan", 80, 150, 30, 300);
        mage1.Present();
    }
}