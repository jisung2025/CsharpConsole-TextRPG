using System;
using System.Collections.Generic;
using System.IO;

namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Text RPG Start");
            Console.WriteLine("Press escape to exit...");
            var start = Console.ReadKey(intercept: true);
            if (start.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Text RPG End");
            }
            else if (start.Key == ConsoleKey.Enter)
            {
                FixTitle();
                while (true)
                {
                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                    {
                        FixTitle();
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
            public int Atk = 10;
            public int WAtk = 0;
            public int Def = 0;
            public int ADef = 0;
            public int Gold = 0;
            public Armor armor = Armor.None;
            public WeaponType weapon = WeaponType.Fist;

        }
        public static class Backpack
        {
            public static bool Leather = false;
            public static bool Chainmail = false;
            public static bool Fullplate = false;
            public static bool God = false;
            public static bool wood = false;
            public static bool stone = false;
            public static bool iron = false;
            public static bool god = false;
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
        private static Character player = new Character();
        public static void Shop()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine(" ________________    ____________    ____________");
            Console.WriteLine("/|구매하기(enter)|  /|판매하기(e)|  /|떠나기(esc)|");
            var buy = Console.ReadKey(intercept: true);
            var sell = Console.ReadKey(intercept: true);
            var leave = Console.ReadKey(intercept: true);
            if (buy.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine(" ________    ________    ____________");
                Console.WriteLine("/|갑옷(1)|  /|무기(2)|  /|돌아가기(esc)|");
                var armor = Console.ReadKey(intercept: true);
                var weapon = Console.ReadKey(intercept: true);
                var back = Console.ReadKey(intercept: true);
                if (armor.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("가죽갑옷(100)");
                    Console.WriteLine("사슬갑옷(4000)");
                    Console.WriteLine("풀플레이트갑옷(100000)");
                    Console.WriteLine("신의 갑옷(999999999)");
                    Console.WriteLine("\n");
                    Console.WriteLine(" _______________      ______________");
                    Console.WriteLine("/|선택하기(번호)|    /|돌아가기(esc)|");
                    var leather = Console.ReadKey(intercept: true);
                    var chain = Console.ReadKey(intercept: true);
                    var fullplate = Console.ReadKey(intercept: true);
                    var god = Console.ReadKey(intercept: true);
                    back = Console.ReadKey(intercept: true);
                    if (leather.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 100)
                        {
                            player.Gold -= 100;
                            Backpack.Leather = true;
                        }
                    }
                    else if (chain.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 4000)
                        {
                            player.Gold -= 4000;
                            Backpack.Chainmail = true;
                        }
                    }
                    else if (fullplate.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 100000)
                        {
                            player.Gold -= 100000;
                            Backpack.Fullplate = true;
                        }
                    }
                    else if (god.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 999999999)
                        {
                            player.Gold -= 999999999;
                            Backpack.God = true;
                        }
                    }
                    else if (back.Key == ConsoleKey.Escape)
                    {
                        Shop();
                    }
                }
                else if (weapon.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("나무검(100)");
                    Console.WriteLine("돌검(4000)");
                    Console.WriteLine("철검(100000)");
                    Console.WriteLine("신의 검(999999999)");
                    Console.WriteLine("\n");
                    Console.WriteLine(" _______________      ______________");
                    Console.WriteLine("/|선택하기(번호)|    /|돌아가기(esc)|");
                    var wood = Console.ReadKey(intercept: true);
                    var stone = Console.ReadKey(intercept: true);
                    var iron = Console.ReadKey(intercept: true);
                    var god = Console.ReadKey(intercept: true);
                    back = Console.ReadKey(intercept: true);
                    if (wood.Key == ConsoleKey.D1)
                    {
                        if (player.Gold >= 100)
                        {
                            player.Gold -= 100;
                            Backpack.wood = true;
                        }
                    }
                    else if (stone.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 4000)
                        {
                            player.Gold -= 4000;
                            Backpack.stone = true;
                        }
                    }
                    else if (iron.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 100000)
                        {
                            player.Gold -= 100000;
                            Backpack.iron = true;
                        }
                    }
                    else if (god.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 999999999)
                        {
                            player.Gold -= 999999999;
                            Backpack.god = true;
                        }
                    }
                    else if (back.Key == ConsoleKey.Escape)
                    {
                        Shop();
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
                            SlimeCurrentHp -= (player.Atk - SlimeDef);
                            PlayerCurrentHp -= (SlimeAtk - player.Def);
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
                        player.Gold -= 50;
                        Console.WriteLine("50골드를 잃었습니다.");
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
                    else if (SlimeCurrentHp <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("슬라임을 물리쳤습니다.");
                        player.Exp += 5;
                        player.Gold += 100;
                        Console.WriteLine("경험치 5 획득");
                        Console.WriteLine("골드 100 획득");
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
                            SlimeHp += 100;
                            SlimeCurrentHp = SlimeHp;
                            SlimeAtk += 1;
                            SlimeDef += 1;
                            while (true)
                            {
                                if (SlimeCurrentHp > 0)
                                {
                                    Console.WriteLine("슬라임 사냥터2");
                                    Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                    Console.WriteLine("슬라임");
                                    Console.WriteLine($"Hp:{SlimeCurrentHp}/{SlimeHp}");
                                    Console.WriteLine($"공격력:{SlimeAtk} 방어력:{SlimeDef}");
                                    if (60 < SlimeCurrentHp && SlimeCurrentHp < 200)
                                    {
                                        Console.WriteLine(@"  ____");
                                        Console.WriteLine(@" | x x\_");
                                        Console.WriteLine(@"/________\");
                                    }
                                    else if (SlimeCurrentHp == 200)
                                    {
                                        Console.WriteLine(@"  ____");
                                        Console.WriteLine(@" | . .\_");
                                        Console.WriteLine(@"/________\");
                                    }
                                    else if (SlimeCurrentHp <= 60)
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
                                        SlimeCurrentHp -= (player.Atk - SlimeDef);
                                        PlayerCurrentHp -= (SlimeAtk - player.Def);
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
                                    player.Gold -= 100;
                                    Console.WriteLine("100골드를 잃었습니다.");
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
                                else if (SlimeCurrentHp <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("슬라임을 물리쳤습니다.");
                                    player.Exp += 10;
                                    player.Gold += 200;
                                    Console.WriteLine("경험치 10 획득");
                                    Console.WriteLine("골드 200 획득");
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
                                        SlimeHp += 100;
                                        SlimeCurrentHp = SlimeHp;
                                        SlimeAtk += 1;
                                        SlimeDef += 1;
                                        while (true)
                                        {
                                            if (SlimeCurrentHp > 0)
                                            {
                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                Console.WriteLine("슬라임 사냥터3");
                                                Console.WriteLine("슬라임");
                                                Console.WriteLine($"Hp:{SlimeCurrentHp}/{SlimeHp}");
                                                Console.WriteLine($"공격력:{SlimeAtk} 방어력:{SlimeDef}");
                                                if (90 < SlimeCurrentHp && SlimeCurrentHp < 300)
                                                {
                                                    Console.WriteLine(@"  ____");
                                                    Console.WriteLine(@" | x x\_");
                                                    Console.WriteLine(@"/________\");
                                                }
                                                else if (SlimeCurrentHp == 300)
                                                {
                                                    Console.WriteLine(@"  ____");
                                                    Console.WriteLine(@" | . .\_");
                                                    Console.WriteLine(@"/________\");
                                                }
                                                else if (SlimeCurrentHp <= 90)
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
                                                    SlimeCurrentHp -= (player.Atk - SlimeDef);
                                                    PlayerCurrentHp -= (SlimeAtk - player.Def);
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
                                                player.Gold -= 200;
                                                Console.WriteLine("200골드를 잃었습니다.");
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
                                            else if (SlimeCurrentHp <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("슬라임을 물리쳤습니다.");
                                                player.Exp += 15;
                                                player.Gold += 300;
                                                Console.WriteLine("경험치 15 획득");
                                                Console.WriteLine("골드 300 획득");
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
                                                else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                {
                                                    Console.WriteLine("이 앞은 보스 슬라임 킹(추천레벨 10)이 존재합니다.");
                                                    Console.WriteLine("정말 들어가시겠습니까?");
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine(" ________________    ______________");
                                                    Console.WriteLine("/|들어가기(enter)|  /|돌아가기(esc)|");
                                                    enter = Console.ReadKey(intercept: true);
                                                    var back = Console.ReadKey(intercept: true);
                                                    if (enter.Key == ConsoleKey.Escape)
                                                    {
                                                        Battle();
                                                        break;
                                                    }
                                                    else if (enter.Key == ConsoleKey.Enter)
                                                    {
                                                        Console.Clear();
                                                        int SlimeKingHp = 5000;
                                                        int SlimeKingAtk = 250 + 500;
                                                        int SlimeKingDef = 500;
                                                        int SlimeKingCurrentHp = SlimeKingHp;
                                                        int PlayerKingCurrentHp = player.Hp;
                                                        while (true)
                                                        {
                                                            if (SlimeKingCurrentHp > 0)
                                                            {
                                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerKingCurrentHp}/{player.Hp}");
                                                                Console.WriteLine("보스의 방1");
                                                                Console.WriteLine("슬라임 킹");
                                                                Console.WriteLine($"Hp:{SlimeKingCurrentHp}/{SlimeKingHp}");
                                                                Console.WriteLine($"공격력:{SlimeKingAtk} 방어력:{SlimeKingDef}");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("2턴마다 무적");
                                                                Console.ResetColor();
                                                                if (1500 < SlimeKingCurrentHp && SlimeKingCurrentHp < 5000)
                                                                {
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.WriteLine(@"    /___O___\");
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.WriteLine(@" _/   .l  l.   \_");
                                                                    Console.WriteLine(@"/________________\");
                                                                }
                                                                else if (SlimeKingCurrentHp == 5000)
                                                                {
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.WriteLine(@"    /___O___\");
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.WriteLine(@" _/ __ l  l __ \_");
                                                                    Console.WriteLine(@"/________________\");
                                                                }
                                                                else if (SlimeKingCurrentHp <= 1500)
                                                                {
                                                                    Console.WriteLine(@"     /\/\/\/\");
                                                                    Console.WriteLine(@"    /___O___\");
                                                                    Console.WriteLine(@"   |          |");
                                                                    Console.WriteLine(@" _/  ..1  1..  \_");
                                                                    Console.WriteLine(@"/____||____||____\");
                                                                }
                                                                Console.WriteLine(" ____________    ____________");
                                                                Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                                var attack = Console.ReadKey(intercept: true);
                                                                if (attack.Key == ConsoleKey.Enter)
                                                                {
                                                                    SlimeKingCurrentHp -= (player.Atk - SlimeKingDef);
                                                                    PlayerKingCurrentHp -= (SlimeKingAtk - player.Def);
                                                                    Console.Clear();
                                                                    if (SlimeKingCurrentHp < 0)
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("슬라임 킹을 물리쳤습니다.");
                                                                        player.Exp += 500;
                                                                        player.Gold += 5000;
                                                                        Console.WriteLine("경험치 500 획득");
                                                                        Console.WriteLine("골드 5000 획득");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine(" ______________");
                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                        if (enter.Key == ConsoleKey.Escape)
                                                                        {
                                                                            Battle();
                                                                            break;
                                                                        }
                                                                    }
                                                                    else if (PlayerKingCurrentHp <= 0)
                                                                    {
                                                                        Console.Clear();
                                                                        Console.WriteLine("패배하였습니다.");
                                                                        player.Gold -= 2500;
                                                                        Console.WriteLine("2500골드를 잃었습니다.");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine("\n");
                                                                        Console.WriteLine(" ______________");
                                                                        Console.WriteLine("/|돌아가기(esc)|");
                                                                        if (Console.ReadKey(intercept : true).Key == ConsoleKey.Escape)
                                                                        {
                                                                            FixTitle();
                                                                            break;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerKingCurrentHp}/{player.Hp}");
                                                                        Console.WriteLine("보스의 방1");
                                                                        Console.WriteLine("슬라임 킹");
                                                                        Console.WriteLine($"Hp:{SlimeKingCurrentHp}/{SlimeKingHp}");
                                                                        Console.WriteLine($"공격력:{SlimeKingAtk} 방어력:{SlimeKingDef}");
                                                                        if (1500 < SlimeKingCurrentHp && SlimeKingCurrentHp < 5000)
                                                                        {
                                                                            Console.WriteLine(@"     /\/\/\/\");
                                                                            Console.WriteLine(@"    /___O___\");
                                                                            Console.WriteLine(@"   |          |");
                                                                            Console.WriteLine(@" _/   .l  l.   \_");
                                                                            Console.WriteLine(@"/________________\");
                                                                        }
                                                                        else if (SlimeKingCurrentHp == 5000)
                                                                        {
                                                                            Console.WriteLine(@"     /\/\/\/\");
                                                                            Console.WriteLine(@"    /___O___\");
                                                                            Console.WriteLine(@"   |          |");
                                                                            Console.WriteLine(@" _/ __ l  l __ \_");
                                                                            Console.WriteLine(@"/________________\");
                                                                        }
                                                                        else if (SlimeKingCurrentHp <= 1500)
                                                                        {
                                                                            Console.WriteLine(@"     /\/\/\/\");
                                                                            Console.WriteLine(@"    /___O___\");
                                                                            Console.WriteLine(@"   |          |");
                                                                            Console.WriteLine(@" _/  ..1  1..  \_");
                                                                            Console.WriteLine(@"/____||____||____\");
                                                                        }
                                                                        Console.WriteLine(" ____________    ____________");
                                                                        Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                                        if (attack.Key == ConsoleKey.Enter)
                                                                        {
                                                                            SlimeKingCurrentHp -= (SlimeKingDef - player.Atk);
                                                                            Console.Clear();
                                                                            if (SlimeKingCurrentHp < 0)
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("슬라임 킹을 물리쳤습니다.");
                                                                                player.Exp += 500;
                                                                                player.Gold += 5000;
                                                                                Console.WriteLine("경험치 500 획득");
                                                                                Console.WriteLine("골드 5000 획득");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine(" ______________");
                                                                                Console.WriteLine("/|돌아가기(esc)|");
                                                                                if (enter.Key == ConsoleKey.Escape)
                                                                                {
                                                                                    Battle();
                                                                                    break;
                                                                                }
                                                                            }
                                                                            else if (PlayerKingCurrentHp <= 0)
                                                                            {
                                                                                Console.Clear();
                                                                                Console.WriteLine("패배하였습니다.");
                                                                                player.Gold -= 2500;
                                                                                Console.WriteLine("2500골드를 잃었습니다.");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine("\n");
                                                                                Console.WriteLine(" ______________");
                                                                                Console.WriteLine("/|돌아가기(esc)|");
                                                                                if (Console.ReadKey(intercept : true).Key == ConsoleKey.Escape)
                                                                                {
                                                                                    FixTitle();
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                        else if (attack.Key == ConsoleKey.Escape)
                                                                        {
                                                                            Battle();
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                else if (attack.Key == ConsoleKey.Escape)
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
            else if (start.Key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("미구현");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine(" ______________");
                Console.WriteLine("/|돌아가기(esc)|");
                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
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
            Console.Clear();
            Console.WriteLine("장비");
            Console.WriteLine("\n");
            var availableArmors = new List<(Armor armor, int addDef, string name)>();
            if (Backpack.Leather) availableArmors.Add((Armor.Leather, 50, "가죽갑옷"));
            if (Backpack.Chainmail) availableArmors.Add((Armor.Chainmail, 750, "사슬갑옷"));
            if (Backpack.Fullplate) availableArmors.Add((Armor.Fullplate, 20000, "풀플레이트갑옷"));
            if (Backpack.God) availableArmors.Add((Armor.God, 150000, "신의 갑옷"));
            if (availableArmors.Count == 0)
            {
                Console.WriteLine("장비가 없습니다.");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine(" ______________");
                Console.WriteLine("/|돌아가기(esc)|");
                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                {
                    FixTitle();
                }
            }
            for (int i = 0; i < availableArmors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableArmors[i].name}");
            }
            Console.WriteLine(" ________________    ______________");
            Console.WriteLine("/|장비착용(번호)|  /|돌아가기(esc)|");
            Console.WriteLine();
            var key = Console.ReadKey(intercept: true);
            if (key.Key == ConsoleKey.Escape)
            {
                FixTitle();
            }
            int selection = key.KeyChar - '0';
            if (selection < 1 || selection > availableArmors.Count)
            {
                Console.WriteLine("\n잘못된 입력입니다. 다시 시도하세요.");
                Console.ReadKey(intercept: true);
                Equip();
            }
            var selected = availableArmors[selection - 1];
            player.ADef = selected.addDef;
            player.armor = selected.armor;
            Console.WriteLine($"\n{selected.name} 장착됨. 추가 방어력: {selected.addDef}");
            Console.WriteLine("아무 키나 누르면 돌아갑니다.");
            Console.ReadKey(intercept: true);
            FixTitle();
        }
        public static void LvUp()
        {
            Console.Clear();
            Console.WriteLine("레벨업!");
            if (player.Lv < 10)
            {
                player.Exp -= player.Lv * 10;
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
            }
            else
            {
                if (player.Lv == 10)
                {
                    Console.WriteLine("승급필요");
                }
                else if (player.Lv < 20)
                {
                    player.Exp -= (player.Lv - 10) * 200;
                    player.Lv += 1;
                    player.Hp += 200;
                    player.Mp += 100;
                    player.Atk += 20;
                    player.Def += 20;
                    Console.WriteLine("Hp 200 증가");
                    Console.WriteLine("Mp 100 증가");
                    Console.WriteLine("Atk 20 증가");
                    Console.WriteLine("Def 20 증가");
                    Console.WriteLine(" ______________    ______________");
                    Console.WriteLine("/|레벨업(Space)|  /|돌아가기(esc)|");
                }
                else
                {
                    if (player.Lv == 20)
                    {
                        Console.WriteLine("승급필요");
                    }
                    else if (player.Lv < 30)
                    {
                        player.Exp -= (player.Lv - 20) * 4000;
                        player.Lv += 1;
                        player.Hp += 1000;
                        player.Mp += 500;
                        player.Atk += 100;
                        player.Def += 100;
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
                            player.Exp -= (player.Lv - 30) * 80000;
                            player.Lv += 1;
                            player.Hp += 2000;
                            player.Mp += 1000;
                            player.Atk += 200;
                            player.Def += 200;
                            Console.WriteLine("Hp 2000 증가");
                            Console.WriteLine("Mp 1000 증가");
                            Console.WriteLine("Atk 200 증가");
                            Console.WriteLine("Def 200 증가");
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
                                player.Exp -= (player.Lv - 40) * 1600000;
                                player.Lv += 1;
                                player.Hp += 4000;
                                player.Mp += 2000;
                                player.Atk += 400;
                                player.Def += 400;
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
                                    player.Exp -= (player.Lv - 50) * 32000000;
                                    player.Lv += 1;
                                    player.Hp += 8000;
                                    player.Mp += 4000;
                                    player.Atk += 800;
                                    player.Def += 800;
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
                                        player.Exp -= (player.Lv - 60) * 640000000;
                                        player.Lv += 1;
                                        player.Hp += 16000;
                                        player.Mp += 8000;
                                        player.Atk += 1600;
                                        player.Def += 1600;
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
        public static void FixTitle()
        {
            Console.Clear();
            Console.WriteLine("Text RPG Start");
            Console.WriteLine("Please name your character");
            if (created == false)
            {
                player.name = Console.ReadLine();
                created = true;
            }
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
                if (player.Exp >= player.Lv * 100)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 10)
            {
                if (player.Exp >= 1000)
                {
                    Console.WriteLine(" ________ ");
                    Console.WriteLine("|승급(M)|");
                    Console.WriteLine(" ======== ");
                }
            }
            else if (player.Lv < 20)
            {
                if (player.Exp >= (player.Lv - 10) * 2000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if
                (player.Lv == 20)
            {
                if (player.Exp >= 20000)
                {
                    Console.WriteLine(" ________ ");
                    Console.WriteLine("|승급(M)|");
                    Console.WriteLine(" ======== ");
                }
            }
            else if (player.Lv < 30)
            {
                if (player.Exp >= (player.Lv - 20) * 3000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 30)
            {
                Console.WriteLine(" ________ ");
                Console.WriteLine("|승급(M)|");
                Console.WriteLine(" ======== ");
            }
            else if (player.Lv < 40)
            {
                if (player.Exp >= (player.Lv - 30) * 4000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 40)
            {
                Console.WriteLine(" ________ ");
                Console.WriteLine("|승급(M)|");
                Console.WriteLine(" ======== ");
            }
            else if (player.Lv < 50)
            {
                if (player.Exp >= (player.Lv - 40) * 5000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 50)
            {
                Console.WriteLine(" ________ ");
                Console.WriteLine("|승급(M)|");
                Console.WriteLine(" ======== ");
            }
            else if (player.Lv < 60)
            {
                if (player.Exp >= (player.Lv - 50) * 6000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 60)
            {
                Console.WriteLine(" ________ ");
                Console.WriteLine("|승급(M)|");
                Console.WriteLine(" ======== ");
            }
            else if (player.Lv < 70)
            {
                if (player.Exp >= (player.Lv - 60) * 7000)
                {
                    Console.WriteLine(" _____________ ");
                    Console.WriteLine("|레벨업(Space)|");
                    Console.WriteLine(" ============= ");
                }
            }
            else if (player.Lv == 70)
            {
                Console.WriteLine(" ________ ");
                Console.WriteLine("|승급(M)|");
                Console.WriteLine(" ======== ");
            }
            var introduce = Console.ReadKey(intercept: true);
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
                    Console.WriteLine("Exp: " + player.Exp);
                    Console.WriteLine("Hp: " + player.Hp);
                    Console.WriteLine("Mp: " + player.Mp);
                    Console.WriteLine("Atk: " + player.Atk + $"({player.Atk + player.WAtk})");
                    Console.WriteLine("Def: " + player.Def + $"({player.Def} + {player.ADef})");
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

                }
            }
        }
    }
}


