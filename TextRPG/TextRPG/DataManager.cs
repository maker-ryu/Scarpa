namespace TextRPG;

public class DataManager
{
    public DataManager()
    {
        Awake();
        // Start();
    }
    
    static void Awake()
    {
        Console.WriteLine("데이터 매니저 실행");
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