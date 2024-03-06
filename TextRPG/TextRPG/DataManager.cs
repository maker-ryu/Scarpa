using Newtonsoft.Json;

namespace TextRPG;

public class DataManager
{
    private bool isNewbie = true; // 뉴비인지?
    // 각종 플레이어 정보, 등등
    
    public bool IsNewbie { get; }
    
    public DataManager()
    {
        Awake();
    }
    
    private void Awake()
    {
        // 기존 데이터 불러오기
        // string jsonData = File.ReadAllText("TextRPG/_Data/UserData.json");
        
        // string relativePath = "TextRPG/_Data/UserData.json";
        //
        // // 현재 작업 디렉토리를 기준으로 절대 경로 생성
        // string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        // Console.WriteLine("absolutePath:" + absolutePath);
        //
        // Console.WriteLine("1. " + Path.Combine(absolutePath, "..") + "여기까지");
        
        
        
        // string jsonContent = File.ReadAllText(absolutePath);
        // Console.WriteLine(jsonContent);
        // 뉴비인지?
    }
    
    public void ChangeData(string something)
    {
        Console.WriteLine("데이터 매니저에서 실행, 받은 데이터 : " + something);
    }
}