using TextRPG._GameScene;
using TextRPG._LoadingScene;
using TextRPG._MainScene;

namespace TextRPG;

public enum SceneState
{
    LoadingScene,
    MainScene,
    GameScene,
}

public class GameManager
{
    private static bool endGame = false;
    private static SceneState sceneState;
    private static SceneManager nowScene;
    
    public GameManager()
    {
        Awake();
        Start();
    }
    
    static void Awake()
    {
        // 초기화
        sceneState = SceneState.LoadingScene;
    }

    static void Start()
    {
        while (!endGame)
        {
            Update();
            Thread.Sleep(1000);
        }
    }

    static void Update()
    {
        switch (sceneState)
        {
            case SceneState.LoadingScene:
                nowScene = new LoadingSceneManager();
                // LoadingSceneManage
                break;
            case SceneState.MainScene:
                nowScene = new MainSceneManager();
                break;
            case SceneState.GameScene:
                nowScene = new GameSceneManager();
                break;
            default:
                break;
        }
        
        // 씬 실행
        // nowScene.실행하고 싶은 함수();
        // Console.WriteLine("실행");
    }

    // 외부에서 씬 변경을 해주는 함수
    public static void ChangeSceneState(SceneState state)
    {
        sceneState = state;
    }
}