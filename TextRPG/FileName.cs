/*
    
            Console.Clear();
            Console.WriteLine("장비");
            Console.WriteLine("\n");
            var availableArmors = new List<(Armor armor, int addDef, string name)>();
            if (backpack.Leather) availableArmors.Add((Armor.Leather, 50, "가죽갑옷"));
            if (backpack.Chainmail) availableArmors.Add((Armor.Chainmail, 750, "사슬갑옷"));
            if (backpack.Fullplate) availableArmors.Add((Armor.Fullplate, 20000, "풀플레이트갑옷"));
            if (backpack.God) availableArmors.Add((Armor.God, 5000000, "신의 갑옷"));
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
            FixTitle();            }
        public static void Battle()
        {
            if (player.skill1 == "strong")
            {
                player.Atk *= 3 / 2;
            }
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
                                                        Console.WriteLine( "        __ ");
                                                        Console.WriteLine(@"       /  \_");
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
                                                        Console.WriteLine("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         ");
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
                                                                Console.WriteLine(" ____________  ");
                                                                Console.WriteLine("/|공격(enter)| ");
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
                                                                            CoolTime --;
                                                                            Console.Clear();        
                                                                        }
                                                                        else
                                                                        {
                                                                            SlimeKingCurrentHp -= 0;    
                                                                            CoolTime ++;
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
                                                                            CoolTime --;
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            SlimeCurrentHp -= 0;
                                                                            CoolTime++;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.Clear();
                                                                    Console.WriteLine("잘못된 입력");
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
                        int WolfHp = 2500;
                        int WolfAtk = 500;
                        int WolfDef = 250;
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
                                if ((WolfHp/ 10) * 3 < WolfCurrentHp && WolfCurrentHp < WolfHp)
                                {
                                    Console.WriteLine(@" /\---/\");
                                    Console.WriteLine(@"<  /_\  >");
                                    Console.WriteLine(@" <__U__>  ");
                                }
                                else if (WolfCurrentHp == WolfHp)
                                {
                                    Console.WriteLine(@" /\---/\");
                                    Console.WriteLine(@"<  O_O  >");
                                    Console.WriteLine(@" <__U__>  ");
                                }
                                else if (WolfCurrentHp <= ( WolfHp/ 10) * 3)
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
                                    WolfHp += WolfHp;
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
                                            if ((WolfHp / 10) * 3 < WolfCurrentHp && WolfCurrentHp < WolfHp)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  /_\  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp == WolfHp)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  O_O  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp <= (WolfHp / 10) * 3)
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
                                            if ((WolfHp / 10) * 3 < WolfCurrentHp && WolfCurrentHp < WolfHp)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  /_\  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp == WolfHp)
                                            {
                                                Console.WriteLine(@" /\---/\");
                                                Console.WriteLine(@"<  O_O  >");
                                                Console.WriteLine(@" <__U__>  ");
                                            }
                                            else if (WolfCurrentHp <= (WolfHp / 10) * 3)
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
                                                                Console.WriteLine("                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            ");
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
                                                                        if ((LunaWolfHp/10)*3 < LunaWolfCurrentHp && LunaWolfCurrentHp < LunaWolfHp)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write(@"|\    /|");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                                                                        else if (LunaWolfCurrentHp == LunaWolfHp)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write(@"__    __");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@"/| ");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                                                                        else if (LunaWolfCurrentHp <= (LunaWolfHp / 10) * 3)
                                                                        {
                                                                            Console.WriteLine(@"|\--------/|");
                                                                            Console.Write(@"| ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"///");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                                                            Console.Write(@"   /|");
                                                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                                                            Console.WriteLine(@" |");
                                                                            Console.Write(@"\ ");
                                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                                            Console.Write(@"|||");
                                                                            Console.ForegroundColor = ConsoleColor.Yellow;
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
                                                                                        Console.WriteLine($"경험치{LunaWolfHp/10} 획득");
                                                                                        Console.WriteLine($"골드{LunaWolfHp} 획득");
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
                                                                                        Console.WriteLine($"경험치{LunaWolfHp/10} 획득");
                                                                                        Console.WriteLine($"골드{LunaWolfHp} 획득");
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
                                                                                    Console.WriteLine($"경험치{LunaWolfHp/10} 획득");
                                                                                    Console.WriteLine($"골드{LunaWolfHp} 획득");
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
                    Console.Clear();
                    Console.WriteLine("「<--(esc)」");
                    Console.WriteLine("\n");
                    Console.WriteLine("     뱀의 사당(레벨제한:21)");
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Console.WriteLine(" ____________      __________");
                    Console.WriteLine("/|입장(enter)|    /|다음(-->)|");
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
                            int SoBeliveHp = 10000;
                            int SoBeliveAtk = 1000;
                            int SoBeliveDef = 500;
                            int SoBeliveCurrentHp = SoBeliveHp;
                            int PlayerCurrentHp = player.Hp;
                            while (true)
                            {
                                if (SoBeliveCurrentHp > 0)
                                {
                                    Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                    Console.WriteLine("뱀의 사당1");
                                    Console.WriteLine("광신도");
                                    Console.WriteLine($"Hp:{SoBeliveCurrentHp}/{SoBeliveHp}");
                                    Console.WriteLine($"공격력:{SoBeliveAtk} 방어력:{SoBeliveDef}");
                                    if (30 < SoBeliveCurrentHp && SoBeliveCurrentHp < 100)
                                    {
                                        Console.WriteLine(@"   ___");
                                        Console.WriteLine(@"  /+++\");
                                        Console.WriteLine(@" /=====\");
                                        Console.WriteLine(@"(__\_/__)");
                                        Console.WriteLine(@" \=====/  ");
                                        Console.WriteLine(@"  \___/  ");
                                    }
                                    else if (SoBeliveCurrentHp == 100)
                                    {
                                        Console.WriteLine(@"   ___");
                                        Console.WriteLine(@"  /+++\");
                                        Console.WriteLine(@" /=====\");
                                        Console.WriteLine(@"(  =_=  )");
                                        Console.WriteLine(@" \=====/  ");
                                        Console.WriteLine(@"  \___/  ");
                                    }
                                    else if (SoBeliveCurrentHp <= 30)
                                    {
                                        Console.WriteLine(@"   ___");
                                        Console.WriteLine(@"  /+++\");
                                        Console.WriteLine(@" /=====\");
                                        Console.WriteLine(@"(__0_0__)");
                                        Console.WriteLine(@" \=====/  ");
                                        Console.WriteLine(@"  \___/  ");
                                    }
                                    Console.WriteLine(" ____________    ____________");
                                    Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                    var attack = Console.ReadKey(intercept: true);
                                    if (attack.Key == ConsoleKey.Enter)
                                    {
                                        if (player.Def + player.ADef > SoBeliveAtk)
                                        {
                                            PlayerCurrentHp -= 1;
                                            if (player.Atk + player.WAtk < SoBeliveDef)
                                            {
                                                SoBeliveCurrentHp -= 1;
                                            }
                                            else
                                            {
                                                PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
                                            }
                                        }
                                        else
                                        {
                                            SoBeliveCurrentHp -= ((player.Atk + player.WAtk) - SoBeliveDef);
                                            if (player.Atk + player.WAtk < SoBeliveDef)
                                            {
                                                SoBeliveCurrentHp -= 1;
                                            }
                                            else
                                            {
                                                PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
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
                                    player.Gold -= SoBeliveHp / 2;
                                    Console.WriteLine($"{SoBeliveHp / 2}골드를 잃었습니다.");
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
                                else if (SoBeliveCurrentHp <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("광신도를 물리쳤습니다.");
                                    player.Exp += SoBeliveHp / 10;
                                    player.Gold += SoBeliveHp;
                                    Console.WriteLine($"경험치{SoBeliveHp / 10}  획득");
                                    Console.WriteLine($"골드 {SoBeliveHp} 획득");
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
                                        SoBeliveHp += 100;
                                        SoBeliveCurrentHp = SoBeliveHp;
                                        SoBeliveAtk += 1;
                                        SoBeliveDef += 1;
                                        while (true)
                                        {
                                            if (SoBeliveCurrentHp > 0)
                                            {
                                                Console.WriteLine("뱀의 사당2");
                                                Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                Console.WriteLine("광신도");
                                                Console.WriteLine($"Hp:{SoBeliveCurrentHp}/{SoBeliveHp}");
                                                Console.WriteLine($"공격력:{SoBeliveAtk} 방어력:{SoBeliveDef}");
                                                if (30 < SoBeliveCurrentHp && SoBeliveCurrentHp < 100)
                                                {
                                                    Console.WriteLine(@" /\---/\");
                                                    Console.WriteLine(@"<  /_\  >");
                                                    Console.WriteLine(@" <__U__>  ");
                                                }
                                                else if (SoBeliveCurrentHp == 100)
                                                {
                                                    Console.WriteLine(@" /\---/\");
                                                    Console.WriteLine(@"<  O_O  >");
                                                    Console.WriteLine(@" <__U__>  ");
                                                }
                                                else if (SoBeliveCurrentHp <= 30)
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
                                                    if (player.Def + player.ADef > SoBeliveAtk)
                                                    {
                                                        PlayerCurrentHp -= 1;
                                                        if (player.Atk + player.WAtk < SoBeliveDef)
                                                        {
                                                            SoBeliveCurrentHp -= 1;
                                                        }
                                                        else
                                                        {
                                                            PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        SoBeliveCurrentHp -= ((player.Atk + player.WAtk) - SoBeliveDef);
                                                        if (player.Atk + player.WAtk < SoBeliveDef)
                                                        {
                                                            SoBeliveCurrentHp -= 1;
                                                        }
                                                        else
                                                        {
                                                            PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
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
                                                player.Gold -= SoBeliveHp / 2;
                                                Console.WriteLine($"{SoBeliveHp / 2}골드를 잃었습니다.");
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
                                            else if (SoBeliveCurrentHp <= 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("광신도를 물리쳤습니다.");
                                                player.Exp += SoBeliveHp / 20;
                                                player.Gold += SoBeliveHp;
                                                Console.WriteLine($"경험치{SoBeliveHp / 20}  획득");
                                                Console.WriteLine($"골드 {SoBeliveHp} 획득");
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
                                                    SoBeliveHp += 100;
                                                    SoBeliveCurrentHp = SoBeliveHp;
                                                    SoBeliveAtk += 1;
                                                    SoBeliveDef += 1;
                                                    while (true)
                                                    {
                                                        if (SoBeliveCurrentHp > 0)
                                                        {
                                                            Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerCurrentHp}/{player.Hp}");
                                                            Console.WriteLine("뱀의 사당3");
                                                            Console.WriteLine("광신도");
                                                            Console.WriteLine($"Hp:{SoBeliveCurrentHp}/{SoBeliveHp}");
                                                            Console.WriteLine($"공격력:{SoBeliveAtk} 방어력:{SoBeliveDef}");
                                                            if (30 < SoBeliveCurrentHp && SoBeliveCurrentHp < 100)
                                                            {
                                                                Console.WriteLine(@" /\---/\");
                                                                Console.WriteLine(@"<  /_\  >");
                                                                Console.WriteLine(@" <__U__>  ");
                                                            }
                                                            else if (SoBeliveCurrentHp == 100)
                                                            {
                                                                Console.WriteLine(@" /\---/\");
                                                                Console.WriteLine(@"<  O_O  >");
                                                                Console.WriteLine(@" <__U__>  ");
                                                            }
                                                            else if (SoBeliveCurrentHp <= 30)
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
                                                                if (player.Def + player.ADef > SoBeliveAtk)
                                                                {
                                                                    PlayerCurrentHp -= 1;
                                                                    if (player.Atk + player.WAtk < SoBeliveDef)
                                                                    {
                                                                        SoBeliveCurrentHp -= 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    SoBeliveCurrentHp -= ((player.Atk + player.WAtk) - SoBeliveDef);
                                                                    if (player.Atk + player.WAtk < SoBeliveDef)
                                                                    {
                                                                        SoBeliveCurrentHp -= 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - SoBeliveAtk);
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
                                                            player.Gold -= SoBeliveHp / 2;
                                                            Console.WriteLine($"{SoBeliveHp / 2}골드를 잃었습니다.");
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
                                                        else if (SoBeliveCurrentHp <= 0)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("광신도를 물리쳤습니다.");
                                                            player.Exp += SoBeliveHp / 20;
                                                            player.Gold += SoBeliveHp;
                                                            Console.WriteLine($"경험치{SoBeliveHp / 20}  획득");
                                                            Console.WriteLine($"골드 {SoBeliveHp} 획득");
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
                                                                Console.WriteLine("이 앞은 보스 고대의 뱀(추천레벨 10+)가 존재합니다.");
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
                                                                    int AcientHp = 10000;
                                                                    int AcientAtk = 500;
                                                                    int AcientDef = 500;
                                                                    int AcientCurrentHp = AcientHp;
                                                                    int PlayerKingCurrentHp = player.Hp;
                                                                    while (true)
                                                                    {
                                                                        if (AcientCurrentHp > 0)
                                                                        {
                                                                            Console.WriteLine($"{player.name} Lv.{player.Lv} Hp:{PlayerKingCurrentHp}/{player.Hp}");
                                                                            Console.WriteLine("보스의 방3");
                                                                            Console.WriteLine("고대의 뱀 ");
                                                                            Console.WriteLine($"Hp:{AcientCurrentHp}/{AcientHp}");
                                                                            Console.WriteLine($"공격력:{AcientAtk} 방어력:{AcientDef}");
                                                                            if ((AcientHp / 10) * 4 > AcientCurrentHp)
                                                                            {
                                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                                Console.WriteLine("Hp 40%이하시 턴마다 모든 능력치 상승");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.ForegroundColor = ConsoleColor.Gray;
                                                                                Console.WriteLine("???");
                                                                            }

                                                                            Console.ResetColor();
                                                                            if ((AcientHp / 10) * 3 < AcientCurrentHp && AcientCurrentHp < AcientHp)
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
                                                                            else if (AcientCurrentHp == 5000)
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
                                                                            else if (AcientCurrentHp <= (AcientHp / 10) * 4)
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
                                                                                Console.WriteLine(@" |__|   ");
                                                                                Console.WriteLine(@"  \___      _-----------_     ___/");
                                                                                Console.WriteLine(@"   \  |    ||           ||   |  /");
                                                                                Console.WriteLine(@"    \  \    @===========@   /  /");
                                                                                Console.WriteLine(@"     \ |\      \=====/     /| /");
                                                                                Console.WriteLine(@"      / _/-----------------\_ \");
                                                                                Console.WriteLine(@"     |_/---------------------\_|");
                                                                                Console.WriteLine(@"     /-------------------------\_");
                                                                            }
                                                                            Console.ResetColor();
                                                                            Console.WriteLine(" ____________    ____________");
                                                                            Console.WriteLine("/|공격(enter)|  /|떠나기(esc)|");
                                                                            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Enter)
                                                                            {
                                                                                if (player.Def + player.ADef > AcientAtk)
                                                                                {
                                                                                    PlayerCurrentHp -= 1;
                                                                                    if (player.Atk + player.WAtk < AcientDef)
                                                                                    {
                                                                                        AcientCurrentHp -= 1;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - AcientAtk);
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    AcientCurrentHp -= ((player.Atk + player.WAtk) - AcientDef);
                                                                                    if (player.Atk + player.WAtk < AcientDef)
                                                                                    {
                                                                                        AcientCurrentHp -= 1;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        PlayerCurrentHp -= ((player.Def + player.ADef) - AcientAtk);
                                                                                    }
                                                                                }
                                                                                AcientAtk *= 2;
                                                                                AcientDef *= 2;
                                                                                Console.Clear();
                                                                                if (AcientCurrentHp < 0)
                                                                                {
                                                                                    if (AC.ACAcient == false)
                                                                                    {
                                                                                        Random random = new Random();
                                                                                        int rn = random.Next(1, 11);
                                                                                        if (rn == 1)
                                                                                        {
                                                                                            AC.ACAcient = true;
                                                                                            Console.Clear();
                                                                                            Console.WriteLine("고대의 뱀을 물리쳤습니다.");
                                                                                            player.Exp += AcientHp / 10;
                                                                                            player.Gold += AcientHp;
                                                                                            Console.WriteLine($"경험치{AcientHp/10} 획득");
                                                                                            Console.WriteLine($"골드{AcientHp / 10} 획득");
                                                                                            Console.WriteLine("고대의 뱀의 증표 획득");
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
                                                                                            Console.WriteLine("고대의 뱀을 물리쳤습니다.");
                                                                                            player.Exp += AcientHp / 10;
                                                                                            player.Gold += AcientHp;
                                                                                            Console.WriteLine($"경험치{AcientHp/10} 획득");
                                                                                            Console.WriteLine($"골드{AcientHp} 획득");
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
                                                                                        Console.WriteLine("고대의 뱀을 물리쳤습니다.");
                                                                                        player.Exp += AcientHp / 10;
                                                                                        player.Gold += AcientHp;
                                                                                        Console.WriteLine($"경험치{AcientHp/10} 획득");
                                                                                        Console.WriteLine($"골드{AcientHp} 획득");
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

                    }
                }
            }
            else if (start.Key == ConsoleKey.Escape)
            {
                FixTitle();
            }
        }
            }
        }
    }
}

using System.Numerics;
using System.Threading;
using System;

{
    Console.Clear();
    Console.WriteLine("「<--(esc)」");
    Console.WriteLine("\n");
    Console.WriteLine($"     {huntzone}");
    Console.WriteLine("\n");
    Console.WriteLine("\n");
    Console.WriteLine(" ____________      __________");
    Console.WriteLine("/|공격(enter)|    /|스킬(-->)|");
    Console.WriteLine(" ____________      __________");
    Console.WriteLine("/|방어(Space)|    /|도망가기(esc)|");
    var start = Console.ReadKey(intercept: true);
    if (start.Key == ConsoleKey.Enter)
    {
        stand = true;
        Battle();
    }
    if (start.Key == ConsoleKey.Escape)
    {
        FixTitle();
    }
    if (start.Key == ConsoleKey.RightArrow)
    {
        Console.Clear();
        Console.WriteLine("「<--(esc)」");
        Console.WriteLine("\n");
        Console.WriteLine($"     {huntzone}");
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        Console.WriteLine(" ____________      __________");
        Console.WriteLine("/|스킬1(1)|    /|스킬2(2)|");
        Console.WriteLine(" ____________      __________");
        Console.WriteLine("/|스킬3(3)|    /|스킬4(4)|");
        var skill = Console.ReadKey(intercept: true);
        if (skill.Key == ConsoleKey.D1)
        {
            if (player.skill1 == "강타")
            {
                if (player.Mp >= 10)
                {
                    player.Mp -= 10;
                    monster.Hp -= player.Atk + player.MAtk;
                    stand = true;
                    Battle();
                }
            }
            else if (player.skill1 == "암살")
            {
                if (player.Mp >= 100)
                {
                    player.Mp -= 100;
                    monster.Hp -= player.Atk + player.MAtk * 2;
                    stand = true;
                    Battle();
                }
            }
            else if (player.skill1 == "파이어볼")
            {
                if (player.Mp >= 80)
                {
                    player.Mp -= 80;
                    monster.Hp -= player.Atk + player.MAtk * 1.5;
                    stand = true;
                    Standing();
*/