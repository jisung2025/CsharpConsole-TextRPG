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
            public Armor armor = Armor.None;
            public WeaponType weapon = WeaponType.Fist;

        }
        public class Backpack
        {
            public bool Leather = false;
            public bool Chainmail = false;
            public bool Fullplate = false;
            public bool God = false;
            public bool wood = false;
            public bool stone = false;
            public bool iron = false;
            public bool god = false;
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
        private static Character player = new Character();
        private static Achievement AC = new Achievement();
        private static Backpack backpack = new Backpack();
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
                            backpack.Leather = true;
                        }
                    }
                    else if (chain.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 4000)
                        {
                            player.Gold -= 4000;
                            backpack.Chainmail = true;
                        }
                    }
                    else if (fullplate.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 100000)
                        {
                            player.Gold -= 100000;
                            backpack.Fullplate = true;
                        }
                    }
                    else if (god.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 999999999)
                        {
                            player.Gold -= 999999999;
                            backpack.God = true;
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
                            backpack.wood = true;
                        }
                    }
                    else if (stone.Key == ConsoleKey.D2)
                    {
                        if (player.Gold >= 4000)
                        {
                            player.Gold -= 4000;
                            backpack.stone = true;
                        }
                    }
                    else if (iron.Key == ConsoleKey.D3)
                    {
                        if (player.Gold >= 100000)
                        {
                            player.Gold -= 100000;
                            backpack.iron = true;
                        }
                    }
                    else if (god.Key == ConsoleKey.D4)
                    {
                        if (player.Gold >= 999999999)
                        {
                            player.Gold -= 999999999;
                            backpack.god = true;
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
                                    if (attack.Key == ConsoleKey.Escape)
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
                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                {
                                                    Battle();
                                                    loop_3 = false;
                                                }

                                                else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                {
                                                    Console.WriteLine("이 앞은 보스 슬라임 킹(추천레벨 10+)이 존재합니다.");
                                                    Console.WriteLine("정말 들어가시겠습니까?");
                                                    Console.WriteLine("\n");
                                                    Console.WriteLine(" ________________    ______________");
                                                    Console.WriteLine("/|들어가기(enter)|  /|돌아가기(esc)|");
                                                    if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                    {
                                                        Battle();
                                                        loop_3 = false;
                                                    }
                                                    else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
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
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine(@" ");
                                                        Console.WriteLine(@"              ");
                                                        Console.WriteLine(@"     /\/\/\/\");
                                                        Console.WriteLine(@"    /////\\\\\");
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
                                                        int SlimeKingHp = 5000;
                                                        int SlimeKingAtk = 250 + 500;
                                                        int SlimeKingDef = 500;
                                                        int SlimeKingCurrentHp = SlimeKingHp;
                                                        int PlayerKingCurrentHp = player.Hp;
                                                        int CoolTime = 1;
                                                        bool loop_4 = true;
                                                        while (loop_4 == true)
                                                        {
                                                            if (SlimeKingCurrentHp > 0)
                                                            {
                                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerKingCurrentHp}/{player.Hp}");
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
                                                                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
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
                                                                            CoolTime -= 1;
                                                                            Console.Clear();

                                                                        }
                                                                        else
                                                                        {
                                                                            SlimeCurrentHp -= 0;
                                                                        }
                                                                    }
                                                                }
                                                                else if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                                                                {
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
            Console.Clear();
            Console.WriteLine("장비");
            Console.WriteLine("\n");
            var availableArmors = new List<(Armor armor, int addDef, string name)>();
            if (backpack.Leather) availableArmors.Add((Armor.Leather, 50, "가죽갑옷"));
            if (backpack.Chainmail) availableArmors.Add((Armor.Chainmail, 750, "사슬갑옷"));
            if (backpack.Fullplate) availableArmors.Add((Armor.Fullplate, 20000, "풀플레이트갑옷"));
            if (backpack.God) availableArmors.Add((Armor.God, 150000, "신의 갑옷"));
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
                        player.Hp += 100;
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


