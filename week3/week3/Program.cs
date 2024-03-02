using System;

class Program
{
    // 게임 제어 코드, 뱀의 이동, 음식 먹기, 게임 오버 조건 확인
    static void Main()
    {
        Display display = new Display();
        
        // 게임 맵 크기 정하기
        Map map = new Map(10, 20);
        
        // 뱀 위치 정하기
        Snake snake = new Snake();
        map.MapInfo = snake.Init(map.MapInfo);
        
        // 음식 위치 정하기
        FoodCreator foodCreator = new FoodCreator();
        map.MapInfo = foodCreator.Create(map.MapInfo);
        
        // 대기화면 출력, 사용자의 키 입력이 있으면 게임 시작
        display.Lobby();
        display.Play(map.MapInfo);
        
        while (true)
        {
            ConsoleKey key = Console.ReadKey().Key;
            map.MapInfo = snake.Move(key, map.MapInfo);
            display.Play(map.MapInfo);
            
            // 뱀이 죽은 상태인지 확인
            // if (snake.IsDie) break;
            
            
            // 출력
        }
        
        // display.End();
    }
}

// 맵 정보, 생성, 
class Map
{
    private int[,] map;

    public int[,] MapInfo
    {
        get { return map; }
        set { map = value; }
    }
    
    // 맵 생성
    public Map(int _x, int _y)
    {
        int[,] temp = new int[_x, _y];
        for (int i = 0; i < temp.GetLength(0); i++)
        {
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                if (i == 0 || i == _x - 1 || j == 0 || j == _y - 1)
                {
                    temp[i, j] = 1;
                }
                else
                {
                    temp[i, j] = 0;
                }
            }
        }

        map = temp;

    }
    
}
// 뱀의 상태와 이동, 음식 먹기, 자신의 몸에 부딪혔는지
class Snake
{
    private bool isDie = true;
    private int howLong = 1;
    private Queue<int[]> snakePosition = new Queue<int[]>();

    public bool IsDie
    {
        get { return isDie; }
    }
    
    // 맵의 정보를 받아 랜덤으로 맵 위에 뱀의 위치를 랜덤으로 선정
    public int[,] Init(int[,] _map)
    {
        Random rand = new Random();
        while (true)
        {
            int tempX = rand.Next(1, _map.GetLength(0) - 1);
            int tempY = rand.Next(1, _map.GetLength(1) - 1);
            
            if (_map[tempX, tempY] == 0)
            {
                snakePosition.Enqueue([tempX, tempY]);
                _map[tempX, tempY] = 2;
                return _map;
            }
        }
    }
    
    // 키 입력과 맵 정보를 받아 뱀의 위치를 변경하여, 맵정보를 반환
    public int[,] Move(ConsoleKey _key, int[,] _map)
    {
        foreach (int[] pos in snakePosition)
        {
            _map[pos[0], pos[1]] = 0;
        }
        int[] temp = snakePosition.Dequeue(); // 머리부분 
        
        // ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■  // <<<<<<<<<<<<<<<<< 테스트용 <<<<<<<<<<<<<<<<<
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ ■ ■ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ * □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ □ ■ 
        // ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ ■ 
        
        // 5,7
        // 5,7 5,8
        // 5,8
        
        // 5,6 5,7 5,8
        // 5,6 5,7 5,8 5,9
        // 5,7 5,8 5,9
        

        if (_key == ConsoleKey.UpArrow)
        {
            int[] moveTo = {temp[0] - 1, temp[1]};
            snakePosition.Enqueue(moveTo);
            if (_map[moveTo[0], moveTo[1]] == 3)
            {
                snakePosition.Enqueue([temp[0], temp[1]]);
            }
        }
        else if (_key == ConsoleKey.DownArrow)
        {
            int[] moveTo = {temp[0] + 1, temp[1]};
            snakePosition.Enqueue(moveTo);
            if (_map[moveTo[0], moveTo[1]] == 3)
            {
                snakePosition.Enqueue([temp[0], temp[1]]);
            }
        }
        else if (_key == ConsoleKey.LeftArrow)
        {
            int[] moveTo = {temp[0], temp[1] - 1};
            snakePosition.Enqueue(moveTo);
            if (_map[moveTo[0], moveTo[1]] == 3)
            {
                snakePosition.Enqueue([temp[0], temp[1]]);
            }
        }
        else if (_key == ConsoleKey.RightArrow)
        {
            int[] moveTo = {temp[0], temp[1] + 1};
            snakePosition.Enqueue(moveTo);
            if (_map[moveTo[0], moveTo[1]] == 3)
            {
                snakePosition.Enqueue([temp[0], temp[1]]);
            }
        }
        
        foreach (int[] pos in snakePosition)
        {
            _map[pos[0], pos[1]] = 2;
        }

        return _map;
    }
}

// 무작위 위치에 음식을 생성
class FoodCreator
{
    public int[,] Create(int[,] _map)
    {
        Random rand = new Random();
        while (true)
        {
            int tempX = rand.Next(1, _map.GetLength(0) - 1);
            int tempY = rand.Next(1, _map.GetLength(1) - 1);
            
            if (_map[tempX, tempY] == 0)
            {
                _map[tempX, tempY] = 3;
                return _map;
            }
        }
    }
}

class Display
{
    public void Lobby()
    {
        Console.Clear();
        Console.WriteLine("Press any key to start!");
        Console.WriteLine();
    }

    public void End()
    {
        Console.Clear();
        Console.WriteLine("Game Over");
    }

    public void Play(int[,] _map)
    {
        Console.Clear();
        for (int i = 0; i < _map.GetLength(0); i++)
        {
            for (int j = 0; j < _map.GetLength(1); j++)
            {
                if (_map[i,j] == 0)
                {
                    Console.Write("□ ");
                }
                else if (_map[i,j] == 1 || _map[i,j] == 2)
                {
                    Console.Write("■ "); 
                }
                else if (_map[i,j] == 3)
                {
                    Console.Write("* "); 
                }
            }
            Console.WriteLine("");
        }
    }
    
}




