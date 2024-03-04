interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int Attack { get; set; }
    bool IsDead { get; set; }

    void TakeDamage(int damage);
}

class Warrior : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public bool IsDead { get; set; }
    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}

class Monster : ICharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public bool IsDead { get; set; }
    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}

class Goblin : Monster
{
    
}

class Dragon : Monster
{
    
}



interface IItem
{
    string Name { get; set; }
    void Use(Warrior warrior);
}

class HealthPotion : IItem
{
    public string Name { get; set; }
    public void Use(Warrior warrior)
    {
        throw new NotImplementedException();
    }
}

class StrengthPotion : IItem
{
    public string Name { get; set; }
    public void Use(Warrior warrior)
    {
        throw new NotImplementedException();
    }
}

class Stage
{
    Warrior warrior = new Warrior();
    Goblin goblin = new Goblin();

    HealthPotion healthPotion = new HealthPotion();
    StrengthPotion strengthPotion = new StrengthPotion();

    public void Start()
    {
        // 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
        // 플레이어와 몬스터가 교대로 턴을 진행
        // 플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
        // 스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
    }
}

class Program
{
    static void Main()
    {
        Stage stage = new Stage();

        while (true)
        {
            stage.Start();
            
            Thread.Sleep(1000);
        }
        
        
    }
}