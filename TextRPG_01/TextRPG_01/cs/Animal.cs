namespace TextRPG_01.cs;

public class Animal
{
    public string name;
    public string sound;

    public void PlaySound()
    {
        Console.WriteLine($"{name} say's : {sound}");
    }
}