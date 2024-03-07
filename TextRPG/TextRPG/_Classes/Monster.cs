using Newtonsoft.Json.Linq;

namespace TextRPG;

public class Monster : ICharacter
{
    public int Level { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int ATK { get; set; }
    public bool IsDead { get; set; }
    
    public Monster(DataManager dataManager, int _minIndex, int _maxIndex)
    {
        JObject monsterJObject = dataManager.GetMonsterData();
        Random random = new Random();
        
        int index = 0; // 몬스터 종류
        index = random.Next(_minIndex, _maxIndex);

        Level = (int)monsterJObject["monster"][index]["Level"];
        Name = (string?)monsterJObject["monster"][index]["Name"];
        HP = (int)monsterJObject["monster"][index]["HP"];
        ATK = (int)monsterJObject["monster"][index]["ATK"];
    }
    
    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}