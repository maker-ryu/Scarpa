using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

class Program
{
    private JObject monsterJObject;
    
    static void Main()
    {
        DataManager dataManager = new DataManager();
        // dataManager.Print();
    }
}

// JSON 파일의 구조에 맞는 클래스 정의
class MyObject
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void TakeDamage()
    {
        
    }
}

class DataManager
{
    private JObject monsterJObject;
    
    // JSON 데이터 생성
    MyObject myObject = new MyObject
    {
        Name = "John",
        Age = 30,
    };

    public DataManager()
    {
        // monsterJObject = ReadJsonFile("_Data/MonsterData.json");
        // ReadOrCreateFile("_Data/UserData.json");
        SaveJsonFile("_Data/UserData.json", myObject);
        
        // string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // string projectDirectory = GetParentDirectory(GetParentDirectory(GetParentDirectory(GetParentDirectory(baseDirectory))));
        // string filePath = Path.Combine(projectDirectory, "_Data/UserData.json");
        // Console.WriteLine("filePath : " + filePath);
        //
        // ReadOrCreateFile(filePath);
    }
    
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

    private void SaveJsonFile<T>(string _relativePath, T data)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath);
        
        try
        {
            // 파일이 이미 존재하는 경우 삭제
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // JSON 형태의 데이터로 직렬화하여 파일에 쓰기
            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);

            Console.WriteLine("파일이 성공적으로 저장되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일을 저장하는 중 오류 발생: {ex.Message}");
        }
    }
    
    private void ReadOrCreateFile(string filePath)
    {
        try
        {
            // 파일이 존재하는지 확인
            if (File.Exists(filePath))
            {
                // 파일이 존재하면 읽어오기
                string content = ReadFileContent(filePath);
                Console.WriteLine($"파일 내용: {content}");
            }
            else
            {
                // 파일이 존재하지 않으면 생성하고 내용 쓰기
                CreateFile(filePath);
                Console.WriteLine("새로운 파일을 생성했습니다.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"파일을 처리하는 중 오류 발생: {ex.Message}");
        }
    }

    private string ReadFileContent(string filePath)
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            return sr.ReadToEnd();
        }
    }

    private void CreateFile(string filePath)
    {
        // 파일을 생성하고 내용 쓰기
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.WriteLine("새로운 파일이 생성되었습니다.");
            sw.WriteLine("추가적인 내용을 쓸 수 있습니다.");
        }
    }
}