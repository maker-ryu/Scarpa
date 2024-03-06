using TextRPG._LoadingScene;

namespace TextRPG._MainScene;

public class MainSceneManager : SceneManager
{
    public MainSceneManager()
    {
        Awake();
        // Start();
    }
    
    static void Awake()
    {
        Console.WriteLine("메인씬 시작");
        
    }

    static void Start()
    {
        while (true)
        {
            Update();
        }
    }

    static void Update()
    {
        
    }
}