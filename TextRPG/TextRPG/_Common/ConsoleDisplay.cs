namespace TextRPG._Common;

public class ConsoleDisplay
{
    private User user;
    private List<Monster> monsters;
    
    public ConsoleDisplay(User user, List<Monster> monsters)
    {
        this.user = user;
        this.monsters = monsters;
    }
    
    public BattleState IdleDisplay()
    {
        // 콘솔창 출력
        Console.Clear();
        Console.WriteLine("Battle!!\n");

        for (int i = 0; i < monsters.Count(); i++)
        {
            Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].HP}");
        }
        
        Console.WriteLine("\n[내정보]");
        Console.WriteLine($"Lv.{user.Level} {user.Name} ( {user.Job} )");
        Console.WriteLine($"HP {user.HP}/100");
        
        Console.WriteLine("\n1. 공격");

        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        if (ExceptAtReadline([1], out int num))
        {
            return (BattleState)num;
        }

        return BattleState.Idle;
    }

    public BattleState UserPhaseAttackDisplay()
    {
        // 남은 몬스터의 순번을 저장하는 리스트
        List<int> integerList = new List<int>();
                
        // 콘솔창 출력
        Console.Clear();
        Console.WriteLine("Battle!!\n");
                
        for (int a = 0; a < monsters.Count(); a++)
        {
            if (monsters[a].IsDead)
            {
                string text = (a + 1) + " Lv. " + monsters[a].Level + " " + monsters[a].Name + " Dead";
                ChangeColorAndWriteLine(text, ConsoleColor.Black);
                // Console.WriteLine($"{a + 1} Lv.{monsters[a].Level} {monsters[a].Name} Dead");
            }
            else
            {
                Console.WriteLine($"{a + 1} Lv.{monsters[a].Level} {monsters[a].Name} HP {monsters[a].HP}");
                integerList.Add(a + 1);
            }
        }
        
        // 만약 모든 몬스터가 죽었거나, 유저가 죽었으면 배틀 결과 페이지로 바로 이동
        if (integerList.Count() == 0 || user.IsDead)
        {
            return BattleState.Result;
        }
        
        Console.WriteLine("\n[내정보]");
        Console.WriteLine($"Lv.{user.Level} {user.Name} ( {user.Job} )");
        Console.WriteLine($"HP {user.HP}/100");
                
        Console.WriteLine("\n0. 취소");
        integerList.Add(0);

        Console.WriteLine("\n대상을 선택해주세요.");
        Console.Write(">>");
        
        // 공격 결과 페이지 
        int[] integerArray = integerList.ToArray();
        if (ExceptAtReadline(integerArray, out int num))
        {
            // 취소 선택하면 다시 배틀 스테이지 첫 화면으로
            if (num == 0)
            {
                return BattleState.Idle;
            }
            else
            {
                // 오차율 10% 유저의 공격값 구하기
                Random random = new Random();
                int userAtkGap = (int)Math.Round(user.ATK * 0.1);
                int userAtk = random.Next(user.ATK - userAtkGap, user.ATK + userAtkGap + 1);
                
                // 유저 -> 몬스터 공격
                int i = num - 1; // 선택한 몬스터의 인덱스
                int beforeDamage = monsters[i].HP;
                monsters[i].TakeDamage(userAtk);

                // 콘솔창 출력
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Battle!!\n");

                    Console.WriteLine($"{user.Name}의 공격!");
                    Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name}을 맞췄습니다. [데미지 : {userAtk}]");

                    Console.WriteLine($"\nLv.{monsters[i].Level} {monsters[i].Name}");
                    Console.Write($"HP {beforeDamage}");
                    if (monsters[i].IsDead)
                    {
                        Console.WriteLine(" -> Dead");
                    }
                    else
                    {
                        Console.WriteLine($" -> {monsters[i].HP}");
                    }
                    
                    Console.WriteLine("\n0. 다음");
                    Console.Write("\n>>");

                    if (ExceptAtReadline([0], out int numInside))
                    {
                        return BattleState.EnemyPhase;
                    }
                }
            }
        }

        return BattleState.공격;
    }

    public BattleState EnemyPhaseDisplay()
    {
        // 남은 몬스터의 순번을 저장하는 리스트
        List<int> integerList = new List<int>();
                
        for (int a = 0; a < monsters.Count(); a++)
        {
            if (monsters[a].IsDead)
            {
                // Console.WriteLine($"{i + 1} Lv.{monsters[i].Level} {monsters[i].Name} Dead");
            }
            else
            {
                // Console.WriteLine($"{i + 1} Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].HP}");
                integerList.Add(a);
            }
        }
        
        // 만약 모든 몬스터가 죽었거나, 유저가 죽었으면 배틀 결과 페이지로 바로 이동
        if (integerList.Count() == 0 || user.IsDead)
        {
            return BattleState.Result;
        }

        // 몬스터 -> 유저 공격
        int i = integerList[0]; // 선택된 몬스터의 인덱스
        int monsterATK = monsters[i].ATK;
        int beforeDamage = user.HP;
        user.TakeDamage(monsterATK);
        
        // 콘솔창 출력
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            
            Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name}의 공격!");
            Console.WriteLine($"{user.Name} 을(를) 맞췄습니다. [데미지 : {monsterATK}]");
            
            Console.WriteLine($"\nLv.{user.Level} {user.Name}");
            Console.Write($"HP {beforeDamage}");
            if (user.IsDead)
            {
                Console.WriteLine(" -> Dead");
            }
            else
            {
                Console.WriteLine($" -> {user.HP}");
            }
            
            Console.WriteLine("\n0. 다음");
            Console.Write("\n>>");

            if (ExceptAtReadline([0], out int numInside))
            {
                return BattleState.공격;
            }
        }

        // return BattleState.EnemyPhase;
    }

    public void ResultDisplay()
    {
        Console.Clear();
        Console.WriteLine("Battle!! - Result\n");
        
        if (user.IsDead)
        {
            // Console.WriteLine("You Lose\n");
            ChangeColorAndWriteLine("You Lose\\n", ConsoleColor.Red);
            Console.WriteLine($"Lv.{user.Level} {user.Name}");
            Console.WriteLine("HP 100 -> Dead");
        }
        else
        {
            // Console.WriteLine("Victory\n");
            ChangeColorAndWriteLine("Victory\n", ConsoleColor.Green);
            Console.WriteLine($"던전에서 몬스터 {monsters.Count()}마리를 잡았습니다.\n");
            
            Console.WriteLine($"Lv.{user.Level} {user.Name}");
            Console.WriteLine($"HP 100 -> {user.HP}");
        }
            
        Console.WriteLine("\n0. 다음");
        Console.Write("\n>>");
        ExceptAtReadline([0], out int numInside);
        //
        // if (ExceptAtReadline([0], out int numInside))
        // {
        //     return;
        // }
    }
    
    private bool ExceptAtReadline(int[] useInt, out int _num)
    {
        string input = Console.ReadLine();
        
        // int num;
        if (int.TryParse(input, out _num))
        {
            foreach (int use in useInt)
            {
                if (_num == use)
                {
                    return true;
                }
            }
        }
        
        // 조건 이외의 값 입력시 - 잘못된 입력입니다 출력
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
        return false;
    }
    
    public void ChangeColorAndWrite(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor(); // 색상을 원래 상태로 되돌립니다.
    }
    
    public void ChangeColorAndWriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor(); // 색상을 원래 상태로 되돌립니다.
    }
}