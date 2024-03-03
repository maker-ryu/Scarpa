using System;
using System.Drawing;

class Program
{
    // 맵의 크기를 지정
    static int mapWidth = 20;
    static int mapHeight = 10;
    
    // 게임 속도 지정
    static int gameSpeed = 100;
    
    static void Main()
    {
        Snake snake = new Snake(mapWidth, mapHeight);
        
        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            Thread.Sleep(gameSpeed);
        }
        
    }
}


// 뱀의 상태와 이동, 음식 먹기, 자신의 몸에 부딪혔는지
class Snake
{
    private List<Point> body = new List<Point>();
    
    public Snake(int _mapWidth, int _mapHeight)
    {
        Random rand = new Random();
        Point 
        
    }
}

// 무작위 위치에 음식을 생성
class FoodCreator
{
    
}




