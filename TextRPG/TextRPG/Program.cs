using System;
using Newtonsoft.Json.Linq;

namespace TextRPG;

class Program
{
    static void Main()
    {
        DataManager dataManager = new DataManager();
        GameManager gameManager = new GameManager(dataManager);
        gameManager.Start();
        // dataManager.SaveUserData();
        
        // // string relativePath = "_Data/UserData.json";
        // string relativePath = "_Data/MonsterData.json";
        // string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
        // string jsonText = File.ReadAllText(absolutePath);
        //
        // Console.WriteLine(jsonText); // <<< 테스트 출력 코드 >>>
        //
        // JObject JsonData = JObject.Parse(jsonText);
        //
        // Console.WriteLine(JsonData["monster"]);
        // Console.WriteLine(JsonData["monster"].Count());
        // Console.WriteLine(JsonData["monster"][0]);
        // Console.WriteLine(JsonData["monster"][0]["name"]);
    }
}