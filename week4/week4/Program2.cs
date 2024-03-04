namespace week4;

public class Program2
{
    static void Abc(int value)
    {
        Console.WriteLine($"{value}의 값이 증가했습니다.");
    }

    static void Main()
    {
        Program.OnStart += Abc;
    }
}