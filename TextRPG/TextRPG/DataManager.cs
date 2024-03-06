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
        // Console.WriteLine("데이터 매니저 실행");
        // 기존 데이터 불러오기
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
    
    public static void ChangeData()
    {
        Console.WriteLine("데이터 매니저에서 데이터 무언가 변경!");
    }
}