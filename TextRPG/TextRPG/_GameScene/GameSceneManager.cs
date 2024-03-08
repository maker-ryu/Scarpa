using TextRPG._Common;

namespace TextRPG._GameScene;

public class GameSceneManager
{
    private DataManager dataManager;
    private SceneState returnSceneState;
    private User user;
    
    private bool endGameScene = false;
    // private BattleState battleState;
    
    // 생성자
    public GameSceneManager(DataManager dataManager)
    {
        this.dataManager = dataManager;
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== GameSceneManager 시작 ====");
        // User 정보 할당
        user = dataManager.GetUserData();
        // battleState = BattleState.Idle;
    }

    public SceneState Start()
    {
        BattleStage battleStage = new BattleStage(dataManager, user, 1);
        battleStage.Start();

        if (user.IsDead)
        {
            returnSceneState = SceneState.GameOver;
        }
        else
        {
            // 다음 스테이지 정보 입력
            returnSceneState = SceneState.GameOver; // <<< 일단 게임오버 >>>
        }
        
        return returnSceneState;
    }
}