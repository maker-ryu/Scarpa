using TextRPG._Common;

namespace TextRPG._GameScene;

public class GameSceneManager(DataManager dataManager)
{
    private User user = dataManager.GetUserData();
    private SceneState returnSceneState;
    
    private bool endGameScene = false;
    
    public SceneState Start()
    {
        // 새로운 스테이지 생성
        // BattleStage battleStage = new BattleStage(dataManager, user, user.Stage);
        // battleStage.Start();

        // 플레이어가 죽지 않고 스테이지를 클리어 하면, 다음 스테이지 시작.
        if (user.IsDead)
        {
            returnSceneState = SceneState.GameOver;
        }
        else
        {
            // 유저 정보를 저장하고, 다음 스테이지 진행
            user.Stage++;
            dataManager.SaveUserData2JsonFile(user);
            returnSceneState = SceneState.MainScene;
        }
        
        return returnSceneState;
    }
}