using TextRPG._Common;

namespace TextRPG._GameScene;

public class BattleStage
{
    private bool endBattle = false;
    private DataManager dataManager;
    private User user;
    private List<Monster> monsters = new List<Monster>();
    
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
                break;
            case BattleState.스킬:
                break;
            case BattleState.Enemy_Phase:
                break;
            case BattleState.Result:
                break;
            default:
                break;
        }
    }

    private void IdleDisplay()
    {
        Console.Clear();
        Console.WriteLine("Battle!!\n");

        for (int i = 0; i < monsters.Count(); i++)
        {
            Console.WriteLine($"Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].HP}");
        }
        
        Console.WriteLine("\n[내정보]");
        Console.WriteLine($"Lv.{user.Level} {user.Name} ( {user.Job} )");
        Console.WriteLine($"HP {user.HP}/100");
        
        Console.WriteLine("\n1.공격");

        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");

        int num = ExceptAtReadline([1]);
        if (num != -1)
        {
            battleState = (BattleState)num;
        }
    }
    
    private int ExceptAtReadline(int[] useInt)
    {
        string input = Console.ReadLine();
        
        int num;
        if (int.TryParse(input, out num))
        {
            foreach (int use in useInt)
            {
                if (num == use)
                {
                    return num;
                }
            }
        }
        
        // 조건 이외의 값 입력시 - 잘못된 입력입니다 출력
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
        return -1;
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