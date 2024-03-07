using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextRPG;

public class DataManager
{
    public bool IsNewbie { get; set; } // 뉴비인지?
    private User user = new User(); // 각종 플레이어 정보 저장
    private JObject monsterJObject;
    
    
    public DataManager()
    {
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== DataManager 시작 ====");

        // 몬스터 json파일 데이터 조회
        monsterJObject = ReadJsonFile("_Data/MonsterData.json");

        // 기존에 저장된 json파일 데이터 조회 > 유저 정보( 캐릭터 정보, 스테이지 정보(어디까지 깼는지) )
        // JObject userJObject = ReadJsonFile("_Data/UserData.json");
         
        if (false) // 기존 유저 데이터가 있다면 <<< 일단 뉴비라고 치고 개발 >>>
        {
            IsNewbie = false;
            // json파싱해서 user인스턴스에 저장
        }
        else // 기존 데이터가 없다면 유저 정보 생성
        {
            IsNewbie = true;
            // CreateNewbieUserData();
        }
    }

    private JObject ReadJsonFile(string _relativePath)
    {
        string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath);
        string jsonText = File.ReadAllText(absolutePath);
        
        return JObject.Parse(jsonText);
    }

    public User GetUserData()
    {
        return user;
    }
    
    public JObject GetMonsterData()
    {
        return monsterJObject;
    }
    
    public void ChangeData(string something)
    {
        Console.WriteLine("데이터 매니저에서 실행, 받은 데이터 : " + something);
    }
    
}