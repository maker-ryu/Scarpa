using TextRPG._Common;
using TextRPG._GameScene;
using TextRPG._LoadingScene;
using TextRPG._MainScene;

namespace TextRPG;

public class GameManager(DataManager dataManager)
{
    private bool endGame = false;
    private SceneState sceneState = SceneState.LoadingScene;

    public void Start()
    {
        while (!endGame)
        {
            Update();
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
                // 게임종료 메세지 출력
                Console.Clear();
                Console.WriteLine("게임 끝남!");
                break;
            default:
                break;
        }
    }
}