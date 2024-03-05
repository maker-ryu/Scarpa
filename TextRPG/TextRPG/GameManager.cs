namespace TextRPG;

public class GameManager
{
    private static bool endGame = false;
    
    public GameManager()
    {
        Awake();
        Start();
    }
    
    static void Awake()
    {
        
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
        Console.WriteLine("실행");
    }
}