using week2_TicTacToe._GameScene;

enum GamePlayMode
{
    SinglePLay,
    MultiPlay,
}

// namespace TicTacToe;

public class GameManager
{
    private GamePlayMode gamePlayMode; 
    private GameSceneManager gameSceneManager;
    
    public GameManager()
    {
        Awake();
        Start();
    }

    private void Awake()
    {
        
    }

    private void Start()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome To TicTacToe Console!\n");
            Console.WriteLine("1. 싱글플레이");
            Console.WriteLine("2. 멀티플레이");
            Console.Write("\nChose Your Play Mode >> ");

            int num = ExceptAtReadline([1,2]);
            if (num != -1)
            {
                gamePlayMode = (GamePlayMode)(num - 1);
                break;
            }
            
            Console.WriteLine("잘못된 입력입니다!");
            Thread.Sleep(1000);
        }
        
        switch (gamePlayMode)
        {
            case GamePlayMode.SinglePLay:
                // 싱글플레이
                gameSceneManager = new GameSceneManager(new Player(), new AIPlayer());
                gameSceneManager.Start();
                break;
            case GamePlayMode.MultiPlay:
                // 멀티플레이
                gameSceneManager = new GameSceneManager(new Player(), new Player());
                gameSceneManager.Start();
                break;
        }
    }
    
    private int ExceptAtReadline(int[] useInt)
    {
        string input = Console.ReadLine();
        
        int num;
        if (int.TryParse(input, out num))
        {
            foreach (int use in useInt)
            {
                if (num == use)
                {
                    return num;
                }
            }
        }
        
        // 조건 이외의 값 입력시 - 잘못된 입력입니다 출력
        return -1;
    }
}