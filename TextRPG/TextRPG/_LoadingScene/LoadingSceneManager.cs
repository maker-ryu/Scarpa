using TextRPG._Common;

namespace TextRPG._LoadingScene;

public class LoadingSceneManager : SceneManager
{
    private DataManager dataManager;
    private bool endLoadingScene = false;
    private SceneState returnSceneState;
    private User user;
    
    public LoadingSceneManager(DataManager _dataManager)
    {
        dataManager = _dataManager;
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== LoadingSceneManager 시작 ====");
        // User 정보 할당
        user = dataManager.GetUserData();
    }

    public SceneState Start()
    {
        // Start() 함수의 기능 구현
        if (dataManager.IsNewbie)
        {
            string name = "Chad";
            WriteLog("이름 생성", name);
            string job = "전사";
            WriteLog("직업 선택", job);
            
            // 새로운 유저 데이터 생성
            CreateNewbieUserData(name, job);
        }
        
        // 로딩씬 끝
        endLoadingScene = true;
        
        // 로딩씬이 끝나고 메인씬 시작
        returnSceneState = SceneState.MainScene;
        
        // 로딩씬이 끝나고 메인씬 시작
        return returnSceneState;
    }

    private void WriteLog(string _action, string _message)
    {
        Console.WriteLine($"(LSM log) {_action} : {_message}");
    }
    
    private void CreateNewbieUserData(string _name, string _job)
    {
        user.Level = 1;
        user.Name = _name;
        user.Job = _job;
        user.Attack = 10;
        user.Defence = 5;
        user.Health = 100;
        user.Gold = 1500;
    }

}