using System;
using System.Collections.Generic;
using static Dungeon3.Program.Character;

namespace Dungeon3
{
    internal class Program
    {
        private static Character player;
        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            //equipment = new Equipment();
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    EquipmentInfo();
                    LoadItemInfo();   //왜...?
                    break;
            }
        }
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.WriteLine($"공격력 :{player.Atk}");
            Console.WriteLine($"방어력 : {player.Def}");
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void EquipmentInfo()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("현재 가지고 있는 아이템 정보를 표시합니다.");
            Console.WriteLine();
            Console.WriteLine("무기");
            
        }

        public class Character
        {
            public string Name { get; }
            public string Job { get; }
            public int Level { get; }
            public int Atk { get; }
            public int Def { get; }
            public int Hp { get; }
            public int Gold { get; }

            public Character(string name, string job, int level, int atk, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }

            public class Weapon
            {
                public string WeaponName { get;}
                public string WeaponInfo { get;}
                public int Atk { get;}
                public int Price { get;}
                public Weapon(string weaponName, string weaponInfo, int atk, int price)
                {
                    WeaponName = weaponName;
                    WeaponInfo = weaponInfo;
                    Atk = atk;
                    Price = price;
                }
            }
            public class Armor
            {
                public string ArmorName { get;}
                public string ArmorInfo { get;}
                public int Def { get;}
                public int Price { get;}
                public Armor(string armorName, string armorInfo, int def, int price)
                {
                    ArmorName = armorName;
                    ArmorInfo = armorInfo;
                    Def = def;
                    Price = price;
                }
            }
            public class Acc
            {
                public string AccName { get;}
                public string AccInfo { get;}
                public int Atk { get;}
                public int Def { get;}
                public int Price { get;}
                public Acc(string accName, string accInfo, int atk, int def, int price)
                {
                    AccName = accName;
                    AccInfo = accInfo;
                    Atk = atk;
                    Def = def;
                    Price = price;
                }
            }
            public class Equipment
            {
                public string EquipmentName { get;}
                public string EquipmentInfo { get;}
                public int Atk { get;}
                public int Def { get;}
                
            }
        }
        static void LoadItemInfo()
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon("낡은 나무검", "꼬마들이나 장난감으로 가지고 놀 법한, 날은 하나도 서지 않은 낡은 나무검", 2, 300));
            weapons.Add(new Weapon("무딘 철검", "나름 검 같은 모습은 갖췄다.", 4, 450));
            weapons.Add(new Weapon("떡갈나무지팡이", "나뭇가지를 꺾어 적당히 깎았다. 땅에 꽂으면 그대로 나무가 자라날 것 같다...", 2, 300));
            weapons.Add(new Weapon("참나무지팡이", "조금 신경써서 깎은 티가 난다. 단단해서 호신용으로도 나쁘진 않다.", 4, 450));
            weapons.Add(new Weapon("나무새총", "돌을 먹여 사용한다.", 2, 300));
            weapons.Add(new Weapon("조악한 나무활", "기능은 하지만 많이 조악하다.", 4, 450));
           

            List<Armor> armors = new List<Armor>();
            armors.Add(new Armor("가죽갑옷", "무두질한 가죽을 갑옷 모양으로 그럴싸하게 만들었다. 큰 효과는 기대할 수 없다.", 2, 200));
            armors.Add(new Armor("검은 로브", "펑퍼짐하고 두툼한... 이불?", 2, 100));
            armors.Add(new Armor("작업복", "세탁이 쉬워 무슨 일을 하더라도 편하게 입을 수 있는 옷이다.", 1, 70));
            armors.Add(new Armor("황동갑옷", "황동으로 만든 갑옷. 무겁고 무르긴 해도 적당히 효과를 기대할 정도는 된다.", 4, 500));
            armors.Add(new Armor("마술사 복장", "제법 옷의 형태를 갖췄다. 로브 안쪽에는 다양한 도구를 숨겨둘 수 있다.", 3, 400));
            armors.Add(new Armor("체육복", "움직이기 편하고 적당히 몸을 보호해준다.", 2, 300));
            
            List<Acc> accs = new List<Acc>();
            accs.Add(new Acc("나무 방패", "방패라기엔 나무술통 뚜껑을 너무나도 닮았다.", 1, 1, 100));
            accs.Add(new Acc("빨간구슬 반지", "꼬마들이 끼던 것같은 조악한 반지지만 이상하게 효과는 조금 있는 것 같다.", 2, 0, 100));
            accs.Add(new Acc("파란구슬 목걸이", "파란색 유리구슬이 달린 목걸이. 조금 기분을 내는 정도다.", 0, 2, 100));
            accs.Add(new Acc("손목 보호대", "두꺼운 천을 덧대어 만든 손목 보호대.", 0, 1, 60));
            accs.Add(new Acc("가죽벨트", "바지가 흘러내리는걸 방지해서 좀 더 집중할 수 있게 해준다.", 2, 0, 100));
            accs.Add(new Acc("가죽부츠", "먼 걸음 떠나는 여행자의 필수품!", 1, 2, 150));
            for (int i = 0; i < weapons.Count; i++)
            {
                Console.WriteLine(weapons[i]);
            }
            for (int i = 0; i < armors.Count; i++)
            {
                Console.WriteLine(armors[i]);
            }
            for (int i = 0; i < accs.Count; i++)
            {
                Console.WriteLine(accs[i]);
            }
        }
    }
}