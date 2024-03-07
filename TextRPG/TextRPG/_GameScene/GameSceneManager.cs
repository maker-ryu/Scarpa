using TextRPG._Common;

namespace TextRPG._GameScene;

public class GameSceneManager : SceneManager
{
    public GameSceneManager(DataManager _dataManager)
    {
        Awake();
        // Start();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== GameSceneManager 시작 ====");

        // 기존 데이터 불러오기
    }

    public SceneState Start()
    {
        while (true)
        {
            Update();
            break;
        }

        return SceneState.MainScene;
    }

    private void Update()
    {
        
    }
    
    private void WriteLog(string _action, string _message)
    {
        Console.WriteLine($"(GSM log) {_action} : {_message}");
    }
}