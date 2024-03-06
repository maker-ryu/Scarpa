using TextRPG._Common;

namespace TextRPG._LoadingScene;

public class LoadingSceneManager : SceneManager
{
    private DataManager dataManager;
    private bool endLoadingScene = false;
    
    public LoadingSceneManager(DataManager _dataManager)
    {
        dataManager = _dataManager;
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== LoadingSceneManager 시작 ====");
    }

    public SceneState Start()
    {
        while (!endLoadingScene)
        {
            Update();
        }
        
        // 로딩씬이 끝나고 메인씬 시작
        return SceneState.MainScene;
    }

    private void Update()
    {
        if (dataManager.IsNewbie)
        {
            Console.WriteLine("캐릭터 생성");
            Console.WriteLine("직업 선택");
        }
        
        // 생성된 정보 저장
        dataManager.ChangeData("로딩씬에서 생성된 캐릭터 생성 이름, 직업 정보");
        
        // 로딩씬 끝
        endLoadingScene = true;
    }
}