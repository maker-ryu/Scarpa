using TextRPG_01.cs;

namespace TextRPG_01;

class Program
{
    static void Main()
    {
        Animal tom = new Animal();
        tom.name = "tom";
        tom.sound = "meow";
        
        tom.PlaySound();

    }
}

