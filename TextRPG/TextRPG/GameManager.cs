using TextRPG._Common;
using TextRPG._GameScene;
using TextRPG._LoadingScene;
using TextRPG._MainScene;

namespace TextRPG;

public class GameManager
{
    private bool endGame = false;
    private int gameSpeed = 1000; // 씬 전환 속도
    private SceneState sceneState; // 현재 띄워야 할 씬이 무엇인지 저장
    
    // private SceneManager nowScene;
    private DataManager dataManager;
    
    public GameManager()
    {
        Awake();
    }
    
    private void Awake()
    {
        // 데이터 매니저 소환
        dataManager = new DataManager();
        // 씬 상태 초기화(당연히 처음 거쳐가야 하는 로딩씬)
        sceneState = SceneState.LoadingScene;
    }

    public void Start()
    {
        while (!endGame)
        {
            Update();
            Thread.Sleep(gameSpeed); 
        }
    }

    private void Update()
    {
        switch (sceneState)
        {
            case SceneState.LoadingScene:
                LoadingSceneManager loadingSceneManager = new LoadingSceneManager(dataManager); // 로딩씬 인스턴스 생성, 데이터 매니저 참조값 전달
                sceneState = loadingSceneManager.Start(); // 로딩씬 시작, 끝나면 다음 씬이 무엇일지 반환
                break;
            case SceneState.MainScene:
                MainSceneManager mainSceneManager = new MainSceneManager(dataManager);
                sceneState = mainSceneManager.Start();
                break;
            case SceneState.GameScene:
                GameSceneManager gameSceneManager = new GameSceneManager(dataManager);
                sceneState = gameSceneManager.Start();
                break;
            case SceneState.GameOver:
                endGame = true;
                Console.Clear();
                Console.WriteLine("게임 끝남!");
                // 게임오버 메세지 출력
                break;
            default:
                break;
        }
    }
}