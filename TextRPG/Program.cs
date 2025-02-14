using System;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text RPG Start");
            Console.WriteLine("Press escape to exit...");
            var escape = Console.ReadKey(intercept: true);
            var start = Console.ReadKey(intercept: true);
            if (escape.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Text RPG End");
            }
            else if (start.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("Text RPG Start");
                Console.WriteLine("Please name your character");
                string name = Console.ReadLine();
                FixTitle();
                Character player = new Character();
                player.name = name;
                var introduce = Console.ReadKey(intercept: true);
                while (true)
                {
                    if (introduce.Key == ConsoleKey.I)
                    {
                        Console.Clear();
                        Console.WriteLine("Name: " + player.name);
                        Console.WriteLine("Lv: " + player.Lv);
                        Console.WriteLine("Exp: " + player.Exp);
                        Console.WriteLine("Hp: " + player.Hp);
                        Console.WriteLine("Mp: " + player.Mp);
                        Console.WriteLine("Atk: " + player.Atk);
                        Console.WriteLine("Def: " + player.Def);
                        Console.WriteLine("Gold: " + player.Gold);
                        Console.WriteLine("Armor: " + player.armor);
                        Console.WriteLine("Weapon: " + player.weapon);
                        while (true)
                        {
                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                            {
                                FixTitle();
                                break;
                            }
                        }
                    }
                    if (introduce.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine("Text RPG End");
                        break;
                    }
                }
            }
            
        }
        
        public class Character
        {
            public string name = "NoName";
            public int Lv = 1;
            public int Exp = 0;
            public int Hp = 100;
            public int Mp = 100;
            public int Atk = 1;
            public int Def = 1;
            public int Gold = 0;
            public ArmorType armor = ArmorType.Breastplate;
            public WeaponType weapon = WeaponType.Sword;
            
        }
        public enum ArmorType
        {
            None = 0,
            Breastplate
        }
        public enum WeaponType
        {
            None = 0,
            Sword
        }
        public static void FixTitle()
        {   
            Console.Clear();
            Console.WriteLine(@"/|------------------------------|");
            Console.WriteLine(@"|| ---                          |");
            Console.WriteLine(@"||  | /=\ \ / ---   |/- |/\ /\| |");
            Console.WriteLine(@"||  | \__ / \  \/   |   |-- --| |");
            Console.WriteLine(@"||                      |   \_/ |");
            Console.WriteLine(@"|/==============================/");
        }
    }
}
