using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace TextRPG
{
    internal class Program
    {
        private static void Main()
        {
            tutorial = false;
            Console.WriteLine("Text RPG Start");
            Console.WriteLine("Press escape to exit...");
            var start = Console.ReadKey(intercept: true);
            if (start.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Text RPG End");
            }
            else
            {
                FixTitle();
            }
        }
        public class Character
        {
            public string name = "NoName";
            public int Lv = 1;
            public double Exp = 0;
            public int Hp = 100;
            public int Mp = 100;
            public int Atk = 10;
            public int WAtk = 0;
            public int Def = 5;
            public int ADef = 0;
            public int Gold = 99999999;
            public int MAtk = 0;
            public int WMAtk = 0;
            public string skill1 = "x";
            public string skill2 = "x";
            public string skill3 = "x";
            public string skill4 = "x";
            public int cooltime;
            public double ExpNeed = 10;
            public int increase = 5;
        }
        public class Backpack
        {
            public bool Leather = false;
            public bool Chainmail = false;
            public bool Fullplate = false;
            public bool Gold = false;
            public bool God = false;
            public bool wood = false;
            public bool stone = false;
            public bool iron = false;
            public bool god = true;
            public bool just = false;
            public bool crystal = false;
            public bool dia = false;
            public bool gods = false;
            public bool strong = false;
            public bool amsal = false;
            public bool fireball = false;
            public bool godcom = false;
            public bool heal = false;
            public bool vamp = false;
            public bool revival = false;
            public bool tstrong = false;
            public bool weapon = false;
            public bool skill = false;
            public bool armor = false;
        }
        public class Equip
        {
            public string weapon = "없음";
            public string armor = "없음";
            public string skill = "없음";
        }
        public class Achievement
        {
            public bool ACslime = false;
            public bool ACWolf = false;
            public bool ACAcient = false;
        }
        private static bool created = false;
        private static bool tutorial = false;
        private static Character player = new Character();
        private static Achievement AC = new Achievement();
        private static Backpack backpack = new Backpack();
        private static Equip equip = new Equip();
        public class Enemy
        {
            public string name;
            public int Hp;
            public int Atk;
            public int Def;
            public bool Boss;
        }
        private static Enemy monster = new Enemy();
        static int cooltime = 0;
        static bool Boss = false;
        static bool appear = false;
        static bool animate = false;
        static int PCHp = 0;
        static int stage = 0;
        static bool stand = false;
        static int monsterCHp = 0;
        static int increase = 0;
        static string huntzone = "";
        public static void Battle()
        {
            if (appear == false)
            {
                if (monster.name == "슬라임")
                {
                    monster.Hp = 100;
                    monster.Atk = 10;
                    monster.Def = 5;
                    huntzone = "슬라임 사냥터";
                }
                else if (monster.name == "슬라임 킹")
                {
                    monster.Hp = 3000;
                    monster.Atk = 300;
                    monster.Def = 150;
                    huntzone = "슬라임 보스방";
                }
                else if (monster.name == "늑대")
                {
                    monster.Hp = 1000;
                    monster.Atk = 100;
                    monster.Def = 50;
                    huntzone = "늑대 사냥터";
                }
                else if (monster.name == "달빛 늑대")
                {
                    monster.Hp = 30000;
                    monster.Atk = 3000;
                    monster.Def = 1500;
                    huntzone = "늑대 보스방";
                }
                else if (monster.name == "광신도")
                {
                    monster.Hp = 10000;
                    monster.Atk = 1000;
                    monster.Def = 500;
                    huntzone = "뱀의 사당";
                }
                else if (monster.name == "고대 뱀")
                {
                    monster.Hp = 300000;
                    monster.Atk = 30000;
                    monster.Def = 15000;
                    huntzone = "뱀 보스방";
                }
                monsterCHp = monster.Hp;
                PCHp = player.Hp;
                appear = true;
                increase = monster.Def;
                Battle();
            }
            else
            {
                if (Boss == false)
                {
                    if (stand == false)
                    {
                        Standing();
                    }
                    else
                    {
                        Console.WriteLine(" ____________   ________________   ____________ ");
                        Console.WriteLine("/|공격(Enter)| /|스킬(BackSpace)| /|나가기(Esc)|");
                        var attack = Console.ReadKey(intercept: true);
                        if (attack.Key == ConsoleKey.Enter)
                        {
                            if (monster.Boss == false)
                            {
                                if (player.Atk + player.WAtk - monster.Def <= 0)
                                {
                                    monsterCHp -= 1;
                                }
                                else
                                {
                                    monsterCHp -= player.Atk + player.WAtk - monster.Def;
                                }
                                if (monster.Atk - player.Def <= 0)
                                {
                                    PCHp -= 1;
                                }
                                else
                                {
                                    PCHp -= monster.Atk - player.Def;
                                }
                            }
                            else
                            {
                                if (monster.name != "슬라임 킹")
                                {
                                    if (player.Atk + player.WAtk - monster.Def <= 0)
                                    {
                                        monsterCHp -= 1;
                                    }
                                    else
                                    {
                                        monsterCHp -= player.Atk + player.WAtk - monster.Def;
                                    }
                                    if (monster.Atk - player.Def <= 0)
                                    {
                                        PCHp -= 1;
                                    }
                                    else
                                    {
                                        PCHp -= monster.Atk - player.Def;
                                    }
                                }
                                else
                                {
                                    if (cooltime == 0)
                                    {
                                        if (player.Atk + player.WAtk - monster.Def <= 0)
                                        {
                                            monsterCHp -= 1;
                                        }
                                        else
                                        {
                                            monsterCHp -= player.Atk + player.WAtk - monster.Def;
                                        }
                                    }
                                    else
                                    {
                                        if (monster.Atk - player.Def <= 0)
                                        {
                                            PCHp -= 1;
                                        }
                                        else
                                        {
                                            PCHp -= monster.Atk - player.Def;
                                        }
                                    }
                                    if (monster.Atk - player.Def <= 0)
                                    {
                                        PCHp -= 1;
                                    }
                                    else
                                    {
                                        PCHp -= monster.Atk - player.Def;
                                    }
                                }
                            }
                            stand = false;
                            Battle();
                        }
                        if (attack.Key == ConsoleKey.Escape)
                        {
                            if (monster.Boss == true)
                            {
                                Console.Clear();
                                Console.WriteLine("보스전에서는 도망칠 수 없습니다");
                                attack = Console.ReadKey(intercept: true);
                                stand = false;
                                if (attack.Key == ConsoleKey.Escape)
                                {
                                    Battle();
                                }
                                else
                                {
                                    Battle();
                                }
                            }
                        }
                        if (attack.Key == ConsoleKey.Backspace)
                        {
                            if (player.skill1 == "x")
                            {
                                Console.Clear();
                                Console.WriteLine("스킬이 없습니다");
                                attack = Console.ReadKey(intercept: true);
                                stand = false;
                                if (attack.Key == ConsoleKey.Escape)
                                {
                                    Battle();
                                }
                                else
                                {
                                    Battle();
                                }
                            }
                            else
                            {
                            }
                        }
                    }
                }
                else
                {
                    Animation();
                }
                stand = false;
            }
        }
        public static void Animation()
        {
        }
        public static void Standing()
        {
            Console.Clear();
            Console.WriteLine("「<--(esc)」");
            Console.WriteLine(huntzone);
            Console.WriteLine($"{monster.name}|atk:{monster.Atk}|def:{monster.Def}");
            Console.WriteLine(monster.Hp + @"\" + monsterCHp);
            if (monster.Boss == false)
            {
                if (monsterCHp > (monster.Hp / 10) * 7)
                {
                    if (monster.name == "슬라임")
                    {
                        Console.WriteLine(@"  ____");
                        Console.WriteLine(@" | . .\_");
                        Console.WriteLine(@"/________\");
                    }
                    else if (monster.name == "늑대")
                    {
                        Console.WriteLine(@" /\---/\  ");
                        Console.WriteLine(@"<  O_O  > ");
                        Console.WriteLine(@" <__U__>  ");
                    }
                    else if (monster.name == "광신도")
                    {
                        Console.WriteLine(@"   ___");
                        Console.WriteLine(@"  /+++\");
                        Console.WriteLine(@" /=====\");
                        Console.WriteLine(@"(  =_=  )");
                        Console.WriteLine(@" \=====/  ");
                        Console.WriteLine(@"  \___/  ");
                    }
                }
                else if (monsterCHp > (monster.Hp / 10) * 2)
                {
                    if (monster.name == "슬라임")
                    {
                        Console.WriteLine(@"  ____");
                        Console.WriteLine(@" | x x\_");
                        Console.WriteLine(@"/________\");
                    }
                    else if (monster.name == "늑대")
                    {
                        Console.WriteLine(@" /\---/\");
                        Console.WriteLine(@"<  /_\  >");
                        Console.WriteLine(@" <__U__>  ");
                    }
                    else if (monster.name == "광신도")
                    {
                        Console.WriteLine(@"   ___");
                        Console.WriteLine(@"  /+++\");
                        Console.WriteLine(@" /=====\");
                        Console.WriteLine(@"(__\_/__)");
                        Console.WriteLine(@" \=====/  ");
                        Console.WriteLine(@"  \___/  ");
                    }
                }
                else
                {
                    if (monster.name == "슬라임")
                    {
                        Console.WriteLine(@"  ____");
                        Console.WriteLine(@" | x / ___");
                        Console.WriteLine(@"/____\/_x_/");
                    }
                    else if (monster.name == "늑대")
                    {
                        Console.WriteLine(@" /\---/\");
                        Console.WriteLine(@"<  X_X  >");
                        Console.WriteLine(@" <__U__>  ");
                    }
                    else if (monster.name == "광신도")
                    {
                        Console.WriteLine(@"   ___");
                        Console.WriteLine(@"  /+++\");
                        Console.WriteLine(@" /=====\");
                        Console.WriteLine(@"(__0_0__)");
                        Console.WriteLine(@" \=====/  ");
                        Console.WriteLine(@"  \___/  ");
                    }
                    Console.WriteLine("이름:" + player.name);
                    Console.WriteLine("레벨:" + player.Lv + "|" + player.Hp + @"\" + PCHp);
                }
            }
            else
            {
                if (monster.name == "슬라임 킹")
                {
                }
                else if (monster.name == "달빛 늑대")
                {
                }
                else if (monster.name == "고대 뱀")
                {
                    if (monsterCHp == monster.Hp)
                    {
                        Console.WriteLine(@"______                 ");
                        Console.WriteLine(@" \  /                         ______  ");
                        Console.WriteLine(@" |  |                          \  /   ");
                        Console.WriteLine(@" |  |                          |  |   ");
                        Console.WriteLine(@" |  |                          |  |   ");
                        Console.Write(@" |  | ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"       _____     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"        |  |  ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"    /     -------  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    |  |   ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"  /              \_  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"  |  |");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"  /       \   /     \  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |  |");
                        Console.Write(@" |  | ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"  |   _ _   |_-     /__ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |  |   ");
                        Console.Write(@" |  | ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@"   \       /       /   \ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"|  |    ");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@" / |_   _|            /");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |  |   ");
                        Console.Write(@" |__|   ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(@" \/ \_/____________/  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |__|   ");
                        Console.WriteLine(@"  \___      _-----------_     ___/");
                        Console.WriteLine(@"   \  |    ||           ||   |  /");
                        Console.WriteLine(@"    \  \    @===========@   /  /");
                        Console.WriteLine(@"     \ |\      \=====/     /| /");
                        Console.WriteLine(@"      / _/-----------------\_ \");
                        Console.WriteLine(@"     |_/---------------------\_|");
                        Console.WriteLine(@"     /-------------------------\_");
                    }
                    else if (monsterCHp > (monster.Hp / 10) * 4)
                    {
                        Console.WriteLine(@"______");
                        Console.Write(@" \  / ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"         ________    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"   ______  ");
                        Console.Write(@" |  |      ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"   /        \   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    \  /   ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"     |          |   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"   |  |   ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"      \  \  /  /     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"  |  |   ");
                        Console.Write(@" |  |    ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"      |_    _|     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"   |  |  ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"       / \  /  |  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"     |  |   ");
                        Console.Write(@" |  |     ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"    /   ||  /    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    |  |");
                        Console.Write(@" |  |    ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"    /    /\/     ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"     |  |");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"  __ /    _/ ________  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |  |   ");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@" /  |      /         \  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"|  |    ");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"/  _ \     \----/     / ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"|  |   ");
                        Console.Write(@" |__|  ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@" \/ \________________/ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |__|   ");
                        Console.WriteLine(@"  \___      _-----------_     ___/");
                        Console.WriteLine(@"   \  |    ||           ||   |  /");
                        Console.WriteLine(@"    \  \    @===========@   /  /");
                        Console.WriteLine(@"     \ |\      \=====/     /| /");
                        Console.WriteLine(@"      / _/-----------------\_ \");
                        Console.WriteLine(@"     |_/---------------------\_|");
                        Console.WriteLine(@"    _/-------------------------\_");
                    }
                    else
                    {
                        Console.WriteLine(@"______                 ");
                        Console.Write(@" \  /   ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"       /\/\/\/\   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    ______  ");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"       /  /  \  \  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"     \  /   ");
                        Console.Write(@" |  |    ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"    |          |  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    |  |   ");
                        Console.Write(@" |  |   ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"      \  \  /  /    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"   |  |   ");
                        Console.Write(@" |  |     ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"     |_    _|    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    |  |  ");
                        Console.Write(@" |  |       ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"   / \  /  | ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"      |  |   ");
                        Console.Write(@" |  |    ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"     /   ||  /    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"    |  |");
                        Console.Write(@" |  |     ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"   /  \ /\/    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"      |  |");
                        Console.Write(@" |  |    ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"__ / /  _/ ________ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"  |  |   ");
                        Console.Write(@" |  |  ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@" /  |      /         \  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"|  |    ");
                        Console.Write(@" |  | ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@" /  _ \  \  \----/  / / ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |  |   ");
                        Console.Write(@" |__| ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(@"  \/ \______________/   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@" |__|");
                        Console.WriteLine(@"  \___      _-----------_     ___/");
                        Console.WriteLine(@"   \  |    ||           ||   |  /");
                        Console.WriteLine(@"    \  \    @===========@   /  /");
                        Console.WriteLine(@"     \ |\      \=====/     /| /");
                        Console.WriteLine(@"      / _/-----------------\_ \");
                        Console.WriteLine(@"     |_/---------------------\_|");
                        Console.WriteLine(@"     /-------------------------\_");
                    }
                }
                stand = true;
                Battle();
            }
        }
        public static void Moving()
        {
            int width = 86, height = 28;
            Console.CursorVisible = false; // 커서 숨기기
            char[,] map = new char[width, height];
            string[] map1 =
            {
                 "|---------------------------------------------------------------------------|",
                 "|       _                                     ;##;;                         |",
                @"|      / \                                    \##|/                         |",
                 "|     ;;;;;                                   ;##;;    _                    |",
                @"|     /___\                                   \##|/   |_|                   |",
                @"|     /___\                                   ;##;; <=(o)=>                 |",
                @"|      | |                                    \##|/    |                    |",
                 "|                                             ;##;;;##;;;##;;;##;;;##;;;##;;|",
                @"|                 ,..,                        \##|/\##|/\##|/\##|/\##|/\##|/|",
                @"|               /',..,'\                                                    |",
                @"|               \/____\/                                                    |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                                                                           |",
                 "|                       _________                                           |",
                 "|                     _/         |                                          |",
                @"|                    /            \                                         |",
                 "|---------------------------------------------------------------------------|"
            };
            string[] map2 =
            {
                "|----------------------------------------------------------------------------|",
               @"|                 /                    \________                             |",
               @"|               _/                              \____________________________|",
                "|            __/                                                             |",
               @"|        ___/                       \|/                                      |",
                "|_______/                                                                    |",
                "|                                                                            |",
               @"|    \|/                                                                     |",
               @"|                                               \|/                          |",
                "|                                                                            |",
               @"|                             \|/                                            |",
               @"|                                                                            |",
               @"|         \|/                                                                |",
               @"|                                                               \|/          |",
               @"|                                                                            |",
               @"|                                                                            |",
               @"|                                       \|/                                  |",
               @"|                                                            ___             |",
               @"|                                                           /__/|            |",
               @"|                                                           |__|/            |",
               @"|                                  \|/                                       |",
               @"|                                                                            |",
               @"|                \|/                                                         |",
               @"|                                                                            |",
               @"|                                                     \|/                    |",
               @"|                                                                            |",
               @"|                                                                            |",
               @"|                                                                            |",
               @"|----------------------------------------------------------------------------|"
            };
            string[] map3 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map4 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map5 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map6 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map7 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map8 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map9 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map10 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map11 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map12 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map13 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map14 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map15 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map16 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map17 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map18 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map19 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map20 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map21 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
            string[] map22 =
            {
                "|----------------------------------------------------------------------------|",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|                                                                            |",
                "|----------------------------------------------------------------------------|"
            };
        }
        public static void Shop()
        {
            Console.Clear();
            Console.WriteLine(@"상점                        .___  ___   .");
            Console.WriteLine($"보유 골드:{player.Gold}     | +| |  || |");
            Console.WriteLine(@"         /_____________\   /|__|-|__||-/|");
            Console.WriteLine(@"        /  ___/     /   \  ===========_-      ");
            Console.WriteLine(@"        |  \_/ (ll)  o  |            ");
            Console.WriteLine(@"         \/   ______    /             ________   ");
            Console.WriteLine(@"          -_  \||||/  _-     /\      /  _  _  \   ");
            Console.WriteLine(@"            \        /      ||||     \_| || |_|      ");
            Console.WriteLine(@"    _-----_ _       _ _---_ |/O|     __      __   ");
            Console.WriteLine(@"   /       \_       _/     \| ||    /  \____/  \     ");
            Console.WriteLine(@"  /   /   /          \     \=====  |  ___      |");
            Console.WriteLine(@" /___//__/_,          \     \<|>   |==| |--    |");
            Console.WriteLine(@"(_______(__/            //_/       |___________|  ");
            Console.WriteLine(@"=======================|/_/        ");
            Console.WriteLine(" ________________    ____________    ____________");
            Console.WriteLine("/|구매하기(enter)|  /|판매하기(e)|  /|떠나기(esc)|");
            var Buy = Console.ReadKey();
            if (Buy.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine(@"상점                        .___  ___   .");
                Console.WriteLine($"보유 골드:{player.Gold}     | +| |  || |");
                Console.WriteLine(@"         /_____________\   /|__|-|__||-/|");
                Console.WriteLine(@"        /  ___/     /   \  ===========_-      ");
                Console.WriteLine(@"        |  \_/ (ll)  o  |            ");
                Console.WriteLine(@"         \/   ______    /             ________   ");
                Console.WriteLine(@"          -_  \||||/  _-     /\      /  _  _  \   ");
                Console.WriteLine(@"            \        /      ||||     \_| || |_|      ");
                Console.WriteLine(@"    _-----_ _       _ _---_ |/O|     __      __   ");
                Console.WriteLine(@"   /       \_       _/     \| ||    /  \____/  \     ");
                Console.WriteLine(@"  /   /   /          \     \=====  |  ___      |");
                Console.WriteLine(@" /___//__/_,          \     \<|>   |==| |--    |");
                Console.WriteLine(@"(_______(__/            //_/       |___________|  ");
                Console.WriteLine(@"=======================|/_/        ");
                Console.WriteLine(" ________    ________    ________    ______________");
                Console.WriteLine("/|갑옷(1)|  /|무기(2)|  /|스킬(3)|  /|돌아가기(esc)|");
                Buy = Console.ReadKey(intercept: true);
                if (Buy.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("상점                       ");
                    Console.WriteLine($"보유골드:{player.Gold}    ");
                    Console.WriteLine("<제품에 하자가 있다고? 환불은 절대 안돼!>");
                    Console.WriteLine("[1]가죽갑옷(3000)         ");
                    Console.WriteLine("[2]사슬갑옷(75000)        ");
                    Console.WriteLine("[3]풀플레이트갑옷(1500000)");
                    Console.WriteLine("[4]순금 전신 갑옷(2000000000)");
                    Console.WriteLine("[5]축복받은 갑옷(1000000000)");
                    Console.WriteLine(" _______________      ______________");
                    Console.WriteLine("/|선택하기(번호)|    /|돌아가기(esc)|");
                    Buy = Console.ReadKey(intercept: true);
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (backpack.Leather == false)
                        {
                            if (player.Gold >= 3000)
                            {
                                player.Gold -= 3000;
                                backpack.Leather = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }

                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (backpack.Chainmail == false)
                        {
                            if (player.Gold >= 75000)
                            {
                                player.Gold -= 75000;
                                backpack.Chainmail = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (backpack.Fullplate == false)
                        {
                            if (player.Gold >= 1500000)
                            {
                                player.Gold -= 1500000;
                                backpack.Fullplate = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (backpack.Gold == false)
                        {
                            if (player.Gold >= 2000000000)
                            {
                                player.Gold -= 2000000000;
                                backpack.Fullplate = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D5)
                    {
                        if (backpack.God == false)
                        {
                            if (player.Gold >= 2000000000)
                            {
                                player.Gold -= 2000000000;
                                backpack.God = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");

                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.Escape)
                    {
                        Shop();
                    }
                    else
                    {
                        FixTitle();
                    }
                }
                else if (Buy.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine($"보유골드:{player.Gold}");
                    Console.WriteLine("<제품에 하자가 있다고? 환불은 절대 안돼!>");
                    Console.WriteLine("[1]나무 검(75000)");
                    Console.WriteLine("[2]돌 검(1500000)");
                    Console.WriteLine("[3]철 검(300000000)");
                    Console.WriteLine("[4]신의 검(1000000000)");
                    Console.WriteLine("\n");
                    Console.WriteLine(" _______________    _________     ______________");
                    Console.WriteLine("/|선택하기(번호)|  /|다음(->)|   /|돌아가기(esc)|");
                    Buy = Console.ReadKey(intercept: true);
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (backpack.wood == false)
                        {
                            if (player.Gold >= 3000)
                            {
                                player.Gold -= 3000;
                                backpack.wood = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (backpack.stone == false)
                        {
                            if (player.Gold >= 75000)
                            {
                                player.Gold -= 75000;
                                backpack.stone = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                            Buy = Console.ReadKey(intercept: true);
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (backpack.stone == false)
                        {
                            if (player.Gold >= 1500000)
                            {
                                player.Gold -= 1500000;
                                backpack.iron = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (backpack.god == false)
                        {
                            if (player.Gold >= 2000000000)
                            {
                                player.Gold -= 2000000000;
                                backpack.god = true;
                            }
                            else
                            {
                                Console.WriteLine("보유 골드가 부족합니다");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                                if (Buy.Key == ConsoleKey.Escape)
                                {
                                    Shop();
                                }
                                else
                                {
                                    Shop();
                                }
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!보유중입니다!");
                            Console.ResetColor();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                        }
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            Shop();
                        }
                    }
                    else if (Buy.Key == ConsoleKey.Escape)
                    {
                        Shop();
                    }
                    else if (Buy.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        Console.WriteLine("상점");
                        Console.WriteLine($"보유골드:{player.Gold}");
                        Console.WriteLine("<제품에 하자가 있다고? 환불은 절대 안돼!>");
                        Console.WriteLine("[1]일반 스태프(150000)");
                        Console.WriteLine("[2]크리스탈 스태프(30000000)");//D1
                        Console.WriteLine("[3]다이아몬드 스태프(60000000)");
                        Console.WriteLine("[4]신의 스태프(2000000000)");
                        Console.WriteLine("\n");
                        Console.WriteLine(" _______________    _________     ______________");
                        Console.WriteLine("/|선택하기(번호)|  /|다음(->)|   /|돌아가기(esc)|");
                        Buy = Console.ReadKey(intercept: true);
                        if (Buy.Key == ConsoleKey.D1)
                        {
                            if (backpack.just == false)
                            {
                                if (player.Gold >= 3000)
                                {
                                    player.Gold -= 3000;
                                    backpack.just = true;
                                    Console.WriteLine("구매 완료");
                                }
                                else
                                {
                                    Console.WriteLine("보유 골드가 부족합니다");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine(" _________");
                                    Console.WriteLine("/|돌아가기|");
                                    if (Buy.Key == ConsoleKey.Escape)
                                    {
                                        Shop();
                                    }
                                    else
                                    {
                                        Shop();
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                            }
                            Buy = Console.ReadKey(intercept: true);
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                        else if (Buy.Key == ConsoleKey.D2)
                        {
                            if (backpack.crystal == false)
                            {
                                if (player.Gold >= 75000)
                                {
                                    player.Gold -= 75000;
                                    backpack.crystal = true;
                                    Console.WriteLine("구매 완료");
                                }
                                else
                                {
                                    Console.WriteLine("보유 골드가 부족합니다");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine(" _________");
                                    Console.WriteLine("/|돌아가기|");
                                    if (Buy.Key == ConsoleKey.Escape)
                                    {
                                        Shop();
                                    }
                                    else
                                    {
                                        Shop();
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                            }
                            Buy = Console.ReadKey(intercept: true);
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                        else if (Buy.Key == ConsoleKey.D3)
                        {
                            if (backpack.dia == false)
                            {
                                if (player.Gold >= 1500000)
                                {
                                    player.Gold -= 1500000;
                                    backpack.dia = true;
                                    Console.WriteLine("구매 완료");
                                }
                                else
                                {
                                    Console.WriteLine("보유 골드가 부족합니다");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine(" _________");
                                    Console.WriteLine("/|돌아가기|");
                                    if (Buy.Key == ConsoleKey.Escape)
                                    {
                                        Shop();
                                    }
                                    else
                                    {
                                        Shop();
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                            }
                            Buy = Console.ReadKey(intercept: true);
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                            Buy = Console.ReadKey(intercept: true);
                        }
                        else if (Buy.Key == ConsoleKey.D4)
                        {
                            if (backpack.gods == false)
                            {
                                if (player.Gold >= 2000000000)
                                {
                                    player.Gold -= 2000000000;
                                    backpack.gods = true;
                                    Console.WriteLine("구매 완료");
                                }
                                else
                                {
                                    Console.WriteLine("보유 골드가 부족합니다");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.WriteLine(" _________");
                                    Console.WriteLine("/|돌아가기|");
                                    if (Buy.Key == ConsoleKey.Escape)
                                    {
                                        Shop();
                                    }
                                    else
                                    {
                                        Shop();
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine(" _________");
                                Console.WriteLine("/|돌아가기|");
                            }
                            Buy = Console.ReadKey(intercept: true);
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                        else if (Buy.Key == ConsoleKey.Escape)
                        {
                            Shop();
                        }
                        else
                        {
                            FixTitle();
                        }
                    }
                    else
                    {
                        FixTitle();
                    }
                }
                else if (Buy.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine($"보유골드:{player.Gold}");
                    Console.WriteLine("<제품에 하자가 있다고? 환불은 절대 안돼!>");
                    Console.WriteLine("강타(20000)");
                    Console.WriteLine("암살(1000000)");
                    Console.WriteLine("파이어볼(80000)");
                    Console.WriteLine("강림(2000000000)");
                    Console.WriteLine("\n");
                    Console.WriteLine(" _______________    _________    ______________");
                    Console.WriteLine("/|선택하기(번호)|  /|다음(->)|  /|돌아가기(esc)|");
                    Buy = Console.ReadKey(intercept: true);
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 20000)
                        {
                            player.Gold -= 20000;
                            backpack.strong = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 1000000)
                        {
                            player.Gold -= 1000000;
                            backpack.amsal = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 80000)
                        {
                            player.Gold -= 80000;
                            backpack.fireball = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 2000000000)
                        {
                            player.Gold -= 2000000000;
                            backpack.godcom = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        Console.WriteLine("상점");
                        Console.WriteLine($"보유골드:{player.Gold}");
                        Console.WriteLine("<제품에 하자가 있다고? 환불은 절대 안돼!>");
                        Console.WriteLine("[1]힐(20000)");
                        Console.WriteLine("[2]흡혈(1000000)");
                        Console.WriteLine("[3]부활(2000000000)");//마법뎀 스킬 하나밖에 없음,스킬슬롯이 4개나 되는데 개수는 왜 8개임?
                        Console.WriteLine("[4]힘 강화(20000000)");
                        Console.WriteLine("\n");
                        Console.WriteLine(" _______________    _________    ______________");
                        Console.WriteLine("/|선택하기(번호)|  /|다음(->)|  /|돌아가기(esc)|");
                    }
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 20000)
                        {
                            player.Gold -= 20000;
                            backpack.heal = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 1000000)
                        {
                            player.Gold -= 1000000;
                            backpack.vamp = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 80000)
                        {
                            player.Gold -= 80000;
                            backpack.revival = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 2000000000)
                        {
                            player.Gold -= 2000000000;
                            backpack.tstrong = true;
                        }
                        else
                        {
                            Console.WriteLine("보유 골드가 부족합니다");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" _________");
                            Console.WriteLine("/|돌아가기|");
                            if (Buy.Key == ConsoleKey.Escape)
                            {
                                Shop();
                            }
                            else
                            {
                                Shop();
                            }
                        }
                    }
                    else if (Buy.Key == ConsoleKey.Escape)
                    {
                        Shop();
                    }
                    else
                    {
                        FixTitle();
                    }
                }
                else if (Buy.Key == ConsoleKey.Escape)
                {
                    FixTitle();
                }
            }
            else if(Buy.Key == ConsoleKey.Escape)
            {
                FixTitle();
            }
        }

        public static void Equip2()
        {
            Console.WriteLine("가방");
            if (backpack.weapon == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|무기(w)|");
            }
            else if (backpack.armor == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|갑옷(a)|");
            }
            else if (backpack.skill == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|스킬(s)|");
            }
            else
            {
                Console.WriteLine("가방이 비어있습니다");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine(" _________");
                Console.WriteLine("/|돌아가기|");
                var goback = Console.ReadKey();
                if (goback.Key == ConsoleKey.Escape)
                {
                    FixTitle();
                }
                else
                {
                    FixTitle();
                }
            }
            ConsoleKeyInfo e1quip = Console.ReadKey();
            if (e1quip.Key == ConsoleKey.W)
            {
                if (backpack.weapon == true)
                {
                    int num = 0;
                    int w1 = 0;
                    int w2 = 0;
                    int w3 = 0;
                    int w4 = 0;
                    int w5 = 0;
                    int w6 = 0;
                    int w7 = 0;
                    int w8 = 0;
                    if (backpack.wood == true)
                    {
                        num++;
                        w1 = num;
                        Console.WriteLine($"[{w1}]나무 검");
                    }
                    if (backpack.stone == true)
                    {
                        num++;
                        w2 = num;
                        Console.WriteLine($"[{w2}]돌 검");
                    }
                    if (backpack.iron == true)
                    {
                        num++;
                        w3 = num;
                        Console.WriteLine($"[{w3}]철 검");
                    }
                    if (backpack.god == true)
                    {
                        num++;
                        w4 = num;
                        Console.WriteLine($"[{w4}]신의 검");
                    }
                    if (backpack.just == true)
                    {
                        num++;
                        w5 = num;
                        Console.WriteLine($"[{w5}]일반 스태프");
                    }
                    if (backpack.crystal == true)
                    {
                        num++;
                        w6 = num;
                        Console.WriteLine($"[{w6}]크리스탈 스태프");
                    }
                    if (backpack.dia == true)
                    {
                        num++;
                        w7 = num;
                        Console.WriteLine($"[{w7}]다이아몬드 스태프");
                    }
                    if (backpack.gods == true)
                    {
                        num++;
                        w8 = num;
                        Console.WriteLine($"[{w8}]신의 스태프");
                    }
                    var select = Console.ReadKey();
                    if (select.Key == ConsoleKey.D1)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w1 == 1)
                            {
                                Console.WriteLine("나무 검");
                                Console.WriteLine("공격력 + 100 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     조잡한 성능. 나무검에게 뭘 바라나? ");
                                Console.WriteLine("     고작 나무검의 성능을 뛰어나게 만들 수 있는 능력자면  ");
                                Console.WriteLine("     나무검을 안만들었다. 몽둥이나 다름없다. ");

                            }
                            if (w2 == 1)
                            {
                                Console.WriteLine("돌 검");
                                Console.WriteLine("공격력 + 5,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 날을 갈아서, 나무에 붙였다. ");
                                Console.WriteLine("     절삭력은 사과를 벨 수 있을 정도.");
                            }
                            if (w3 == 1)
                            {
                                Console.WriteLine("철 검");
                                Console.WriteLine("공격력 + 250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     검이라고 봐줄만한 검. ");
                                Console.WriteLine("     평민도 이정도는 살 수 있다.");
                            }
                            if (w4 == 1)
                            {
                                Console.WriteLine("신의 검");
                                Console.WriteLine("공격력 + 12,500,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 검을 파는게 말이 안된다.");
                                Console.WriteLine("     물론 아주 강하긴 하다.");
                            }
                            if (w5 == 1)
                            {
                                Console.WriteLine("일반 스태프");
                                Console.WriteLine("마법공격력 + 500 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                            if (w6 == 1)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 1)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 1)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                        }
                        e1quip = Console.ReadKey();
                        if (e1quip.Key == ConsoleKey.Enter)
                        {
                            if (w1 == 1)
                            {
                                equip.weapon = "나무 검";
                            }
                            if (w2 == 1)
                            {
                                equip.weapon = "돌 검";
                            }
                            if (w3 == 1)
                            {
                                equip.weapon = "철 검";
                            }
                            if (w4 == 1)
                            {
                                equip.weapon = "신의 검";
                            }
                            if (w5 == 1)
                            {
                                equip.weapon = "일반 스태프";
                            }
                            if (w6 == 1)
                            {
                                equip.weapon = "크리스탈 스태프";
                            }
                            if (w7 == 1)
                            {
                                equip.weapon = "다이아몬드 스태프";
                            }
                            if (w8 == 1)
                            {
                                equip.weapon = "신의 스태프";
                            }
                            FixTitle();
                        }
                    }
                    if (select.Key == ConsoleKey.D2)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w2 == 2)
                            {
                                Console.WriteLine("돌 검");
                                Console.WriteLine("공격력 + 5,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 날을 갈아서, 나무에 붙였다. ");
                                Console.WriteLine("     절삭력은 사과를 벨 수 있을 정도.");
                            }
                            if (w3 == 2)
                            {
                                Console.WriteLine("철 검");
                                Console.WriteLine("공격력 + 250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     검이라고 봐줄만한 검. ");
                                Console.WriteLine("     평민도 이정도는 살 수 있다.");
                            }
                            if (w4 == 2)
                            {
                                Console.WriteLine("신의 검");
                                Console.WriteLine("공격력 + 12,500,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 검을 파는게 말이 안된다.");
                                Console.WriteLine("     물론 아주 강하긴 하다.");
                            }
                            if (w5 == 2)
                            {
                                Console.WriteLine("일반 스태프");
                                Console.WriteLine("마법공격력 + 500 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                            if (w6 == 2)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 2)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 2)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D3)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w3 == 3)
                            {
                                Console.WriteLine("철 검");
                                Console.WriteLine("공격력 + 250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     검이라고 봐줄만한 검. ");
                                Console.WriteLine("     평민도 이정도는 살 수 있다.");
                            }
                            if (w4 == 3)
                            {
                                Console.WriteLine("신의 검");
                                Console.WriteLine("공격력 + 12,500,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 검을 파는게 말이 안된다.");
                                Console.WriteLine("     물론 아주 강하긴 하다.");
                            }
                            if (w5 == 3)
                            {
                                Console.WriteLine("일반 스태프");
                                Console.WriteLine("마법공격력 + 500 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                            if (w6 == 3)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 3)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 3)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                if (w3 == 3)
                                {
                                    player.WAtk = 250000;
                                }
                                if (w4 == 3)
                                {
                                    player.WAtk = 12500000;
                                }
                                if (w5 == 3)
                                {
                                    player.WMAtk = 500;
                                }
                                if (w6 == 3)
                                {
                                    player.WMAtk = 25000;
                                }
                                if (w7 == 3)
                                {
                                    player.WMAtk = 1250000;
                                }
                                if (w8 == 3)
                                {
                                    player.WMAtk = 625000000;
                                }
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D4)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w4 == 4)
                            {
                                Console.WriteLine("신의 검");
                                Console.WriteLine("공격력 + 12,500,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 검을 파는게 말이 안된다.");
                                Console.WriteLine("     물론 아주 강하긴 하다.");
                            }
                            if (w5 == 4)
                            {
                                Console.WriteLine("일반 스태프");
                                Console.WriteLine("마법공격력 + 500 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                            if (w6 == 4)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 4)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 4)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                if (w1 == 4)
                                {
                                    player.WAtk = 100;
                                }
                                if (w2 == 4)
                                {
                                    player.WAtk = 5000;
                                }
                                if (w3 == 4)
                                {
                                    player.WAtk = 250000;
                                }
                                if (w4 == 4)
                                {
                                    player.WAtk = 12500000;
                                }
                                if (w5 == 4)
                                {
                                    player.WMAtk = 500;
                                }
                                if (w6 == 4)
                                {
                                    player.WMAtk = 25000;
                                }
                                if (w7 == 4)
                                {
                                    player.WMAtk = 1250000;
                                }
                                if (w8 == 4)
                                {
                                    player.WMAtk = 625000000;
                                }
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D5)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w5 == 5)
                            {
                                Console.WriteLine("일반 스태프");
                                Console.WriteLine("마법공격력 + 500 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                            if (w6 == 5)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 5)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 5)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }

                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                if (w5 == 5)
                                {
                                    player.WMAtk = 500;
                                }
                                if (w6 == 5)
                                {
                                    player.WMAtk = 25000;
                                }
                                if (w7 == 5)
                                {
                                    player.WMAtk = 1250000;
                                }
                                if (w8 == 5)
                                {
                                    player.WMAtk = 625000000;
                                }
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D6)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w6 == 6)
                            {
                                Console.WriteLine("크리스탈 스태프");
                                Console.WriteLine("마법공격력 + 25,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     크리스탈 처럼 생긴 색유리다.");
                                Console.WriteLine("     싸다고 무턱대고 샀다가 사기");
                                Console.WriteLine("     당한 사람들이 많다. 그래도 ");
                                Console.WriteLine("     유리라 마력이 확대된다.");
                            }
                            if (w7 == 6)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 6)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                if (w6 == 6)
                                {
                                    player.WMAtk = 25000;
                                }
                                if (w7 == 6)
                                {
                                    player.WMAtk = 1250000;
                                }
                                if (w8 == 6)
                                {
                                    player.WMAtk = 625000000;
                                }
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D7)
                    {
                        if (num > 0)
                        {
                            if (w7 == 7)
                            {
                                Console.WriteLine("다이아몬드 스태프");
                                Console.WriteLine("마법공격력 + 1,250,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     아쉽지만 이건 진짜다.");
                                Console.WriteLine("     비싸서 아주 조그맣다.");
                                Console.WriteLine("     뾰족한 부분이 마력을");
                                Console.WriteLine("     모으는 역할을 한다.");
                            }
                            if (w8 == 7)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                if (w7 == 7)
                                {
                                    player.WMAtk = 1250000;
                                }
                                if (w8 == 8)
                                {
                                    player.WMAtk = 625000000;
                                }
                            }
                        }
                    }
                    if (select.Key == ConsoleKey.D8)
                    {
                        if (num > 0)
                        {
                            Console.Clear();
                            if (w8 == 8)
                            {
                                Console.WriteLine("신의 스태프");
                                Console.WriteLine("마법공격력 + 625,000,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     모조품이다. 애초에 상인이 ");
                                Console.WriteLine("     신의 스태프를 파는게 말이 ");
                                Console.WriteLine("     안된다. 물론 아주 강하긴  ");
                                Console.WriteLine("     하다.");
                            }
                            e1quip = Console.ReadKey();
                            if (e1quip.Key == ConsoleKey.Enter)
                            {
                                player.WMAtk = 625000000;
                            }
                        }
                    }
                }
                else if (e1quip.Key == ConsoleKey.A)
                {
                    if (backpack.armor == true)
                    {
                        int num = 0;
                        int a1 = 0;
                        int a2 = 0;
                        int a3 = 0;
                        int a4 = 0;
                        int a5 = 0;
                        if (backpack.Leather == true)
                        {
                            num++;
                            a1 = num;
                            Console.WriteLine($"[{a1}]가죽 갑옷");
                        }
                        if (backpack.Chainmail == true)
                        {
                            num++;
                            a2 = num;
                            Console.WriteLine($"[{a2}]사슬 갑옷");
                        }
                        if (backpack.Fullplate == true)
                        {
                            num++;
                            a3 = num;
                            Console.WriteLine($"[{a3}]풀 플레이트 갑옷");
                        }
                        if (backpack.Gold == true)
                        {
                            num++;
                            a4 = num;
                            Console.WriteLine($"[{a4}]전신 순금 갑옷");
                        }
                        if (backpack.God== true)
                        {
                            num++;
                            a5 = num;
                            Console.WriteLine($"[{a5}]축복받은 갑옷");
                        }
                        var select = Console.ReadKey();
                        if (select.Key == ConsoleKey.D1)
                        {
                            if (num > 0)
                            {
                                if (a1 == 1)
                                {
                                    Console.WriteLine("가죽 갑옷");
                                    Console.WriteLine("방어력 + 50 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     가리는 곳도 적다.없는 것 보단 낫지만...");
                                    Console.WriteLine("     이정도면 돈을 받고 쓰레기 처리를 해줘야 한다");
                                }
                                if (a2 == 1)
                                {
                                    Console.WriteLine("사슬 갑옷");
                                    Console.WriteLine("방어력 + 2,500 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     체인이 녹슬었다. 공격받으면 낮은 ");
                                    Console.WriteLine("     확률로 파상풍에 걸릴수도...");
                                }
                                if (a3 == 1)
                                {
                                    Console.WriteLine("풀 플레이트 갑옷");
                                    Console.WriteLine("방어력 + 125,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     무명의 수습 대장장이가 만들었다. ");
                                    Console.WriteLine("     이걸로 드래곤에게 덤비는 놈은 없겠지.");
                                }
                                if (a4 == 1)
                                {
                                    Console.WriteLine("전신 순금 갑옷");
                                    Console.WriteLine("방어력 + 3,125,000 마력 + 6,250,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     18k 골드. 즉 순금이 아니다.");
                                    Console.WriteLine("     금이라 좀 무르다.");
                                    Console.WriteLine("     대신 마력이 오른다...");
                                }
                                if (a5 == 1)
                                {
                                    Console.WriteLine("축복 받은 갑옷");
                                    Console.WriteLine("방어력 + 312,500,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                    Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                    Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                                }
                            }
                        }
                        if (select.Key == ConsoleKey.D2)
                        {
                            if (num > 0)
                            {
                                if (a2 == 1)
                                {
                                    Console.WriteLine("사슬 갑옷");
                                    Console.WriteLine("방어력 + 2,500 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     체인이 녹슬었다. 공격받으면 낮은 ");
                                    Console.WriteLine("     확률로 파상풍에 걸릴수도...");
                                }
                                if (a3 == 1)
                                {
                                    Console.WriteLine("철 갑옷");
                                    Console.WriteLine("방어력 + 125,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     무명의 수습 대장장이가 만들었다. ");
                                    Console.WriteLine("     이걸로 드래곤에게 덤비는 놈은 없겠지.");
                                }
                                if (a4 == 1)
                                {
                                    Console.WriteLine("전신 순금 갑옷");
                                    Console.WriteLine("방어력 + 3,125,000 마력 + 6,250,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     18k 골드. 즉 순금이 아니다.");
                                    Console.WriteLine("     금이라 좀 무르다.");
                                    Console.WriteLine("     대신 마력이 오른다...");
                                }
                                if (a5 == 1)
                                {
                                    Console.WriteLine("축복 받은 갑옷");
                                    Console.WriteLine("방어력 + 312,500,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                    Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                    Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                                }
                            }
                        }
                        if (select.Key == ConsoleKey.D3)
                        {
                            if (num > 0)
                            {
                                if (a3 == 1)
                                {
                                    Console.WriteLine("철 갑옷");
                                    Console.WriteLine("방어력 + 125,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     무명의 수습 대장장이가 만들었다. ");
                                    Console.WriteLine("     이걸로 드래곤에게 덤비는 놈은 없겠지.");
                                }
                                if (a4 == 1)
                                {
                                    Console.WriteLine("전신 순금 갑옷");
                                    Console.WriteLine("방어력 + 3,125,000 마력 + 6,250,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     18k 골드. 즉 순금이 아니다.");
                                    Console.WriteLine("     금이라 좀 무르다.");
                                    Console.WriteLine("     대신 마력이 오른다...");
                                }
                                if (a5 == 1)
                                {
                                    Console.WriteLine("축복 받은 갑옷");
                                    Console.WriteLine("방어력 + 312,500,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                    Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                    Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                                }
                            }
                        }
                        if (select.Key == ConsoleKey.D4)
                        {
                            if (num > 0)
                            {
                                if (a4 == 1)
                                {
                                    Console.WriteLine("전신 순금 갑옷");
                                    Console.WriteLine("방어력 + 3,125,000 마력 + 6,250,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     18k 골드. 즉 순금이 아니다.");
                                    Console.WriteLine("     금이라 좀 무르다.");
                                    Console.WriteLine("     대신 마력이 오른다...");
                                }
                                if (a5 == 1)
                                {
                                    Console.WriteLine("축복 받은 갑옷");
                                    Console.WriteLine("방어력 + 312,500,000 ");
                                    Console.WriteLine("설명:");
                                    Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                    Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                    Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                                }
                            }
                        }
                        if (select.Key == ConsoleKey.D5)
                        {
                            if (num > 0)
                            {
                                Console.WriteLine("축복 받은 갑옷");
                                Console.WriteLine("방어력 + 312,500,000 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 막대기다. 마력이 아주 조금 ");
                                Console.WriteLine("     담겨있지만 오래된 돌멩이 수준의 ");
                                Console.WriteLine("     마력이며 초보 마법사도 안쓴다.");
                            }
                        }
                    }
                }
                if (1 == 1)
                {
                    if (backpack.skill == true)
                    {
                        int num = 0;
                        int s1 = 0;
                        int s2 = 0;
                        int s3 = 0;
                        int s4 = 0;
                        int s5 = 0;
                    }
                }
            }
        }
        public static void LvUp()
        {
            while (true)
            {
                Console.Clear();
                if (player.Lv == 1)
                {
                    Console.WriteLine("레벨업!");
                    player.Exp -= player.ExpNeed;
                    player.Lv += 1;
                    player.Hp += player.increase*20;
                    player.Mp += player.increase * 10;
                    player.Atk += player.increase * 2;
                    player.Def += player.increase;
                    Console.WriteLine($"체력 {player.increase * 20} 증가");
                    Console.WriteLine($"마력 {player.increase * 10} 증가");
                    Console.WriteLine($"공격력 {player.increase * 2} 증가");
                    Console.WriteLine($"방어력 {player.increase} 증가");
                    Console.WriteLine(" ______________    ______________");
                    Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                    if (player.Lv < 10)
                    {
                        player.ExpNeed += 100;
                    }
                    else if (player.Lv < 20)
                    {
                        player.ExpNeed += 2000;
                    }
                    else if (player.Lv < 30)
                    {
                        player.ExpNeed += 40000;
                    }
                    else if (player.Lv < 40)
                    {
                        player.ExpNeed += 800000;
                    }
                    else if (player.Lv < 50)
                    {
                        player.ExpNeed += 16000000;
                    }
                    else if (player.Lv < 60)
                    {
                        player.ExpNeed += 320000000;
                    }
                    else if (player.Lv < 70)
                    {
                        player.ExpNeed += 6400000000;
                    }
                    //long은 정수형 변수로 2^63까지 표현 가능
                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Spacebar)
                    {
                        LvUp();
                        break;
                    }
                }
                else if (player.Lv < 10)
                {
                    if (player.Exp >= player.Lv * 10)
                    {
                        Console.WriteLine("레벨업!");
                        player.Exp -= player.Lv * 10;
                        player.Lv += 1;
                        player.Hp += 100; // 10lv은  1000,500,100,50
                        player.Mp += 50;
                        player.Atk += 10;
                        player.Def += 5;
                        Console.WriteLine("Hp 100 증가");
                        Console.WriteLine("Mp 50 증가");
                        Console.WriteLine("Atk 10 증가");
                        Console.WriteLine("Def 5 증가");
                        Console.WriteLine(" ______________    ______________");
                        Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                    }
                }
                var LvU = Console.ReadKey(intercept: true);
                if (LvU.Key == ConsoleKey.Spacebar)
                {
                    LvUp();
                }
                else if (LvU.Key == ConsoleKey.Escape)
                {
                    FixTitle();
                }
            }
        }
        public static void RkUp()
        {
            if (player.Lv == 10)
            {
                if (AC.ACslime == true)
                {
                    player.Lv += 1;
                    player.Exp -= 20;
                    player.Hp += 4_000;
                    player.Mp += 2_000;
                    player.Atk += 400;
                    player.Def += 200;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 4,000 증가");
                    Console.WriteLine("공격력 400 증가");
                    Console.WriteLine("방어력 200 증가");
                }
            }
            else if (player.Lv == 20)
            {
                if (AC.ACWolf == true)
                {
                    player.Lv += 1;
                    player.Exp -= 400;
                    player.Hp += 15_000;
                    player.Mp += 7_500;
                    player.Atk += 1_500;
                    player.Def += 750;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 15,000 증가");
                    Console.WriteLine("공격력 1,500 증가");
                    Console.WriteLine("방어력 750 증가");
                }
            }
            else if (player.Lv == 30)
            {
                if (AC.ACAcient == true)
                {
                    player.Lv += 1;
                    player.Exp -= 8_000;
                    player.Hp += 50_000;
                    player.Mp += 25_000;
                    player.Atk += 5_000;
                    player.Def += 2_500;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 50,000 증가");
                    Console.WriteLine("공격력 5,000 증가");
                    Console.WriteLine("방어력 2,500 증가");
                }
                else
                {
                }
            }
            else if (player.Lv == 40)
            {
                player.Lv += 1;
                player.Exp -= 160_000;
                player.Hp += 300_000;
                player.Mp += 150_000;
                player.Atk += 30_000;
                player.Def += 15_000;
                Console.WriteLine("(한계)레벨 증가");
                Console.WriteLine("체력 50,000 증가");
                Console.WriteLine("공격력 30,000 증가");
                Console.WriteLine("방어력 15,000 증가");
            }
            else if (player.Lv == 50)
            {
                player.Lv += 1;
                player.Exp -= 3_200_000;
                player.Hp += 1_500_000;
                player.Mp += 750_000;
                player.Atk += 150_000;
                player.Def += 75_000;
            }
            else if (player.Lv == 60)
            {
                player.Lv += 1;
                player.Exp -= 64_000_000;
                player.Hp += 5_000_000;
                player.Mp += 2_500_000;
                player.Atk += 500_000;
                player.Def += 250_000;
            }
            else if (player.Lv == 70)
            {
                player.Lv += 1;
                player.Exp = 0;
                player.Hp += 45_000_000;
                player.Mp += 22_500_000;
                player.Atk += 4_500_000;
                player.Def += 2_250_000;
            }
        }
        public static void FixTitle()
        {
            if (backpack.Leather == true || backpack.Chainmail == true || backpack.Fullplate == true || backpack.God == true || backpack.Gold == true)
            {
                backpack.armor = true;
            }
            if (backpack.wood == true || backpack.stone == true || backpack.iron == true || backpack.god == true || backpack.just == true||backpack.crystal||backpack.dia||backpack.gods)
            {
                backpack.weapon = true;
            }
            if (backpack.strong||backpack.amsal||backpack.fireball||backpack.godcom||backpack.heal||backpack.vamp||backpack.revival||backpack.tstrong)
            {
                backpack.skill = true;
            }
            if (equip.armor == "가죽 갑옷")
            {
                player.ADef = 50;
            }
            if (equip.armor == "사슬 갑옷")
            {
                player.ADef = 2500;
            }
            if (equip.armor == "철 갑옷")
            {
                player.ADef = 125000;
            }
            if (equip.armor == "전신 순금 갑옷")
            {
                player.ADef = 3125000;
            }
            if (equip.armor == "축복받은 갑옷")
            {
                player.ADef = 312500000;
            }
            if (equip.weapon == "나무 검")
            {
                player.WAtk = 100;
            }
            if (equip.weapon == "돌 검")
            {
                player.WAtk = 5000;
            }
            if (equip.weapon == "철 검")
            {
                player.WAtk = 250000;
            }
            if (equip.weapon == "신의 검")
            {
                player.WAtk = 12500000;
            }
            if (equip.weapon == "일반 스태프")
            {
                player.WMAtk = 500;
            }
            if (equip.weapon == "크리스탈 스태프")
            {
                player.WMAtk = 25000;
            }
            if (equip.weapon == "다이아몬드 스태프")
            {
                player.WMAtk = 1250000;
            }
            if (equip.weapon == "신의 스태프")
            {
                player.WMAtk = 625000000;
            }
            Console.Clear();
            Console.WriteLine("Text RPG Start");
            Console.WriteLine("Please name your character");
            if (created == false)
            {
                player.name = Console.ReadLine();
                created = true;
                if (tutorial == false)
                {
                    Console.WriteLine("튜토리얼을 하시겠습니까?");
                }
            }
            player.MAtk = (int)player.Atk / 2;
            Console.Clear();
            Console.WriteLine(@" ________________________________");
            Console.WriteLine(@"/ |                              |");
            Console.WriteLine(@"| | ---         |                |");
            Console.WriteLine(@"| |  | /=\ \ / ---   |/- |/\ /\| |");
            Console.WriteLine(@"| |  | \__ / \  \/   |   |-- --| |");
            Console.WriteLine(@"| |                      |   \_/ |");
            Console.WriteLine(@"| |______________________________|");
            Console.WriteLine(@"|_/______________________________/");
            Console.WriteLine("\n");
            Console.WriteLine(" _______    _______");
            Console.WriteLine("|정보(I)|  |장비(E)|");
            Console.WriteLine(" =======    =======");
            Console.WriteLine(" _______    _______ ");
            Console.WriteLine("|훈련(t)|  |상점(S)|");
            Console.WriteLine(" =======   =======");
            Console.WriteLine(" _______    _______");
            Console.WriteLine("|이동(M)|  |도감(D)|");
            Console.WriteLine(" =======    =======");
            if (player.Gold < 0)
            {
                player.Gold = 0;
            }
            
            var introduce = Console.ReadKey(intercept: true);
            if (player.Gold < 0)
            {
                player.Gold = 0;
            }
            if (player.Exp > player.ExpNeed)
            {
                if (player.Lv == 10 || player.Lv == 20 || player.Lv == 30 || player.Lv == 40 || player.Lv == 50 || player.Lv == 60 || player.Lv == 70)
                {
                    Console.WriteLine(@"       /\/\/\");
                    Console.WriteLine(@"  __,./-    -\.,__");
                    Console.WriteLine(@" |  승급(space)   |");
                    Console.WriteLine(@" \--..________..--/");
                    Console.WriteLine(@"  \______________/");
                }
                else
                {

                    Console.WriteLine(@"        /\");
                    Console.WriteLine(@"  __,./-  -\.,__");
                    Console.WriteLine(@" |레벨업(space)|");
                    Console.WriteLine(@"  --..______..--");
                }
            }

            while (true)
            {
                if (introduce.Key == ConsoleKey.I)
                {
                    Console.Clear();
                    Console.WriteLine("Name: " + player.name);
                    if (player.Lv == 71)
                    {
                        Console.WriteLine("Lv: Max");
                    }
                    else
                    {
                        Console.WriteLine("Lv: " + player.Lv);
                    }
                    if (player.Lv < 71)
                    {
                        Console.WriteLine("Exp: " + player.Exp);
                    }
                    Console.WriteLine("Hp: " + player.Hp);
                    Console.WriteLine("Mp: " + player.Mp);
                    Console.WriteLine("Atk: " + player.Atk + $"({player.Atk + player.WAtk})");
                    Console.WriteLine("MagicAtk: " + player.MAtk + $"({player.MAtk + player.WMAtk})");
                    Console.WriteLine("Def: " + player.Def + $"({player.Def + player.ADef})");
                    Console.WriteLine("Gold: " + player.Gold);
                    Console.WriteLine("Armor: " + equip.armor);
                    Console.WriteLine("Weapon: " + equip.weapon);
                    Console.WriteLine("Skill 1: " + player.skill1);
                    Console.WriteLine("Skill 2: " + player.skill2);
                    Console.WriteLine("Skill 3: " + player.skill3);
                    Console.WriteLine("Skill 4: " + player.skill4);
                    Console.WriteLine(" ______________");
                    Console.WriteLine("/|돌아가기(esc)|");
                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                    {
                        FixTitle();
                        break;
                    }
                }
                else if (introduce.Key == ConsoleKey.E)
                {
                    Console.Clear();
                    Equip2();
                    break;
                }
                else if (introduce.Key == ConsoleKey.S)
                {
                    Shop();
                    break;
                }
                else if (introduce.Key == ConsoleKey.Spacebar)
                {
                    if (player.Lv < 10)
                    {
                        if (player.Exp >= player.Lv * 10)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 10)
                    {
                        if (player.Exp >= 100)
                        {
                        }
                    }
                    else if (player.Lv < 20)
                    {
                        if (player.Exp >= (player.Lv - 10) * 200)
                        {
                            LvUp();
                        }
                    }
                    else if
                        (player.Lv == 20)
                    {
                        if (player.Exp >= 2000)
                        {
                        }
                    }
                    else if (player.Lv < 30)
                    {
                        if (player.Exp >= (player.Lv - 20) * 4000)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 30)
                    {
                        if (player.Exp >= 40000)
                        {
                        }
                    }
                    else if (player.Lv < 40)
                    {
                        if (player.Exp >= (player.Lv - 30) * 80000)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 40)
                    {
                        if (player.Exp >= 800000)
                        {
                        }
                    }
                    else if (player.Lv < 50)
                    {
                        if (player.Exp >= (player.Lv - 40) * 1600000)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 50)
                    {
                        if (player.Exp >= 16000000)
                        {
                        }
                    }
                    else if (player.Lv < 60)
                    {
                        if (player.Exp >= (player.Lv - 50) * 32000000)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 60)
                    {
                        if (player.Exp >= 320000000)
                        {
                        }
                    }
                    else if (player.Lv < 70)
                    {
                        if (player.Exp >= (player.Lv - 60) * 640000000)
                        {
                            LvUp();
                        }
                    }
                    else if (player.Lv == 70)
                    {
                    }
                    else if (player.Lv == 71)
                    {
                        Console.WriteLine("한계 레벨입니다");
                    }
                }
                else
                {
                    FixTitle();
                }
            }
        }
    }
}


