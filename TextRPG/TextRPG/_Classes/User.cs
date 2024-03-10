namespace TextRPG;

public class User : ICharacter
{
    public int Level { get; set; }
    public string Name { get; set; }
    public string Job { get; set; } 
    public int ATK { get; set; }
    public int Defence { get; set; }
    public int HP { get; set; }
    public int Gold { get; set; }
    public int Stage { get; set; }

    public bool IsDead { get; set; } = false;

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            IsDead = true;
        }
    }

    public void CreateNewbieUserData(string name, string job)
    {
        Name = name;
        Level = 1;
        Job = job;
        ATK = 10;
        Defence = 5;
        HP = 100;
        Gold = 1500;
        Stage = 1;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"Lv. {Level.ToString("D2")}");
        Console.WriteLine($"{Name} ( {Job} )");
        Console.WriteLine($"공격력 : {ATK}");
        Console.WriteLine($"방어력 : {Defence}");
        Console.WriteLine($"체 력 : {HP}");
        Console.WriteLine($"Gold : {Gold} G");
    }
}
