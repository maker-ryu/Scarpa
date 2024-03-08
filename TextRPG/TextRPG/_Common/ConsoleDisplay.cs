namespace TextRPG._Common;

public class ConsoleDisplay
{
    public void ChangeColorAndWrite(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor(); // 색상을 원래 상태로 되돌립니다.
    }
    
    public void ChangeColorAndWriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor(); // 색상을 원래 상태로 되돌립니다.
    }
}