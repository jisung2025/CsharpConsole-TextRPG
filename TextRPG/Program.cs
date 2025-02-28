using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace TextRPG
{
    internal class Program
    {
        private static void Main(string[] args)
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
            public int Exp = 1000000;
            public int Hp = 100;
            public int Mp = 100;
            public int Atk = 10;
            public int WAtk = 0;
            public int Def = 0;
            public int ADef = 0;
            public int Gold = 0;
            public int MAtk = 0;
            public int skill1 = 0;
            public int skill2 = 0;
            public int skill3 = 0;
            public int skill4 = 0;
            public int cooltime;
            public Armor armor = Armor.None;
            public WeaponType weapon = WeaponType.Fist;

        }
        public class Backpack
        {
            public bool Leather = false;
            public bool Chainmail = true;
            public bool Fullplate = false;
            public bool God = false;
            public bool wood = false;
            public bool stone = false;
            public bool iron = false;
            public bool god = false;
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
            public bool armor = true;
        }
        public class Achievement
        {
            public bool ACslime = false;
            public bool ACWolf = false;
        }
        public enum Armor
        {
            None = 0,
            Leather,
            Chainmail,
            Fullplate,
            God
        }
        public enum WeaponType
        {
            Fist = 0,
            wood,
            stone,
            iron,
            god
        }
        private static bool created = false;
        private static bool tutorial = false;
        private static Character player = new Character();
        private static Achievement AC = new Achievement();
        private static Backpack backpack = new Backpack();
        public static void Shop()
        {
            Console.Clear();
            Console.WriteLine(@"상점                        .___  ___   .");
            Console.WriteLine($"보유 골드:{player.Gold}     | +| |  || |");
            Console.WriteLine(@"         /_____________\   /|__|-|__||-/|");
            Console.WriteLine(@"        /  ___/     /   \  ===========_-      ");
            Console.WriteLine(@"        |  \_/ (ll)  o  |            ");
            Console.WriteLine(@"         \/   ______    /            ________   ");
            Console.WriteLine(@"          -_  \||||/  _-     /\     /  _  _  \   ");
            Console.WriteLine(@"            \        /      ||||    \_| || |_|      ");
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
                Console.WriteLine(@"         \/   ______    /            ________   ");
                Console.WriteLine(@"          -_  \||||/  _-     /\     /  _  _  \   ");
                Console.WriteLine(@"            \        /      ||||    \_| || |_|      ");
                Console.WriteLine(@"    _-----_ _       _ _---_ |/O|     __      __   ");
                Console.WriteLine(@"   /       \_       _/     \| ||    /  \____/  \     ");
                Console.WriteLine(@"  /   /   /          \     \=====  |  ___      |");
                Console.WriteLine(@" /___//__/_,          \     \<|>   |==| |--    |");
                Console.WriteLine(@"(_______(__/            //_/       |___________|  ");
                Console.WriteLine(@"=======================|/_/        ");
                Console.WriteLine(" ________    ________    ________     _____________");
                Console.WriteLine("/|갑옷(1)|  /|무기(2)|  /|스킬(3)|  /|돌아가기(esc)|");
                if (Buy.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("상점                       "+   "  ___________________");
                    Console.WriteLine($"보유골드:{player.Gold}    "+  @" /  제품에 하자가?   \");
                    Console.WriteLine(@"[1]가죽갑옷(3000)         " + @"| 환불은 절대 안돼!   |");
                    Console.WriteLine(@"[1]가죽갑옷(3000)         " + @"\    ________________/");
                    Console.WriteLine(@"[2]사슬갑옷(75000)        "+  @"  \ /");
                    Console.WriteLine(@"[3]풀플레이트갑옷(1500000)"+  @"  |/");
                    Console.WriteLine("[4]순금 전신 갑옷(2000000000)");
                    Console.WriteLine("[5]축복받은 갑옷(1000000000)");
                    Console.WriteLine(" _______________      ______________");
                    Console.WriteLine("/|선택하기(번호)|    /|돌아가기(esc)|");
                    Buy = Console.ReadKey(intercept: true);
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 3000)
                        {
                            player.Gold -= 3000;
                            backpack.Leather = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 75000)
                        {
                            player.Gold -= 75000;
                            backpack.Chainmail = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 1500000)
                        {
                            player.Gold -= 1500000;
                            backpack.Fullplate = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 2000000000)
                        {
                            player.Gold -= 2000000000;
                            backpack.God = true;
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
                    Console.WriteLine("상점"+   "  ___________________");
                    Console.WriteLine($"보유골드:{player.Gold}" + @" /  제품에 하자가?   \");
                    Console.WriteLine("[1]나무 검(3000)" + @"| 환불은 절대 안돼!   |");
                    Console.WriteLine("[2]돌 검(75000)" + @"\    ________________/");
                    Console.WriteLine("[3]철 검(1500000)" + @"  \ /");
                    Console.WriteLine("[4]신의 검(2000000000)" + @"  |/");
                    Console.WriteLine("\n");
                    Console.WriteLine(" _______________    _________     ______________");
                    Console.WriteLine("/|선택하기(번호)|  /|다음(->)|   /|돌아가기(esc)|");
                    Buy = Console.ReadKey(intercept: true);
                    if (Buy.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 3000)
                        {
                            player.Gold -= 3000;
                            backpack.wood = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 75000)
                        {
                            player.Gold -= 75000;
                            backpack.stone = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 1500000)
                        {
                            player.Gold -= 1500000;
                            backpack.iron = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 2000000000)
                        {
                            player.Gold -= 2000000000;
                            backpack.god = true;
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
                        Console.WriteLine("[1]일반 스태프(3000)");
                        Console.WriteLine("[2]크리스탈 스태프(75000)");
                        Console.WriteLine("[3]다이아몬드 스태프(1500000)");
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
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                            }
                            Buy = Console.ReadKey(intercept: true);
                        }
                        else if (Buy.Key == ConsoleKey.D2)
                        {   
                            if(backpack.crystal == false)
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
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
                            }
                            Buy = Console.ReadKey(intercept: true);
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
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
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
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("!보유중입니다!");
                                Console.ResetColor();
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
                        Buy = Console.ReadKey();
                        if (Buy.Key != ConsoleKey.Delete)
                        {
                            Shop();
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
                            backpack.wood = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 1000000)
                        {
                            player.Gold -= 1000000;
                            backpack.stone = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 80000)
                        {
                            player.Gold -= 80000;
                            backpack.iron = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 2000000000)
                        {
                            player.Gold -= 2000000000;
                            backpack.god = true;
                        }
                    }
                    else if (Buy.Key == ConsoleKey.RightArrow)
                    {
                        Console.Clear();
                        Console.WriteLine("상점");
                        Console.WriteLine($"보유골드:{player.Gold}");
                        Console.WriteLine("[1]힐(20000)");
                        Console.WriteLine("[2]흡혈(1000000)");
                        Console.WriteLine("[3]부활(2000000000)");
                        Console.WriteLine("[4]힘 강화(20000000)");
                        Console.WriteLine("\n");
                        Console.WriteLine(" _______________    _________    ______________");
                        Console.WriteLine("/|선택하기(번호)|  /|다음(->)|  /|돌아가기(esc)|");
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
            }
        }
        public static void Battle()
        {
            Console.Clear();
            Console.WriteLine("「<--(esc)」");
            Console.WriteLine("\n");
            Console.WriteLine("     슬라임 사냥터(레벨제한:0)");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine(" ____________      __________");
            Console.WriteLine("/|입장(enter)|    /|다음(-->)|");
            var start = Console.ReadKey(intercept: true);
            if (start.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                int SlimeHp = 100;
                int SlimeAtk = 1;
                int SlimeDef = 0;
                int SlimeCurrentHp = SlimeHp;
                int PlayerCurrentHp = player.Hp;
                player.cooltime = 0;
                while (true)
                {
                    if (SlimeCurrentHp > 0)
                    {
                        Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                        Console.WriteLine("슬라임 사냥터1");
                        Console.WriteLine("슬라임");
                        Console.WriteLine($"Hp:{SlimeCurrentHp}/{SlimeHp}");
                        Console.WriteLine($"공격력:{SlimeAtk} 방어력:{SlimeDef}");
                        if (30 < SlimeCurrentHp && SlimeCurrentHp < 100)
                        {
                            Console.WriteLine(@"  ____");
                            Console.WriteLine(@" | x x\_");
                            Console.WriteLine(@"/________\");
                        }
                        else if (SlimeCurrentHp == 100)
                        {
                            Console.WriteLine(@"  ____");
                            Console.WriteLine(@" | . .\_");
                            Console.WriteLine(@"/________\");
                        }
                        else if (SlimeCurrentHp <= 30)
                        {
                            Console.WriteLine(@"  ____");
                            Console.WriteLine(@" | x / ___");
                            Console.WriteLine(@"/____\/_x_/");
                        }
                        Console.WriteLine(" ____________    ____________");
                        Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                        var attack = Console.ReadKey(intercept: true);
                        if (attack.Key == ConsoleKey.Enter)
                        {
                            PlayerCurrentHp -= 1;
                            if (player.Atk + player.WAtk < SlimeDef)
                            {
                                SlimeCurrentHp -= 1;
                                if (player.Atk + player.WAtk < SlimeDef)
                                {
                                    SlimeCurrentHp -= 1;
                                }
                                else
                                {
                                    PlayerCurrentHp -= ((player.Def + player.ADef) - SlimeAtk);
                                }
                            }
                            else
                            {
                                SlimeCurrentHp -= ((player.Atk + player.WAtk) - SlimeDef);
                                if (player.Atk + player.WAtk < SlimeDef)
                                {
                                    SlimeCurrentHp -= 1;
                                }
                                else
                                {
                                    PlayerCurrentHp -= ((player.Def + player.ADef) - SlimeAtk);
                                }
                            }
                        }
                        else if (attack.Key == ConsoleKey.Escape)
                        {
                            Battle();
                            break;
                        }
                        else 
                        {
                            FixTitle();
                        }
                        Console.Clear();
                    }
                    else if (PlayerCurrentHp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("패배하였습니다.");
                        player.Gold -= SlimeHp / 2;
                        Console.WriteLine($"{SlimeHp / 2}골드를 잃었습니다.");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine(" ______________");
                        Console.WriteLine("/|돌아가기(esc)|");
                        if (Console.ReadKey(intercept:true).Key == ConsoleKey.Escape)
                        {
                            Battle();
                            break;
                        }
                        else
                        {
                            FixTitle();
                        }
                    }
                    else if (SlimeCurrentHp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("슬라임을 물리쳤습니다.");
                        player.Exp += SlimeHp / 20;
                        player.Gold += SlimeHp;
                        Console.WriteLine($"경험치{SlimeHp / 20}  획득");
                        Console.WriteLine($"골드 {SlimeHp} 획득");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine(" ______________      ___________");
                        Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                        var enter = Console.ReadKey(intercept: true);
                        if (enter.Key == ConsoleKey.Escape)
                        {
                            Battle();
                            break;
                        }
                        else if (enter.Key == ConsoleKey.Enter)
                        {
                            SlimeHp += 100;
                            SlimeCurrentHp = SlimeHp;
                            SlimeAtk += 1;
                            SlimeDef += 1;
                            bool loop = true;
                            while (loop == true)
                            {
                                if (SlimeCurrentHp > 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("슬라임 사냥터2");
                                    Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                    Console.WriteLine("슬라임");
                                    Console.WriteLine($"Hp:{SlimeCurrentHp}/{SlimeHp}");
                                    Console.WriteLine($"공격력:{SlimeAtk} 방어력:{SlimeDef}");
                                    if ((SlimeHp / 10) * 3 < SlimeCurrentHp && SlimeCurrentHp < SlimeHp)
                                    {
                                        Console.WriteLine(@"  ____");
                                        Console.WriteLine(@" | x x\_");
                                        Console.WriteLine(@"/________\");
                                    }
                                    else if (SlimeCurrentHp == SlimeHp)
                                    {
                                        Console.WriteLine(@"  ____");
                                        Console.WriteLine(@" | . .\_");
                                        Console.WriteLine(@"/________\");
                                    }
                                    else if (SlimeCurrentHp <= (SlimeHp / 10) * 3)
                                    {
                                        Console.WriteLine(@"  ____");
                                        Console.WriteLine(@" | x / ___");
                                        Console.WriteLine(@"/____\/_x_/");
                                    }
                                    Console.WriteLine(" ____________    ____________");
                                    Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                    var attack = Console.ReadKey(intercept: true);
                                    if (attack.Key == ConsoleKey.Enter)
                                    {
                                        Console.WriteLine($"");
                                        if (player.Def + player.ADef > SlimeAtk)
                                        {
                                            PlayerCurrentHp -= 1;
                                        }
                                        else
                                        {
                                            PlayerCurrentHp -= (SlimeAtk - (player.Def + player.ADef));
                                        }
                                        if (player.Atk + player.WAtk < SlimeDef)
                                        {
                                            SlimeCurrentHp -= 1;
                                        }
                                        else
                                        {
                                            SlimeCurrentHp -= ((player.Atk + player.WAtk) - SlimeDef);
                                        }
                                    }
                                    else if (attack.Key == ConsoleKey.Escape)
                                    {
                                        Battle();
                                        loop = false;
                                    }
                                    else
                                    {
                                        FixTitle();
                                        loop = false;
                                    }
                                }
                                else if (SlimeCurrentHp <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("슬라임을 물리쳤습니다.");
                                    player.Exp += SlimeHp / 20;
                                    player.Gold += SlimeHp;
                                    Console.WriteLine($"경험치{SlimeHp / 20}  획득");
                                    Console.WriteLine($"골드 {SlimeHp} 획득");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\n");
                                    Console.WriteLine(" ______________      ___________");
                                    Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                                    enter = Console.ReadKey(intercept: true);
                                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                    {
                                        Battle();
                                        loop = false;
                                    }
                                    else if (enter.Key == ConsoleKey.Enter)
                                    {
                                        Console.Clear();
                                        SlimeHp += 100;
                                        SlimeCurrentHp = SlimeHp;
                                        SlimeAtk += 1;
                                        SlimeDef += 1;
                                        bool loop_3 = true;
                                        while (loop_3 == true)
                                        {
                                            if (SlimeCurrentHp > 0)
                                            {
                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                Console.WriteLine("슬라임 사냥터3");
                                                Console.WriteLine("슬라임");
                                                Console.WriteLine($"Hp:{SlimeCurrentHp}/{SlimeHp}");
                                                Console.WriteLine($"공격력:{SlimeAtk} 방어력:{SlimeDef}");
                                                if ((SlimeHp / 10) * 3 < SlimeCurrentHp && SlimeCurrentHp < SlimeHp)
                                                {
                                                    Console.WriteLine(@"  ____");
                                                    Console.WriteLine(@" | x x\_");
                                                    Console.WriteLine(@"/________\");
                                                }
                                                else if (SlimeCurrentHp == SlimeHp)
                                                {
                                                    Console.WriteLine(@"  ____");
                                                    Console.WriteLine(@" | . .\_");
                                                    Console.WriteLine(@"/________\");
                                                }
                                                else if (SlimeCurrentHp <= (SlimeHp / 10) * 3)
                                                {
                                                    Console.WriteLine(@"  ____");
                                                    Console.WriteLine(@" | x / ___");
                                                    Console.WriteLine(@"/____\/_x_/");
                                                }
                                                Console.WriteLine(" ____________    ____________");
                                                Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                var attack = Console.ReadKey(intercept: true);
                                                if (attack.Key == ConsoleKey.Enter)
                                                {
                                                    if (player.Def + player.ADef > SlimeAtk)
                                                    {
                                                        PlayerCurrentHp -= 1;
                                                    }
                                                    else
                                                    {
                                                        PlayerCurrentHp -= (SlimeAtk - (player.Def + player.ADef));
                                                    }
                                                    if (player.Atk + player.WAtk < SlimeDef)
                                                    {
                                                        SlimeCurrentHp -= 1;
                                                    }
                                                    else
                                                    {
                                                        SlimeCurrentHp -= ((player.Atk + player.WAtk) - SlimeDef);
                                                    }
                                                    Console.Clear();
                                                }
                                                else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                {
                                                    Battle();
                                                    loop_3 = false;
                                                }
                                                else
                                                {
                                                    FixTitle();
                                                    loop_3 = false;
                                                }
                                            }
                                            else if (PlayerCurrentHp <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("패배하였습니다.");
                                                player.Gold -= SlimeHp / 2;
                                                Console.WriteLine($"{SlimeHp / 2}골드를 잃었습니다.");
                                                Console.WriteLine("\n");
                                                Console.WriteLine("\n");
                                                Console.WriteLine("\n");
                                                Console.WriteLine("\n");
                                                Console.WriteLine(" ______________");
                                                Console.WriteLine("/|돌아가기(esc)|");
                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                {
                                                    Battle();
                                                    loop_3 = false;
                                                }
                                                else
                                                {
                                                    FixTitle();
                                                    loop_3 = false;
                                                }
                                            }
                                            else if (SlimeCurrentHp <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("슬라임을 물리쳤습니다.");
                                                player.Exp += SlimeHp / 20;
                                                player.Gold += SlimeHp;
                                                Console.WriteLine($"경험치{SlimeHp / 20}  획득");
                                                Console.WriteLine($"골드 {SlimeHp} 획득");
                                                Console.WriteLine("\n");
                                                Console.WriteLine("\n");
                                                Console.WriteLine("\n");
                                                Console.WriteLine(" ______________     ____________");
                                                Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                                                var next = Console.ReadKey();
                                                if (next.Key == ConsoleKey.Escape)
                                                {
                                                    Battle();
                                                    loop_3 = false;
                                                }

                                                else if (next.Key == ConsoleKey.Enter)
                                                {
                                                    Console.WriteLine("이 앞은 보스 슬라임 킹(추천레벨 10+)이 존재합니다.");
                                                    Console.WriteLine("정말 들어가시겠습니까?");
                                                    Console.WriteLine("(Hp 전체 회복, 쿨타임 초기화)");
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine(" ________________    ______________");
                                                    Console.WriteLine("/|들어가기(enter)|  /|돌아가기(esc)|");
                                                    next = Console.ReadKey();
                                                    if (next.Key == ConsoleKey.Escape)
                                                    {
                                                        Battle();
                                                        loop_3 = false;
                                                    }
                                                    else if (next.Key == ConsoleKey.Enter)
                                                    {
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(@" ");
                                                        Console.WriteLine(@".,/./../,/.\.\,/.,\./ ");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine("      __ ");
                                                        Console.WriteLine(@"  _,/__\.,.-_.,.-,_,., ");
                                                        Console.WriteLine(@"(__)\___\/___\//\\\____\' ");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine("      _/    _");
                                                        Console.WriteLine(@"  _,/__.,/-\.,.-, ");
                                                        Console.WriteLine(@"(_______||___\/  \' ");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine("      ________");
                                                        Console.WriteLine(@"    /        \");
                                                        Console.WriteLine(@"   |          |");
                                                        Console.Write(@" _/  ");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.Write("l  l");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__  ");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"\_");
                                                        Console.WriteLine(@"/________________\");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"       /""\_");
                                                        Console.WriteLine(@"      (_____) ()");
                                                        Console.WriteLine(@"     ________");
                                                        Console.WriteLine(@"    /        \");
                                                        Console.WriteLine(@"   |          |");
                                                        Console.Write(@" _/  ");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.Write("l  l");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__  ");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"\_");
                                                        Console.WriteLine(@"/________________\");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.WriteLine(@" ");
                                                        Console.WriteLine(@"              ");
                                                        Console.WriteLine(@"     /\/\/\/\");
                                                        Console.WriteLine(@"    /////\\\\\");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"   |          |");
                                                        Console.Write(@" _/  ");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.Write("l  l");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__  ");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"\_");
                                                        Console.WriteLine(@"/________________\");
                                                        Console.ResetColor();
                                                        Thread.Sleep(100);
                                                        Console.Clear();
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(" ");
                                                        Console.WriteLine(@"              ");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine(@"     /\/\/\/\");
                                                        Console.Write(@"    /___");
                                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                                        Console.Write("O");
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine(@"____\");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"   |          |");
                                                        Console.Write(@" _/  ");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        Console.Write("l  l");
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.Write("__  ");
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@"\_");
                                                        Console.WriteLine(@"/________________\");
                                                        Console.ResetColor();
                                                        Thread.Sleep(800);
                                                        Console.Clear();
                                                        Console.BackgroundColor = ConsoleColor.White;
                                                        Console.WriteLine("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               ");
                                                        Console.ResetColor();
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        int SlimeKingHp = 3000;
                                                        int SlimeKingAtk = 50 + 100;
                                                        int SlimeKingDef = 0;
                                                        int SlimeKingCurrentHp = SlimeKingHp;
                                                        PlayerCurrentHp = player.Hp;
                                                        int CoolTime = 1;
                                                        player.cooltime = 0;
                                                        bool loop_4 = true;
                                                        while (loop_4 == true)
                                                        {
                                                            if (SlimeKingCurrentHp > 0)
                                                            {
                                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                                Console.WriteLine("보스의 방1");
                                                                Console.WriteLine("슬라임 킹");
                                                                Console.WriteLine($"Hp:{SlimeKingCurrentHp}/{SlimeKingHp}");
                                                                Console.WriteLine($"공격력:{SlimeKingAtk} 방어력:{SlimeKingDef}");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("2턴마다 무적");
                                                                Console.ResetColor();
                                                                if (1500 < SlimeKingCurrentHp && SlimeKingCurrentHp < 5000)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.Write(@"    /___");
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.Write("O");
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"____\");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.Write(@" _/   ");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write(".");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                    Console.Write("l  l");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write(".   ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"\_");
                                                                    Console.WriteLine(@"/________________\");
                                                                    Console.ResetColor();
                                                                }
                                                                else if (SlimeKingCurrentHp >= 5000)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.Write(@"    /___");
                                                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                                                    Console.Write("O");
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"____\");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.Write(@" _/  ");
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.Write("__");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                    Console.Write("l  l");
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.Write("__  ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"\_");
                                                                    Console.WriteLine(@"/________________\");
                                                                    Console.ResetColor();
                                                                }
                                                                else if (SlimeKingCurrentHp <= 1500)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.Write(@"    /___");
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.Write("O");
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine(@"____\");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.Write(@" _/  ");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write("..");
                                                                    Console.ForegroundColor = ConsoleColor.White;
                                                                    Console.Write("l  l");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write("..  ");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"\_");
                                                                    Console.WriteLine(@"/____");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write("||");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.Write("____");
                                                                    Console.ForegroundColor = ConsoleColor.Blue;
                                                                    Console.Write("||");
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine(@"____\");
                                                                    Console.ResetColor();
                                                                }
                                                                Console.WriteLine(" ____________    ____________");
                                                                Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                                var sk = Console.ReadKey();
                                                                if (sk.Key == ConsoleKey.Enter)
                                                                {
                                                                    if (player.Def + player.ADef > SlimeKingAtk)
                                                                    {
                                                                        PlayerCurrentHp -= 1; 
                                                                        if (CoolTime == 1)
                                                                        {
                                                                            if (player.Atk + player.WAtk < SlimeKingDef)
                                                                            {
                                                                                SlimeKingCurrentHp -= 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                SlimeKingCurrentHp -= ((player.Atk + player.WAtk) - SlimeKingDef);
                                                                            }
                                                                            CoolTime -= 1;
                                                                            Console.Clear();

                                                                        }
                                                                        else
                                                                        {
                                                                            SlimeCurrentHp -= 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        PlayerCurrentHp -= (SlimeKingAtk - (player.Def + player.ADef));
                                                                        if (CoolTime == 1)
                                                                        {
                                                                            if (player.Atk + player.WAtk < SlimeKingDef)
                                                                            {
                                                                                SlimeKingCurrentHp -= 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                SlimeKingCurrentHp -= ((player.Atk + player.WAtk) - SlimeKingDef);
                                                                            }
                                                                            CoolTime += 1;
                                                                            Console.Clear();

                                                                        }
                                                                        else
                                                                        {
                                                                            SlimeCurrentHp -= 0;
                                                                        }
                                                                    }
                                                                }
                                                                else if (sk.Key == ConsoleKey.Escape)
                                                                {
                                                                    Battle();
                                                                    loop_4 = false;
                                                                }
                                                                else
                                                                {
                                                                    FixTitle();
                                                                    loop_4 = false;
                                                                }
                                                            }
                                                            if (SlimeKingCurrentHp <= 0)
                                                            {
                                                                if (AC.ACslime == false)
                                                                {
                                                                    Random random = new Random();
                                                                    int rn = random.Next(1, 11);
                                                                    if (rn == 1)
                                                                    {
                                                                        AC.ACslime = true;
                                                                        Console.Clear();
                                                                        Console.WriteLine("슬라임 킹을 물리쳤습니다.");
                                                                        player.Exp += SlimeKingHp / 10;
                                                                        player.Gold += SlimeKingHp;
                                                                        Console.WriteLine($"경험치 {SlimeKingHp / 10} 획득");
                                                                        Console.WriteLine($"골드 {SlimeKingHp} 획득");
                                                                        Console.WriteLine("슬라임의 증표 획득");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine(" ______________");
                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                        {
                                                                            Battle();
                                                                            loop_4 = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            FixTitle();
                                                                            loop_4 = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("슬라임 킹을 물리쳤습니다.");
                                                                        player.Exp += SlimeKingHp / 10;
                                                                        player.Gold += SlimeKingHp;
                                                                        Console.WriteLine($"경험치 {SlimeKingHp / 10} 획득");
                                                                        Console.WriteLine($"골드 {SlimeKingHp} 획득");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine(" ______________");
                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                        {
                                                                            Battle();
                                                                            loop_4 = false;
                                                                        }
                                                                        else
                                                                        {
                                                                            FixTitle();
                                                                            loop_4 = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("슬라임 킹을 물리쳤습니다.");
                                                                    player.Exp += SlimeKingHp / 10;
                                                                    player.Gold += SlimeKingHp;
                                                                    Console.WriteLine($"경험치 {SlimeKingHp / 10} 획득");
                                                                    Console.WriteLine($"골드 {SlimeKingHp} 획득");
                                                                    Console.WriteLine("\n");
                                                                    Console.WriteLine("\n");
                                                                    Console.WriteLine("\n");
                                                                    Console.WriteLine(" ______________");
                                                                    Console.WriteLine("/|돌아가기(esc)|");
                                                                }
                                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                {
                                                                    Battle();
                                                                    loop_4 = false;
                                                                }
                                                                else
                                                                {
                                                                    FixTitle();
                                                                    loop_4 = false;
                                                                }
                                                            }
                                                            else if (PlayerCurrentHp <= 0)
                                                            {
                                                                Console.Clear();
                                                                Console.WriteLine("패배하였습니다.");
                                                                player.Gold -= SlimeKingHp / 2;
                                                                Console.WriteLine($"{SlimeKingHp / 2}골드를 잃었습니다.");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine(" ______________");
                                                                Console.WriteLine("/|돌아가기(esc)|");
                                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                {
                                                                    Battle();
                                                                    loop_4 = false;
                                                                }
                                                                else
                                                                {
                                                                    FixTitle();
                                                                    loop_4 = false;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        FixTitle();
                                                        loop_3 = false;
                                                    }
                                                }
                                                else
                                                {
                                                    FixTitle();
                                                    loop_3 = false;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        FixTitle();
                                        loop = false;
                                    }
                                }
                                if (PlayerCurrentHp <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("패배하였습니다.");
                                    player.Gold -= SlimeHp / 2;
                                    Console.WriteLine($"{SlimeHp / 2}골드를 잃었습니다.");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\n");
                                    Console.WriteLine("\n");
                                    Console.WriteLine(" ______________");
                                    Console.WriteLine("/|돌아가기(esc)|");
                                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                    {
                                        Battle();
                                        loop = false;
                                    }
                                    else
                                    {
                                        FixTitle();
                                        loop = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            FixTitle();
                        }
                    }
                }

            }
            if (start.Key == ConsoleKey.RightArrow)
            {
                Console.Clear();
                Console.WriteLine("「<--(esc)」");
                Console.WriteLine("\n");
                Console.WriteLine("     늑대 사냥터(레벨제한:11)");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine(" ____________      __________");
                Console.WriteLine("/|입장(enter)|    /|다음(-->)|");
                start = Console.ReadKey(intercept: true);
                if (start.Key == ConsoleKey.Enter)
                {
                    if (player.Lv < 11)
                    {
                        Console.WriteLine("레벨이 부족합니다");
                        Battle();
                    }
                    else
                    {
                        Console.Clear();
                        int WolfHp = 10000;
                        int WolfAtk = 1000;
                        int WolfDef = 500;
                        int WolfCurrentHp = WolfHp;
                        int PlayerCurrentHp = player.Hp;
                        while (true)
                        {
                            if (WolfCurrentHp > 0)
                            {
                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                Console.WriteLine("늑대 사냥터1");
                                Console.WriteLine("늑대");
                                Console.WriteLine($"Hp:{WolfCurrentHp}/{WolfHp}");
                                Console.WriteLine($"공격력:{WolfAtk} 방어력:{WolfDef}");
                                if (30 < WolfCurrentHp && WolfCurrentHp < 100)
                                {
                                    Console.WriteLine(@" /\---/\");
                                    Console.WriteLine(@"<  /_\  >");
                                    Console.WriteLine(@" <__U__>  ");
                                }
                                else if (WolfCurrentHp == 100)
                                {
                                    Console.WriteLine(@" /\---/\");
                                    Console.WriteLine(@"<  O_O  >");
                                    Console.WriteLine(@" <__U__>  ");
                                }
                                else if (WolfCurrentHp <= 30)
                                {
                                    Console.WriteLine(@" /\---/\");
                                    Console.WriteLine(@"<  X_X  >");
                                    Console.WriteLine(@" <__U__>  ");
                                }
                                Console.WriteLine(" ____________    ____________");
                                Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                var attack = Console.ReadKey(intercept: true);
                                if (attack.Key == ConsoleKey.Enter)
                                {
                                    if (player.Def + player.ADef > WolfAtk)
                                    {
                                        PlayerCurrentHp -= 1;
                                        if (player.Atk + player.WAtk < WolfDef)
                                        {
                                            WolfCurrentHp -= 1;
                                        }
                                        else
                                        {
                                            PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                        }
                                    }
                                    else
                                    {
                                        WolfCurrentHp -= ((player.Atk + player.WAtk) - WolfDef);
                                        if (player.Atk + player.WAtk < WolfDef)
                                        {
                                            WolfCurrentHp -= 1;
                                        }
                                        else
                                        {
                                            PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                        }
                                    }

                                    Console.Clear();
                                }
                                else if (attack.Key == ConsoleKey.Escape)
                                {
                                    Battle();
                                    break;
                                }
                            }
                            else if (PlayerCurrentHp <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("패배하였습니다.");
                                player.Gold -= WolfHp / 2;
                                Console.WriteLine($"{WolfHp / 2}골드를 잃었습니다.");
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(" ______________");
                                Console.WriteLine("/|돌아가기(esc)|");
                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                {
                                    FixTitle();
                                    break;
                                }
                            }
                            else if (WolfCurrentHp <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("늑대를 물리쳤습니다.");
                                player.Exp += WolfHp / 10;
                                player.Gold += WolfHp;
                                Console.WriteLine($"경험치{WolfHp / 10}  획득");
                                Console.WriteLine($"골드 {WolfHp} 획득");
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");
                                Console.WriteLine(" ______________      ___________");
                                Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                                var enter = Console.ReadKey(intercept: true);
                                if (enter.Key == ConsoleKey.Escape)
                                {
                                    Battle();
                                    break;
                                }
                                else if (enter.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    WolfHp += 100;
                                    WolfCurrentHp = WolfHp;
                                    WolfAtk += 1;
                                    WolfDef += 1;
                                    while (true)
                                    {
                                        if (WolfCurrentHp > 0)
                                        {
                                            Console.WriteLine("늑대 사냥터2");
                                            Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                            Console.WriteLine("늑대");
                                            Console.WriteLine($"Hp:{WolfCurrentHp}/{WolfHp}");
                                            Console.WriteLine($"공격력:{WolfAtk} 방어력:{WolfDef}");
                                            if (30 < WolfCurrentHp && WolfCurrentHp < 100)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  /_\  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp == 100)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  O_O  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp <= 30)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  X_X  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            Console.WriteLine(" ____________    ____________");
                                            Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                            var attack = Console.ReadKey(intercept: true);
                                            if (attack.Key == ConsoleKey.Enter)
                                            {
                                                if (player.Def + player.ADef > WolfAtk)
                                                {
                                                    PlayerCurrentHp -= 1;
                                                    if (player.Atk + player.WAtk < WolfDef)
                                                    {
                                                        WolfCurrentHp -= 1;
                                                    }
                                                    else
                                                    {
                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                                    }
                                                }
                                                else
                                                {
                                                    WolfCurrentHp -= ((player.Atk + player.WAtk) - WolfDef);
                                                    if (player.Atk + player.WAtk < WolfDef)
                                                    {
                                                        WolfCurrentHp -= 1;
                                                    }
                                                    else
                                                    {
                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                                    }
                                                }
                                                Console.Clear();
                                            }
                                            else if (attack.Key == ConsoleKey.Escape)
                                            {
                                                Battle();
                                                break;
                                            }
                                        }
                                        else if (PlayerCurrentHp <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("패배하였습니다.");
                                            player.Gold -= WolfHp / 2;
                                            Console.WriteLine($"{WolfHp / 2}골드를 잃었습니다.");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.WriteLine(" ______________");
                                            Console.WriteLine("/|돌아가기(esc)|");
                                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                            {
                                                FixTitle();
                                                break;
                                            }
                                        }
                                        else if (WolfCurrentHp <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("늑대를 물리쳤습니다.");
                                            player.Exp += WolfHp / 20;
                                            player.Gold += WolfHp;
                                            Console.WriteLine($"경험치{WolfHp / 20}  획득");
                                            Console.WriteLine($"골드 {WolfHp} 획득");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("\n");
                                            Console.WriteLine(" ______________      ___________");
                                            Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                                            enter = Console.ReadKey(intercept: true);
                                            if (enter.Key == ConsoleKey.Escape)
                                            {
                                                Battle();
                                                break;
                                            }
                                            else if (enter.Key == ConsoleKey.Enter)
                                            {
                                                Console.Clear();
                                                WolfHp += 100;
                                                WolfCurrentHp = WolfHp;
                                                WolfAtk += 1;
                                                WolfDef += 1;
                                                while (true)
                                                {
                                                    if (WolfCurrentHp > 0)
                                                    {
                                                        Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                        Console.WriteLine("늑대 사냥터3");
                                                        Console.WriteLine("늑대");
                                                        Console.WriteLine($"Hp:{WolfCurrentHp}/{WolfHp}");
                                                        Console.WriteLine($"공격력:{WolfAtk} 방어력:{WolfDef}");
                                                        if (30 < WolfCurrentHp && WolfCurrentHp < 100)
                                                        {
                                                            Console.WriteLine(@" /\---/\");
                                                            Console.WriteLine(@"<  /_\  >");
                                                            Console.WriteLine(@" <__U__>  ");
                                                        }
                                                        else if (WolfCurrentHp == 100)
                                                        {
                                                            Console.WriteLine(@" /\---/\");
                                                            Console.WriteLine(@"<  O_O  >");
                                                            Console.WriteLine(@" <__U__>  ");
                                                        }
                                                        else if (WolfCurrentHp <= 30)
                                                        {
                                                            Console.WriteLine(@" /\---/\");
                                                            Console.WriteLine(@"<  X_X  >");
                                                            Console.WriteLine(@" <__U__>  ");
                                                        }
                                                        Console.WriteLine(" ____________    ____________");
                                                        Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                        var attack = Console.ReadKey(intercept: true);
                                                        if (attack.Key == ConsoleKey.Enter)
                                                        {
                                                            if (player.Def + player.ADef > WolfAtk)
                                                            {
                                                                PlayerCurrentHp -= 1;
                                                                if (player.Atk + player.WAtk < WolfDef)
                                                                {
                                                                    WolfCurrentHp -= 1;
                                                                }
                                                                else
                                                                {
                                                                    PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                WolfCurrentHp -= ((player.Atk + player.WAtk) - WolfDef);
                                                                if (player.Atk + player.WAtk < WolfDef)
                                                                {
                                                                    WolfCurrentHp -= 1;
                                                                }
                                                                else
                                                                {
                                                                    PlayerCurrentHp -= ((player.Def + player.ADef) - WolfAtk);
                                                                }
                                                            }
                                                            Console.Clear();
                                                        }
                                                        else if (attack.Key == ConsoleKey.Escape)
                                                        {
                                                            Battle();
                                                            break;
                                                        }
                                                    }
                                                    else if (PlayerCurrentHp <= 0)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("패배하였습니다.");
                                                        player.Gold -= WolfHp / 2;
                                                        Console.WriteLine($"{WolfHp / 2}골드를 잃었습니다.");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine(" ______________");
                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                        {
                                                            FixTitle();
                                                            break;
                                                        }
                                                    }
                                                    else if (WolfCurrentHp <= 0)
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("늑대를 물리쳤습니다.");
                                                        player.Exp += WolfHp / 20;
                                                        player.Gold += WolfHp;
                                                        Console.WriteLine($"경험치{WolfHp / 20}  획득");
                                                        Console.WriteLine($"골드 {WolfHp} 획득");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine("\n");
                                                        Console.WriteLine(" ______________     ____________");
                                                        Console.WriteLine("/|돌아가기(esc)|   /|다음(enter)|");
                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                        {
                                                            Battle();
                                                            break;
                                                        }
                                                        else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                        {
                                                            Console.WriteLine("이 앞은 보스 달빛 늑대(추천레벨 10+)가 존재합니다.");
                                                            Console.WriteLine("정말 들어가시겠습니까?");
                                                            Console.WriteLine("\n");
                                                            Console.WriteLine(" ________________    ______________");
                                                            Console.WriteLine("/|들어가기(enter)|  /|돌아가기(esc)|");
                                                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                            {
                                                                Battle();
                                                                break;
                                                            }
                                                            else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                            {
                                                                Console.Clear();
                                                                int LunaWolfHp = 10000;
                                                                int LunaWolfAtk = 500;
                                                                int LunaWolfDef = 500;
                                                                int LunaWolfCurrentHp = LunaWolfHp;
                                                                int PlayerKingCurrentHp = player.Hp;
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine(" ");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-/");
                                                                Console.WriteLine(@"   /  /");
                                                                Console.WriteLine(@"  |  |");
                                                                Console.WriteLine(@"   \  \");
                                                                Console.WriteLine(@"     -__\");
                                                                Console.ResetColor();
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _---/");
                                                                Console.WriteLine(@"   /    /");
                                                                Console.WriteLine(@"  |    |");
                                                                Console.WriteLine(@"   \    \");
                                                                Console.WriteLine(@"     -___\");
                                                                Console.ResetColor();
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _----|");
                                                                Console.WriteLine(@"   /      |");
                                                                Console.WriteLine(@"  |       |");
                                                                Console.WriteLine(@"   \      |");
                                                                Console.WriteLine(@"     -____|");
                                                                Console.ResetColor();
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-----\");
                                                                Console.WriteLine(@"   /        \ ");
                                                                Console.WriteLine(@"  |          | ");
                                                                Console.WriteLine(@"   \       _/");
                                                                Console.WriteLine(@"     -____/");
                                                                Console.ResetColor();
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(500);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.WriteLine(@"  |             |");
                                                                Console.WriteLine(@"   \           /");
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.WriteLine("\n");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(100);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.WriteLine(@"  |             |");
                                                                Console.WriteLine(@"   \           /");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine("         ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine("         --");
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(100);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.WriteLine(@"  |             |");
                                                                Console.WriteLine(@"   \           /");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine("         ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine("      -|-");
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine("          ");
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(100);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(@"  |             |");
                                                                Console.WriteLine(@"   \           /");
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"     __|__         ");
                                                                Console.WriteLine(@"       |         ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(100);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(@"  |             |");
                                                                Console.WriteLine(@"   \           /");
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"       .          ");
                                                                Console.WriteLine(@"    ___|___         ");
                                                                Console.WriteLine(@"       |         ");
                                                                Console.WriteLine(@"       '          ");
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(100);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     _-------_");
                                                                Console.WriteLine(@"   /           \");
                                                                Console.WriteLine(@"  |             |");
                                                                Console.ForegroundColor = ConsoleColor.White;
                                                                Console.WriteLine(@"   \           /");
                                                                Console.WriteLine(@"     -_______-");
                                                                Console.ResetColor();
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"       /\             ");
                                                                Console.WriteLine(@"    <  --  >        ");
                                                                Console.WriteLine(@"       \/         ");
                                                                Console.WriteLine(@"                    ");
                                                                Console.WriteLine(@"      _--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(300);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"      _-------_");
                                                                Console.WriteLine(@"    /           \");
                                                                Console.WriteLine(@"   |             |");
                                                                Console.WriteLine(@"    \           /");
                                                                Console.WriteLine(@"      -_______-");
                                                                Console.ResetColor();
                                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                Console.WriteLine(@"     |\_  _/\   ");
                                                                Console.WriteLine(@"     |  \/   |");
                                                                Console.WriteLine(@"     <        \__");
                                                                Console.WriteLine(@"     \           \");
                                                                Console.WriteLine(@"     |           |");
                                                                Console.WriteLine(@"     |          /");
                                                                Console.Write(@"     |");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"_--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(300);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     ");
                                                                Console.WriteLine(@"      _-------_");
                                                                Console.WriteLine(@"    /           \");
                                                                Console.WriteLine(@"   |             |");
                                                                Console.WriteLine(@"    \           /");
                                                                Console.ResetColor();
                                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                Console.Write(@"    \_");
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write("-_______-");
                                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                Console.WriteLine(@" /\   ");
                                                                Console.WriteLine(@"     \ \______/       |");
                                                                Console.WriteLine(@"     <                \_");
                                                                Console.WriteLine(@"     \                  \");
                                                                Console.WriteLine(@"     |                  |");
                                                                Console.WriteLine(@"     |                 /");
                                                                Console.Write(@"     |");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine(@"_--\_");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(300);
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine(@"     ");
                                                                Console.WriteLine(@"     ");
                                                                Console.WriteLine(@"        _-------_");
                                                                Console.WriteLine(@"      /           \");
                                                                Console.WriteLine(@"     |             |");
                                                                Console.ResetColor();
                                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                Console.Write(@"    \_");
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.Write(@"\           /");
                                                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                Console.WriteLine(@" /\   ");
                                                                Console.WriteLine(@"     \ \__________/   |");
                                                                Console.WriteLine(@"     <                \_");
                                                                Console.WriteLine(@"     \                  \");
                                                                Console.WriteLine(@"     |                  |");
                                                                Console.WriteLine(@"     |               __/");
                                                                Console.Write(@"     |");
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.Write(@"_--\_");
                                                                Console.WriteLine(@"         /");
                                                                Console.WriteLine(@"    _/ , . \_");
                                                                Console.WriteLine(@"  _/  _  \   |");
                                                                Console.WriteLine(@" /   /    \   \");
                                                                Console.WriteLine(@"{______________} ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                Console.BackgroundColor = ConsoleColor.White;
                                                                Console.WriteLine("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  ");
                                                                Console.ResetColor();
                                                                Thread.Sleep(1000);
                                                                while (true)
                                                                {
                                                                    if (LunaWolfCurrentHp > 0)
                                                                    {
                                                                        Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerKingCurrentHp}/{player.Hp}");
                                                                        Console.WriteLine("보스의 방2");
                                                                        Console.WriteLine("달빛 늑대 ");
                                                                        Console.WriteLine($"Hp:{LunaWolfCurrentHp}/{LunaWolfHp}");
                                                                        Console.WriteLine($"공격력:{LunaWolfAtk} 방어력:{LunaWolfDef}");
                                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                                        Console.WriteLine("턴마다 공격력 증가");
                                                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                        if (1500 < LunaWolfCurrentHp && LunaWolfCurrentHp < 5000)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"|\    /|");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"\.\  /./");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" / _");
                                                                            Console.WriteLine(@" < \ || /  >/ |");
                                                                            Console.WriteLine(@" /\ /__\ /|/  |  ");
                                                                            Console.WriteLine(@"<   ----  >   | ");
                                                                            Console.Write(@" \   |");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"\\\");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" >__/");
                                                                            Console.Write(@" |  / ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"|||");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |\| ");
                                                                            Console.WriteLine(@" \ |   _/ ");
                                                                            Console.WriteLine(@"  /\/\/\| |");
                                                                        }
                                                                        else if (LunaWolfCurrentHp == 5000)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"__    __");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@"/| ");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"\.\  /./");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" / _");
                                                                            Console.WriteLine(@" < \ __ /  >/ |");
                                                                            Console.WriteLine(@" /\ /__\ /|/  |  ");
                                                                            Console.WriteLine(@"<   ----  >   | ");
                                                                            Console.WriteLine(@" \   |    >__/");
                                                                            Console.WriteLine(@" |  /     |\| ");
                                                                            Console.WriteLine(@" \ |   _/ ");
                                                                            Console.WriteLine(@"  /\/\/\| |");
                                                                        }
                                                                        else if (LunaWolfCurrentHp <= 1500)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"///");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"   /|");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"|||");
                                                                            Console.ForegroundColor = ConsoleColor.White;
                                                                            Console.Write(@"  /./");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" / _");
                                                                            Console.WriteLine(@" < \ || /  >/ |");
                                                                            Console.WriteLine(@" /\ /__\ /|/  |  ");
                                                                            Console.WriteLine(@"<   ----  >   | ");
                                                                            Console.Write(@" \   |");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"\\\");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" >__/");
                                                                            Console.Write(@" |  / ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"|||");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |\| ");
                                                                            Console.WriteLine(@" \ |   _/ ");
                                                                            Console.WriteLine(@"  /\/\/\| |");
                                                                        }
                                                                        Console.ResetColor();
                                                                        Console.WriteLine(" ____________    ____________");
                                                                        Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                                        {
                                                                            if (player.Def + player.ADef > LunaWolfAtk)
                                                                            {
                                                                                PlayerCurrentHp -= 1;
                                                                                if (player.Atk + player.WAtk < LunaWolfDef)
                                                                                {
                                                                                    LunaWolfCurrentHp -= 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    PlayerCurrentHp -= ((player.Def + player.ADef) - LunaWolfAtk);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                LunaWolfCurrentHp -= ((player.Atk + player.WAtk) - LunaWolfDef);
                                                                                if (player.Atk + player.WAtk < LunaWolfDef)
                                                                                {
                                                                                    LunaWolfCurrentHp -= 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    PlayerCurrentHp -= ((player.Def + player.ADef) - LunaWolfAtk);
                                                                                }
                                                                            }
                                                                            LunaWolfAtk *= 2;
                                                                            Console.Clear();
                                                                            if (LunaWolfCurrentHp < 0)
                                                                            {
                                                                                if (AC.ACWolf == false)
                                                                                {
                                                                                    Random random = new Random();
                                                                                    int rn = random.Next(1, 11);
                                                                                    if (rn == 1)
                                                                                    {
                                                                                        AC.ACWolf = true;
                                                                                        Console.Clear();
                                                                                        Console.WriteLine("달빛 늑대를 물리쳤습니다.");
                                                                                        player.Exp += LunaWolfHp / 10;
                                                                                        player.Gold += LunaWolfHp;
                                                                                        Console.WriteLine("경험치 500 획득");
                                                                                        Console.WriteLine("골드 5000 획득");
                                                                                        Console.WriteLine("달빛 늑대의 증표 획득");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine(" ______________");
                                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                                        {
                                                                                            Battle();
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.Clear();
                                                                                        Console.WriteLine("달빛 늑대를 물리쳤습니다.");
                                                                                        player.Exp += LunaWolfHp / 10;
                                                                                        player.Gold += LunaWolfHp;
                                                                                        Console.WriteLine("경험치 500 획득");
                                                                                        Console.WriteLine("골드 5000 획득");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine("\n");
                                                                                        Console.WriteLine(" ______________");
                                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                                        {
                                                                                            Battle();
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.Clear();
                                                                                    Console.WriteLine("달빛 늑대 를 물리쳤습니다.");
                                                                                    player.Exp += LunaWolfHp / 10;
                                                                                    player.Gold += LunaWolfHp;
                                                                                    Console.WriteLine("경험치 500 획득");
                                                                                    Console.WriteLine("골드 5000 획득");
                                                                                    Console.WriteLine("\n");
                                                                                    Console.WriteLine("\n");
                                                                                    Console.WriteLine("\n");
                                                                                    Console.WriteLine(" ______________");
                                                                                    Console.WriteLine("/|돌아가기(esc)|");
                                                                                }
                                                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                                {
                                                                                    Battle();
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (start.Key == ConsoleKey.Escape)
                {
                    FixTitle();
                }
                else if (start.Key == ConsoleKey.RightArrow)
                {
                    FixTitle();
                }
            }
            else if (start.Key == ConsoleKey.Escape)
            {
                FixTitle();
            }
        }
        public static void Equip()
        {
            Console.WriteLine("가방");
            if (backpack.weapon == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|무기(w)|");
            }
            if (backpack.armor == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|갑옷(a)|");
            }
            if (backpack.skill == true)
            {
                Console.WriteLine(" ________");
                Console.WriteLine("/|스킬(s)|");
            }
            var equip = Console.ReadKey();
            if (backpack.weapon == true)
            {
                if (equip.Key == ConsoleKey.W)
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
                    if (backpack.stone == true)
                    {
                        num++;
                        w3 = num;
                        Console.WriteLine($"[{w3}]철 검");
                    }
                    if (backpack.stone == true)
                    {
                        num++;
                        w4 = num;
                        Console.WriteLine($"[{w4}]신의 검");
                    }
                    if (backpack.stone == true)
                    {
                        num++;
                        w5 = num;
                        Console.WriteLine($"[{w5}]일반 스태프");
                    }
                    if (backpack.stone == true)
                    {
                        num++;
                        w6 = num;
                        Console.WriteLine($"[{w6}]크리스탈 스태프");
                    }
                    if (backpack.stone == true)
                    {
                        num++;
                        w7 = num;
                        Console.WriteLine($"[{w7}]다이아몬드 스태프");
                    }
                    if (backpack.stone == true)
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
                            if (w1 == 1)
                            {
                                Console.WriteLine("나무 검");
                                Console.WriteLine("공격력 + 100 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     조잡한 성능. 나무검에게 뭘 바라나? ");
                                Console.WriteLine("     고작 나무검의 성능을 뛰어나게 만들 수 있는 능력자면  ");
                                Console.WriteLine("     나무검을 안만들었다. 몽둥이나 다름없다. ");
                            }
                            if (w2 == 2)
                            {
                                Console.WriteLine("돌 검");
                                Console.WriteLine("공격력 + 100 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     그냥 날을 갈아서, 나무에 붙였다. ");
                                Console.WriteLine("     절삭력은 사과를 벨 수 있을 정도.");
                            }
                            if (w3 == 3)
                            {
                                Console.WriteLine("철 검");
                                Console.WriteLine("공격력 + 100 ");
                                Console.WriteLine("설명:");
                                Console.WriteLine("     검이라고 봐줄만한 검. ");
                                Console.WriteLine("     평민도 이정도는 살 수 있다.");
                            }
                            if (w4 == 4)
                            {

                            }
                            if (w5 == 5)
                            {

                            }
                            if (w6 == 6)
                            {

                            }
                            if (w7 == 7)
                            {

                            }
                            if (w8 == 8)
                            {

                            }
                        }
                    }

                }
            }
            if (backpack.armor == true)
            {
                if (equip.Key == ConsoleKey.A)
                {

                }
            }
            if (backpack.skill == true)
            {
                if (equip.Key == ConsoleKey.S)
                {

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
                    player.Exp -= 10;
                    player.Lv += 1;
                    player.Hp += 100;
                    player.Mp += 50;
                    player.Atk += 10;
                    player.Def += 10;
                    Console.WriteLine("Hp 100 증가");
                    Console.WriteLine("Mp 50 증가");
                    Console.WriteLine("Atk 10 증가");
                    Console.WriteLine("Def 10 증가");
                    Console.WriteLine(" ______________    ______________");
                    Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Spacebar)
                    {
                        LvUp();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("경험치 부족");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine(" ______________");
                        Console.WriteLine("/|돌아가기(esc)|");
                        if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                        {
                            FixTitle();
                            break;
                        }
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
                        Console.WriteLine("Def 10 증가");
                        Console.WriteLine(" ______________    ______________");
                        Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                    }
                    else
                    {
                        Console.WriteLine("경험치 부족");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        Console.WriteLine(" ______________");
                        Console.WriteLine("/|돌아가기(esc)|");
                        if (Console.ReadKey(intercept:true).Key == ConsoleKey.Escape)
                        {
                            FixTitle();
                            break;
                        }
                    }
                }
                else
                {
                    if (player.Lv == 10)
                    {
                        Console.WriteLine("승급필요");
                    }
                    else if (player.Lv < 20)
                    {
                        Console.WriteLine("레벨업!");
                        if (player.Exp >= (player.Lv - 10) * 200)
                        {
                            player.Exp -= (player.Lv - 10) * 200;
                            player.Lv += 1;
                            player.Hp += 500;
                            player.Mp += 250;
                            player.Atk += 50;
                            player.Def += 25;
                            Console.WriteLine("Hp 500 증가");
                            Console.WriteLine("Mp 250 증가");
                            Console.WriteLine("Atk 50 증가");
                            Console.WriteLine("Def 25 증가");
                            Console.WriteLine(" ______________    ______________");
                            Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Spacebar)
                            {
                                LvUp();
                                break;
                            }
                            else if (Console.ReadKey(intercept : true).Key == ConsoleKey.Escape)
                            {
                                FixTitle(); 
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("경험치 부족");
                            Console.WriteLine("\n");
                            Console.WriteLine("\n");
                            Console.WriteLine("\n");
                            Console.WriteLine(" ______________");
                            Console.WriteLine("/|돌아가기(esc)|");
                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                            {
                                FixTitle();
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (player.Lv == 20)
                        {
                            Console.WriteLine("승급필요");
                        }
                        else if (player.Lv < 30)
                        {
                            Console.WriteLine("레벨업!");
                            player.Exp -= (player.Lv - 20) * 4000;
                            player.Lv += 1;
                            player.Hp += 2500;
                            player.Mp += 1250;
                            player.Atk += 250;
                            player.Def += 125;
                            Console.WriteLine("Hp 1000 증가");
                            Console.WriteLine("Mp 500 증가");
                            Console.WriteLine("Atk 100 증가");
                            Console.WriteLine("Def 100 증가");
                            Console.WriteLine(" ______________    ______________");
                            Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                        }
                        else
                        {
                            if (player.Lv == 30)
                            {
                                Console.WriteLine("승급필요");
                            }
                            else if (player.Lv < 40)
                            {
                                Console.WriteLine("레벨업!");
                                player.Exp -= (player.Lv - 30) * 80000;
                                player.Lv += 1;
                                player.Hp += 10000;
                                player.Mp += 5000;
                                player.Atk += 1000;
                                player.Def += 500;
                                Console.WriteLine("Hp 10000 증가");
                                Console.WriteLine("Mp 5000 증가");
                                Console.WriteLine("Atk 1000 증가");
                                Console.WriteLine("Def 500 증가");
                                Console.WriteLine(" ______________    ______________");
                                Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                            }
                            else
                            {
                                if (player.Lv == 40)
                                {
                                    Console.WriteLine("승급필요");
                                }
                                else if (player.Lv < 50)
                                {
                                    Console.WriteLine("레벨업!");
                                    player.Exp -= (player.Lv - 40) * 1600000;
                                    player.Lv += 1;
                                    player.Hp += 100000;
                                    player.Mp += 25000;
                                    player.Atk += 5000;
                                    player.Def += 2500;
                                    Console.WriteLine("Hp 4000 증가");
                                    Console.WriteLine("Mp 2000 증가");
                                    Console.WriteLine("Atk 400 증가");
                                    Console.WriteLine("Def 400 증가");
                                    Console.WriteLine(" ______________    ______________");
                                    Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                                }
                                else
                                {
                                    if (player.Lv == 50)
                                    {
                                        Console.WriteLine("승급필요");
                                    }
                                    else if (player.Lv < 60)
                                    {
                                        Console.WriteLine("레벨업!");
                                        player.Exp -= (player.Lv - 50) * 32000000;
                                        player.Lv += 1;
                                        player.Hp += 250000;
                                        player.Mp += 125000;
                                        player.Atk += 25000;
                                        player.Def += 12500;
                                        Console.WriteLine("Hp 8000 증가");
                                        Console.WriteLine("Mp 4000 증가");
                                        Console.WriteLine("Atk 800 증가");
                                        Console.WriteLine("Def 800 증가");
                                        Console.WriteLine(" ______________    ______________");
                                        Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                                    }
                                    else
                                    {
                                        if (player.Lv == 60)
                                        {
                                            Console.WriteLine("승급필요");
                                        }
                                        else if (player.Lv < 70)
                                        {
                                            Console.WriteLine("레벨업!");
                                            player.Exp -= (player.Lv - 60) * 640000000;
                                            player.Lv += 1;
                                            player.Hp += 4500000;
                                            player.Mp += 2250000;
                                            player.Atk += 45000;
                                            player.Def += 22500;
                                            Console.WriteLine("Hp 16000 증가");
                                            Console.WriteLine("Mp 8000 증가");
                                            Console.WriteLine("Atk 1600 증가");
                                            Console.WriteLine("Def 1600 증가");
                                            Console.WriteLine(" ______________    ______________");
                                            Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                                        }
                                        else
                                        {
                                            if (player.Lv == 70)
                                            {
                                                Console.WriteLine("더이상 레벨업이 불가합니다");
                                            }
                                            else
                                            {
                                                Console.WriteLine("경험치가 부족합니다");
                                                FixTitle();
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
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
                    player.Hp += 4000;
                    player.Mp += 2000;
                    player.Atk += 400;
                    player.Def += 200;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 4000 증가");
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
                    player.Hp += 15000;
                    player.Mp += 7500;
                    player.Atk += 1500;
                    player.Def += 750;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 15000 증가");
                    Console.WriteLine("공격력 1500 증가");
                    Console.WriteLine("방어력 750 증가");
                }
            }
            else if (player.Lv == 30)
            {
                if (AC.ACslime == false)
                {
                    player.Lv += 1;
                    player.Exp -= 8000;
                    player.Hp += 50000;
                    player.Mp += 25000;
                    player.Atk += 5000;
                    player.Def += 2500;
                    Console.WriteLine("(한계)레벨 증가");
                    Console.WriteLine("체력 50000 증가");
                    Console.WriteLine("공격력 5000 증가");
                    Console.WriteLine("방어력 2500 증가");
                }
                else
                {
                    Console.WriteLine("미구현");
                    Console.WriteLine(" ______________");
                    Console.WriteLine("/|돌아가기(esc)|");
                    if (Console.ReadKey(intercept:true).Key == ConsoleKey.Escape)
                    {
                        FixTitle();
                    }
                }
            }
            else if (player.Lv == 40)
            {
                player.Lv += 1;
                player.Exp -= 160000;
                player.Hp += 300000;
                player.Mp += 150000;
                player.Atk += 30000;
                player.Def += 15000;
                Console.WriteLine("(한계)레벨 증가");
                Console.WriteLine("체력 50000 증가");
                Console.WriteLine("공격력 5000 증가");
                Console.WriteLine("방어력 2500 증가");
            }
            else if (player.Lv == 50)
            {
                player.Lv += 1;
                player.Exp -= 3200000;
                player.Hp += 1500000;
                player.Mp += 750000;
                player.Atk += 150000;
                player.Def += 75000;
            }
            else if (player.Lv == 60)
            {
                player.Lv += 1;
                player.Exp -= 64000000;
                player.Hp += 5000000;
                player.Mp += 2500000;
                player.Atk += 500000;
                player.Def += 250000;
            }
            else if (player.Lv == 70)
            {
                player.Lv += 1;
                player.Exp = 0;
                player.Hp += 45000000;
                player.Mp += 22500000;
                player.Atk += 4500000;
                player.Def += 2250000;
            }
        }
        public static void FixTitle()
        {
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
            Console.WriteLine("|사냥(B)|  |상점(S)|");
            Console.WriteLine(" =======    =======");
            if (player.Gold < 0)
            {
                player.Gold = 0;
            }
            if (player.Lv < 10)
            {
                if (player.Exp >= player.Lv * 10)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 10)
            {
                if (player.Exp >= 100)
                {
                    Console.WriteLine(" ___________ ");
                    Console.WriteLine("|승급(Space)|");
                    Console.WriteLine(" =========== ");
                }
            }
            else if (player.Lv < 20)
            {
                if (player.Exp >= (player.Lv - 10) * 200)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if
                (player.Lv == 20)
            {
                if (player.Exp >= 2000)
                {
                    Console.WriteLine(" ___________ ");
                    Console.WriteLine("|승급(Space)|");
                    Console.WriteLine(" =========== ");
                }
            }
            else if (player.Lv < 30)
            {
                if (player.Exp >= (player.Lv - 20) * 4000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 30)
            {
                if (player.Exp >= 40000)
                {
                    Console.WriteLine(" ___________ ");
                    Console.WriteLine("|승급(Space)|");
                    Console.WriteLine(" =========== ");
                }
            }
            else if (player.Lv < 40)
            {
                if (player.Exp >= (player.Lv - 30) * 80000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 40)
            {
                if (player.Exp >= 800000)
                {
                    Console.WriteLine(" ___________ ");
                    Console.WriteLine("|승급(Space)|");
                    Console.WriteLine(" =========== ");
                }
            }
            else if (player.Lv < 50)
            {
                if (player.Exp >= (player.Lv - 40) * 1600000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 50)
            {
                if (player.Exp >= 16000000)
                Console.WriteLine(" ___________ ");
                Console.WriteLine("|승급(Space)|");
                Console.WriteLine(" =========== ");
            }
            else if (player.Lv < 60)
            {
                if (player.Exp >= (player.Lv - 50) * 32000000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 60)
            {
                if (player.Exp >= 320000000)
                Console.WriteLine(" ___________ ");
                Console.WriteLine("|승급(Space)|");
                Console.WriteLine(" =========== ");
            }
            else if (player.Lv < 70)
            {
                if (player.Exp >= (player.Lv - 60) * 640000000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 70)
            {
                if (player.Exp >= 999999999)
                {
                    Console.WriteLine(" ___________");
                    Console.WriteLine("|승급(Space)|");
                    Console.WriteLine(" =========== ");
                }
            }
           
            var introduce = Console.ReadKey(intercept: true);
            if (player.Gold < 0)
            {
                player.Gold = 0;
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
                    Console.WriteLine("Def: " + player.Def + $"({player.Def + player.ADef})");
                    Console.WriteLine("Gold: " + player.Gold);
                    Console.WriteLine("Armor: " + player.armor);
                    Console.WriteLine("Weapon: " + player.weapon);
                    Console.WriteLine(" ______________");
                    Console.WriteLine("/|돌아가기(esc)|");
                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                    {
                        FixTitle();
                        break;
                    }
                }
                else if (introduce.Key == ConsoleKey.B)
                {
                    Battle();
                    break;
                }
                else if (introduce.Key == ConsoleKey.E)
                {
                    Equip();
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


