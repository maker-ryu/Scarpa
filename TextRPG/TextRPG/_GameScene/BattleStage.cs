using TextRPG._Common;

namespace TextRPG._GameScene;

public class BattleStage
{
    private DataManager dataManager;
    private ConsoleDisplay consoleDisplay;
    
    private User user;
    private List<Monster> monsters = new List<Monster>();
    
    private bool endBattle = false;
    private BattleState battleState;
    
    // 생성자
    public BattleStage(DataManager dataManager, User user, int _stageLevel)
    {
        Console.WriteLine("==== BattleStage 시작 ====");
        
        // 데이터 매니저와 유저 인스턴스 주소 전달
        this.dataManager = dataManager;
        this.user = user;
        
        // 스테이지 난이도에 맞게 몬스터 랜덤으로 생성
        CreateMonsters(_stageLevel);

        // 디스플레이 인스턴스 생성
        consoleDisplay = new ConsoleDisplay(this.user, monsters);
        
        // 기본 배틀 상태 초기화
        battleState = BattleState.Idle;
    }

    public void Start()
    {
        while (!endBattle)
        {
            switch (battleState)
            {
                case BattleState.Idle:
                    battleState = consoleDisplay.IdleDisplay();
                    break;
                case BattleState.공격:
                    battleState = consoleDisplay.UserPhaseAttackDisplay();
                    break;
                case BattleState.스킬:
                    
                    break;
                case BattleState.EnemyPhase:
                    battleState = consoleDisplay.EnemyPhaseDisplay();
                    break;
                case BattleState.Result:
                    consoleDisplay.ResultDisplay();
                    endBattle = true;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 스테이지의 난이도에 따라 몬스터를 랜덤으로 생성
    /// </summary>
    private void CreateMonsters(int _stageLevel)
    {
        Random random = new Random();
        int monsterNum = 0, minIndex = 0, maxIndex = 0;
        
        if (_stageLevel == 1) // '스테이지 1'인 경우
        {
            monsterNum = random.Next(1, 5); // 랜덤 몬스터 개수
            // 어떤 레벨의 몬스터를 소환할지 범위 지정 0 ~ 3 사이의 몬스터 레벨 선택
            minIndex = 0;
            maxIndex = 3;
        }
        else if (_stageLevel == 2) // '스테이지 2'인 경우
        {
            
        }
        
        // monsters 리스트에 랜덤 몬스터 추가, 지정한 범위의 순번 내에서 생성
        for (int i = 0; i < monsterNum; i++)
        {
            monsters.Add(new Monster(dataManager, minIndex, maxIndex));
        }
    }
}