class Program
{
    static void Main()
    {
        Warrior warrior = new Warrior("돌맹이", 10, 10);
        
        Stage stage1 = new Stage(warrior, "바보 고블린");
        stage1.Start();

        // warrior.Health += 10;

        Stage stage2 = new Stage(warrior, "바보 드래곤");
        stage2.Start();


    }
}

class Stage
{
    private Warrior warrior;
    private Monster monster;

    HealthPotion healthPotion = new HealthPotion();
    StrengthPotion strengthPotion = new StrengthPotion();
    
    // 생성자에는 전사의 정보와, 어떤 몬스터들을 소환할런지(스테이지가 가면 갈 수록 더 높은 난이도의 몬스터 소환)
    public Stage(Warrior _warrior, string _monsterName)
    {
        this.warrior = _warrior;
        
        // 지정한 몬스터 이름을 토대로 어떤 몬스터(고블린 또는 드래곤)인지 결정하여 클래스를 생성 
        if (_monsterName.IndexOf("고블린") != -1)
        {
            this.monster = new Goblin(_monsterName);
        }
        else if (_monsterName.IndexOf("드래곤") != -1)
        {
            this.monster = new Dragon(_monsterName);
        }
    }
    
    public void Start()
    {
        // 각 스테이지가 시작할 때 플레이어와 몬스터의 상태를 출력해주세요.
        Console.WriteLine(warrior.Name);
        Console.WriteLine(warrior.Health);
        Console.WriteLine(warrior.Attack);
        
        Console.WriteLine(monster.Name);
        Console.WriteLine(monster.Health);
        Console.WriteLine(monster.Attack);
        
        while (true)
        {
            // 플레이어와 몬스터가 교대로 턴을 진행
            // 플레이어나 몬스터 중 하나가 죽으면 스테이지가 종료되고, 그 결과를 출력해줍니다.
            Console.WriteLine("스테이지 플레이중...");
            // warrior.Health += 10;
            Thread.Sleep(1000);
            break;
        }
        // 스테이지가 끝날 때, 플레이어가 살아있다면 보상 아이템 중 하나를 선택하여 사용할 수 있습니다.
        // 보상 아이템은 스테이지별 몬스터의 수준에 따라 달라짐(내가 정한거)
        
    }
}



interface ICharacter
{
    string Name { get; set; }
    int Health { get; set; }
    int Attack { get; set; }
    bool IsDead { get; set; }

    // 캐릭터가 데미지를 받아 체력이 감소하는 메서드
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
    
    public Warrior(string name, int health, int attack)
    {
        this.Name = name;
        this.Health = health;
        this.Attack = attack;
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
    
    // 몬스터들의 이름과, (체력, 공격력)을 key,value형태로 지정. 
    private Dictionary<string, int[]> monsterInfo = new Dictionary<string, int[]>()
    {
        {"바보 고블린", [1, 1]},
        {"멍청이 고블린", [1, 2]},
        {"화염 고블린", [10, 20]},
        
        {"바보 드래곤", [5, 10]},
        {"멍청이 드래곤", [10, 15]},
        {"화염 드래곤", [20, 30]},
    };
    
    // 이름을 토대로 딕셔너리에 있는 몬스터의 정보를 저장
    public Monster(string name)
    {
        this.Name = name;
        this.Health = monsterInfo[name][0];
        this.Attack = monsterInfo[name][1];
    }
}

class Goblin : Monster
{
    public Goblin(string name) : base(name)
    {
    }
}

class Dragon : Monster
{
    public Dragon(string name) : base(name)
    {
    }
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
        // warrior.Health += 5;
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