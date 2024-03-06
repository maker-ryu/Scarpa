namespace TextRPG._LoadingScene;

public class LoadingSceneManager : SceneManager
{
    public LoadingSceneManager()
    {
        Awake();
        Start();
    }
    
    static void Awake()
    {
        
    }

    static void Start()
    {
        while (true)
        {
            Update();
            break;
        }
    }

    static void Update()
    {
        Console.WriteLine("캐릭터 생성");
        Console.WriteLine("직업 선택");
        GameManager.ChangeSceneState(SceneState.MainScene);
        DataManager.ChangeData();
    }

    public static void Test()
    {
        Console.WriteLine("로딩씬 테스트 문구 출력!");
    }
}