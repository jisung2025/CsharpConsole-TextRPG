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
            }
        }
    }
}
 */
