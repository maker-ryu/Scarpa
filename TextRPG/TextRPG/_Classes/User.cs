namespace TextRPG;

public class User : ICharacter
{
    public int Level { get; set; }
    public string Name { get; set; }
    public string Job { get; set; } 
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }

    public bool IsDead { get; set; }
    public void TakeDamage(int damage)
    {
        // Health -= damage;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"Lv. {Level.ToString("D2")}");
        Console.WriteLine($"{Name} ( {Job} )");
        Console.WriteLine($"공격력 : {Attack}");
        Console.WriteLine($"방어력 : {Defence}");
        Console.WriteLine($"체 력 : {Health}");
        Console.WriteLine($"Gold : {Gold} G");
    }
}
