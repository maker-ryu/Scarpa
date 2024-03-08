using TextRPG._Common;

namespace TextRPG._GameScene;

public class BattleStage
{
    private bool endBattle = false;
    private DataManager dataManager;
    private User user;
    private List<Monster> monsters = new List<Monster>();
    private ConsoleDisplay consoleDisplay = new ConsoleDisplay();
    
    private BattleState battleState;

    // 생성자
    public BattleStage(DataManager dataManager, User user, int _stageLevel)
    {
        this.dataManager = dataManager;
        this.user = user;
        
        Console.WriteLine("==== BattleStage 시작 ====");
        
        // 몬스터 랜덤으로 생성하는 부분
        CreateMonsters(_stageLevel);
        
        battleState = BattleState.Idle;
    }

    public void Start()
    {
        while (!endBattle)
        {
            Update();
        }
    }

    private void Update()
    {
        switch (battleState)
        {
            case BattleState.Idle:
                IdleDisplay();
                break;
            case BattleState.공격:
                UserPhaseAttackDisplay();
                break;
            case BattleState.스킬:
                break;
            case BattleState.EnemyPhase:
                EnemyPhaseDisplay();
                break;
            case BattleState.Result:
                ResultDisplay();
                break;
            default:
                break;
        }
    }

    private void IdleDisplay()
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
            battleState = (BattleState)num;
        }
    }

    private void UserPhaseAttackDisplay()
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
                consoleDisplay.ChangeColorAndWriteLine(text, ConsoleColor.Black);
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
            battleState = BattleState.Result;
            return;
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
                battleState = BattleState.Idle;
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
                        battleState = BattleState.EnemyPhase;
                        break;
                    }
                }
            }
        }
    }

    private void EnemyPhaseDisplay()
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
            battleState = BattleState.Result;
            return;
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
                battleState = BattleState.공격;
                break;
            }
        }

    }

    private void ResultDisplay()
    {
        Console.Clear();
        Console.WriteLine("Battle!! - Result\n");
        
        if (user.IsDead)
        {
            // Console.WriteLine("You Lose\n");
            consoleDisplay.ChangeColorAndWriteLine("You Lose\\n", ConsoleColor.Red);
            Console.WriteLine($"Lv.{user.Level} {user.Name}");
            Console.WriteLine("HP 100 -> Dead");
        }
        else
        {
            // Console.WriteLine("Victory\n");
            consoleDisplay.ChangeColorAndWriteLine("Victory\n", ConsoleColor.Green);
            Console.WriteLine($"던전에서 몬스터 {monsters.Count()}마리를 잡았습니다.\n");
            
            Console.WriteLine($"Lv.{user.Level} {user.Name}");
            Console.WriteLine($"HP 100 -> {user.HP}");
        }
            
        Console.WriteLine("\n0. 다음");
        Console.Write("\n>>");

        if (ExceptAtReadline([0], out int numInside))
        {
            endBattle = true;
        }
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

    private void CreateMonsters(int _stageLevel)
    {
        Random random = new Random();
        int monsterNum = 0, minIndex = 0, maxIndex = 0;
        if (_stageLevel == 1) // 스테이지 1
        {
            monsterNum = random.Next(1, 5); // 랜덤 몬스터 개수
            // 어떤 레벨의 몬스터를 소환할지 범위 지정 0 ~ 3 번째 사이의 몬스터 선택
            minIndex = 0;
            maxIndex = 3;
        }
        
        for (int i = 0; i < monsterNum; i++)
        {
            monsters.Add(new Monster(dataManager, minIndex, maxIndex));
        }
    }
}