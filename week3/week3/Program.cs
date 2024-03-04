using System;
using System.Drawing;

class Program
{
    // 맵의 크기를 지정
    // 맵에서의 죄표는 좌측하단부터 (0,0), 우측으로는 x축, 위쪽으로는 y축. 좌표평면 기준 1사분면
    static int mapX = 20; // x축
    static int mapY = 10; // y축
    
    // 게임 속도 지정
    static int gameSpeed = 100;
    
    static void Main()
    {
        // 뱀의 위치를 랜덤으로 생성
        Snake snake = new Snake(mapX, mapY); 
        
        // 음식의 위치를 랜덤으로 생성
        FoodCreator foodCreator = new FoodCreator();
        foodCreator.CreateFood(mapX, mapY, snake.SnakePosition);
        
        // 화면 출력 
        Display(snake.SnakePosition, foodCreator.FoodPosition, foodCreator.HowManyEat);
        Console.WriteLine("Press Arrow Key(⭠ ⭡ ⭢ ⭣) to start!");
        
        // 키 입력을 받고 뱀의 방향을 정하면 시작
        ConsoleKey startKey = Console.ReadKey(true).Key;
        snake.SnakeDirection(startKey);

        while (true)
        {
            // 사용자 키 입력이 있으면 실행, While은 버퍼에 쌓아둔 값을 없애기 위함
            while (Console.KeyAvailable)
            {
                // 사용자의 입력에 따라 뱀의 방향을 바꿈
                ConsoleKey keyEvent = Console.ReadKey(true).Key;
                snake.SnakeDirection(keyEvent); 
            }
            
            // 현재의 뱀의 방향에 따라서 뱀의 위치를 바꿈
            snake.MoveSnake();
            
            // 음식을 먹었는지?
            if (snake.IsEatTheFood(foodCreator.FoodPosition))
            {
                // 이동하면서 사라진 위치에 뱀 몸통 하나 추가
                snake.AddBody();
                // 먹은 음식 개수 카운트 추가
                foodCreator.HowManyEat++;
                // 새로운 음식 생성
                foodCreator.CreateFood(mapX, mapY, snake.SnakePosition);
            }
            // 벽에 박았는지? -> 게임오버
            if (snake.IsCrash2Wall(mapX, mapY))
            {
                Console.WriteLine("You crashed to wall!");
                break;
            }
            
            // 뱀의 몸에 부딫혔는지? -> 게임오버
            if (snake.IsCrash2Body())
            {
                Console.WriteLine("You crashed by self!");
                break;
            }

            // 화면 출력 
            Display(snake.SnakePosition, foodCreator.FoodPosition, foodCreator.HowManyEat);
            Console.WriteLine($"Eat : {foodCreator.HowManyEat}");
            
            /*
            // >>>>>>>>>>>>>>>>>>>>>>>>>> 테스트 출력 코드 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            foreach (Point body in snake.SnakePosition) 
            {
                Console.WriteLine("snake: " + body);
            }
            Console.WriteLine("tail: " + snake.TailPoint);
            Console.WriteLine("food :" + foodCreator.FoodPosition);
            */
            
            Thread.Sleep(gameSpeed);
            // break;
        }
        Console.WriteLine("Game Over!!");
    }

    // 콘솔 화면 출력( 뱀 위치, 음식 위치, 먹은 음식 개수 ) 
    static void Display(List<Point> _body, Point _food, int _howManyEat)
    {
        // 벽 출력을 위해 기존 맵 크기 +2씩 
        int wallMapX = mapX + 2;
        int wallMapY = mapY + 2;
        
        // 맵 정보를 출력할 2차원 string배열 생성
        string[,] map = new string[wallMapX, wallMapY];

        // 맵 배열에 가상의 벽 추가
        for (int i = 0; i < wallMapX; i++)
        {
            for (int j = 0; j < wallMapY; j++)
            {
                if (i == 0 || j == 0 || i == wallMapX - 1 || j == wallMapY - 1)
                {
                    map[i, j] = "■ ";
                }
                else
                {
                    map[i, j] = "  ";
                }
            }
        }
        
        // 맵 배열에 뱀 추가
        foreach (Point snakePoint in _body)
        {
            map[snakePoint.X + 1, snakePoint.Y + 1] = "□ ";
        }
        
        // 맵 배열에 음식 추가
        map[_food.X + 1, _food.Y + 1] = "* ";
        
        // 맵 배열 출력
        Console.Clear();
        for (int i = wallMapY - 1; i >= 0; i--)
        {
            for (int j = 0; j < wallMapX; j++)
            {
                Console.Write(map[j, i]);
            }
            Console.WriteLine();
        }
        
    }
}


// 뱀의 상태와 이동, 음식 먹기, 자신의 몸에 부딪혔는지
class Snake
{
    private List<Point> body = new List<Point>(); // 뱀의 위치를 저장하는 Point List
    private Point tail; // 뱀의 꼬리 위치를 저장하는 Point
    private string direction; // 뱀의 방향을 저장하는 string

    public List<Point> SnakePosition
    {
        get { return body; }
    }

    public Point TailPoint
    {
        get { return tail; }
    }
    
    // 처음 뱀을 생성했을 때, 랜덤으로 위치 생성
    public Snake(int _mapX, int _mapY)
    {
        Random rand = new Random();
        Point randomPoint = new Point(rand.Next(0, _mapX), rand.Next(0, _mapY));
        body.Add(randomPoint);
    }
    
    // 키 값 입력에 따라 뱀의 방향을 결정
    public void SnakeDirection(ConsoleKey _key)
    {
        if (_key == ConsoleKey.UpArrow)
        {
            direction = "up";
        }
        else if (_key == ConsoleKey.DownArrow)
        {
            direction = "down";
        }
        else if (_key == ConsoleKey.RightArrow)
        {
            direction = "right";
        }
        else if (_key == ConsoleKey.LeftArrow)
        {
            direction = "left";
        }
    }
    
    // 뱀의 방향에 따라 뱀의 위치를 이동
    public void MoveSnake()
    {
        List<Point> temp = new List<Point>(body);
        body.Clear();
        
        // 방향성에 따라 머리 위치 변경
        Point head = default;
        // Console.WriteLine("direction: " + direction);
        // Console.WriteLine("temp[0].X: " + temp[0].X);
        // Console.WriteLine("temp[0].Y: " + temp[0].Y);
        if (direction == "up")
        {
            head = new Point(temp[0].X, temp[0].Y + 1);
        }
        else if (direction == "down")
        {
            head = new Point(temp[0].X, temp[0].Y - 1);
        }
        else if (direction == "right")
        {
            head = new Point(temp[0].X + 1, temp[0].Y);
        }
        else if (direction == "left")
        {
            head = new Point(temp[0].X - 1, temp[0].Y);
        }
        // 새로운 머리 위치 추가
        body.Add(head);
        
        if (temp.Count == 1)
        {
            // 기존 뱀의 꼬리 위치 저장
            Point t = new Point(temp[0].X, temp[0].Y);
            tail = t;
        }
        else
        {
            // 다음 몸 위치 순차적으로 추가
            for (int i = 0; i < temp.Count - 1; i++)
            {
                Point p = new Point(temp[i].X, temp[i].Y);
                body.Add(p);
            }
            Point t = new Point(temp[temp.Count - 1].X, temp[temp.Count - 1].Y);
            tail = t;
        }
        
    }

    // 음식 Point 값을 받아서 음식을 먹었는지 확인
    public bool IsEatTheFood(Point _food)
    {
        if (body[0].X == _food.X && body[0].Y == _food.Y)
        {
            return true;
        }
        return false;
    }
    
    // 꼬리 위치에 뱀 몸통 하나 추가
    public void AddBody()
    {
        body.Add(tail);
    }
    
    // 벽에 박았는지?
    public bool IsCrash2Wall(int _mapX, int _mapY)
    {
        if (body[0].X < 0 || body[0].X > _mapX - 1 || body[0].Y < 0 || body[0].Y > _mapY - 1)
        {
            return true;
        }
        return false;
    }
    
    // 뱀의 몸에 부딫혔는지?
    public bool IsCrash2Body()
    {
        // 바뀐 머리의 Point값을 비교
        for (int i = 1; i < body.Count; i++)
        {
            // 뒤따라오는 몸통과 충돌이 일어났는지 검토
            if (body[0] == body[i])
            {
                return true;
            }
    
            // 기존 꼬리와 충돌이 일어났는지 검토
            if (body[0] == tail)
            {
                return true;
            }
        }
        return false;
    }
}

// 무작위 위치에 음식을 생성
class FoodCreator
{
    // 음식의 위치를 저장하는 Point변수, 먹은 음식의 개수를 저장하는 변수
    private Point food;
    private int howManyEat = 0;

    // 음식 위치 조회
    public Point FoodPosition
    {
        get { return food; }
    }
    
    // 음식 먹은 개수 조회
    public int HowManyEat
    {
        get { return howManyEat; }
        set { howManyEat = value; }
    }
    
    // 정해진 맵 크기 내의 좌표에서 뱀의 위치가 아닌곳에 음식 생성
    public void CreateFood(int _mapX, int _mapY, List<Point> _body)
    {
        Random rand = new Random();
        while (true)
        {
            Point randomPoint = new Point(rand.Next(0, _mapX), rand.Next(0, _mapY));

            // 임의로 생성한 음식 위치가 뱀의 위치와 겹치지 않는다면, 음식 좌표 지정
            bool isSamePoint = false;
            foreach (Point snakePoint in _body)
            {
                if (randomPoint == snakePoint)
                {
                    isSamePoint = true;
                }
            }

            if (!isSamePoint)
            {
                food = randomPoint;
                break;
            }
        }
    }
}