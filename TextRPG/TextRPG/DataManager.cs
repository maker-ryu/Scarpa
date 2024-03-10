using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TextRPG._Common;

namespace TextRPG;

public class DataManager
{
    public bool IsNewbie { get; set; } = true; // 뉴비인지?
    private User user = new User();

    private string userDataDirectory; // 유저 json데이터 디렉토리
    private string monsterDataDirectory; // 몬스터 정보 json데이터 디렉토리
    
    private JObject userJObject;
    private JObject monsterJObject;
    
    // 생성자
    public DataManager()
    {
        Awake();
    }
    
    private void Awake()
    {
        // 유저 데이터와, 몬스터 데이터 절대경로 지정
        SetAbsouluteDirectory();

        // 유저 json데이터 조회, 없으면 파일 생성
        userJObject = GetJsonDataFormFile(userDataDirectory);

        // 기존에 저장된 유저 정보가 있으면 user인스턴스에 저장
        if (userJObject != null)
        {
            // json데이터 저장
            user.Level = (int)userJObject["Level"];
            user.Name = (string)userJObject["Name"];
            user.Job = (string)userJObject["Job"];
            user.ATK = (int)userJObject["ATK"];
            user.Defence = (int)userJObject["Defence"];
            user.HP = (int)userJObject["HP"];
            user.Gold = (int)userJObject["Gold"];
            user.Stage = (int)userJObject["Stage"];
            
            // 뉴비가 아님을 저장
            IsNewbie = false;
        }
        
        // 테스트 코드
        // user.CreateNewbieUserData("chad", "전사");
        // SaveUserData2JsonFile(user);
        
        // 몬스터 정보 json데이터 조회
        monsterJObject = GetJsonDataFormFile(monsterDataDirectory);
    }
    
    // json데이터 조회
    private JObject GetJsonDataFormFile(string filePath)
    {
        try
        {
            // 파일이 존재하는지 확인
            if (File.Exists(filePath))
            {
                // 파일이 존재하면 JObject로 반환
                string jsonContent = File.ReadAllText(filePath);
                return JObject.Parse(jsonContent);
            }
            else
            {
                // 파일이 존재하지 않으면 파일 생성
                File.CreateText(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일을 처리하는 중 오류 발생: {ex.Message}");
        }
        return null;
    }
    
    // 유저 데이터 저장
    public void SaveUserData2JsonFile(User userData)
    {
        try
        {
            // 파일이 이미 존재하는 경우 삭제
            if (File.Exists(userDataDirectory))
            {
                File.Delete(userDataDirectory);
            }
            
            // JSON 형태의 데이터로 직렬화하여 파일에 쓰기
            string jsonData = JsonConvert.SerializeObject(userData, Formatting.Indented);
            File.WriteAllText(userDataDirectory, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일을 저장하는 중 오류 발생: {ex.Message}");
        }
    }
    
    // 유저 데이터와, 몬스터 데이터 절대경로 지정
    private void SetAbsouluteDirectory()
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string projectDirectory = GetParentDirectory(GetParentDirectory(GetParentDirectory(GetParentDirectory(baseDirectory))));
        userDataDirectory = Path.Combine(projectDirectory, "_Data/UserData.json");
        monsterDataDirectory = Path.Combine(projectDirectory, "_Data/MonsterData.json");
    }
    
    // 상위 디렉토리를 반환하는 함수
    private string GetParentDirectory(string directoryPath)
    {
        try
        {
            DirectoryInfo directoryInfo = Directory.GetParent(directoryPath);

            if (directoryInfo != null)
            {
                return directoryInfo.FullName;
            }

            return null; // 최상위 디렉토리인 경우 null을 반환할 수 있습니다.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"상위 디렉토리를 가져오는 중 오류 발생: {ex.Message}");
            return null;
        }
    }
    
    public User GetUserData()
    {
        return user;
    }
    
    public JObject GetMonsterData()
    {
        return monsterJObject;
    }
}