namespace TextRPG;

public interface ICharacter
{
    public int Level { get; set; }
    string Name { get; set; }
    int HP { get; set; }
    int ATK { get; set; }
    bool IsDead { get; set; }
    void TakeDamage(int damage);
}