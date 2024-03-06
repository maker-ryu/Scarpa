using TextRPG._Common;
using TextRPG._LoadingScene;

namespace TextRPG._MainScene;

public class MainSceneManager : SceneManager
{
    public MainSceneManager(DataManager _dataManager)
    {
        Awake();
        // Start();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== MainSceneManager 시작 ====");
        
    }

    public SceneState Start()
    {
        while (true)
        {
            Update();
            break;
        }

        return SceneState.GameScene;
    }

    private void Update()
    {
        
    }
}