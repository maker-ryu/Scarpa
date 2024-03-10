using TextRPG._Common;

namespace TextRPG._LoadingScene;

public class LoadingSceneManager(DataManager dataManager)
{
    private User user = dataManager.GetUserData();
    
    // private bool endLoadingScene = false;
    // private SceneState returnSceneState;
    
    public SceneState Start()
    {
        if (dataManager.IsNewbie)
        {
            string name = "Chad";
            string job = "전사";
            
            // 새로운 유저 데이터 생성
            user.CreateNewbieUserData(name, job);
            dataManager.SaveUserData2JsonFile(user);
        }
        
        // 로딩씬 끝
        // endLoadingScene = true;
        
        // 로딩씬이 끝나고 메인씬 시작
        // returnSceneState = SceneState.MainScene;
        
        // 로딩씬이 끝나고 메인씬 시작
        return SceneState.MainScene;
    }
}