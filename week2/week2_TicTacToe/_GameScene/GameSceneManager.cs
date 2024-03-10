namespace week2_TicTacToe._GameScene;

enum NowPlayer
{
    Player1,
    Player2,
}

public class GameSceneManager
{
    private Player player1;
    private Player player2;
    // private Player nowPlayer;
    private NowPlayer nowPlayer;
    private bool endGame = false;
    
    public GameSceneManager(Player player1, Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public void Start()
    {
        // 첫 플레이어 지정
        nowPlayer = NowPlayer.Player1;
        
        // 게임 시작!
        while (!endGame)
        {
            Update();
            Thread.Sleep(100);
        }
        
        // 게임 종료, 승자가 누구인지 알려줌
        ConsoleDisplay();
        string msg = (nowPlayer == NowPlayer.Player1) ? "플레이어 1" : "플레이어 2";
        Console.WriteLine(msg + "의 승리!");
    }

    private void Update()
    {
        // 콘솔 출력
        ConsoleDisplay();

        // 비긴 경우
        if (player1.choseNum.Count + player2.choseNum.Count == 9)
        {
            Console.WriteLine("비겼습니다! 게임을 재시작 합니다.");
            player1.choseNum.Clear();
            player2.choseNum.Clear();
            Thread.Sleep(1000);
            return;
        }
        
        // 현재 플레이어 턴 진행
        switch (nowPlayer)
        {
            case NowPlayer.Player1:
                UserTurn(player1, player2);
                break;
            case NowPlayer.Player2:
                // AI 플레이어인 경우 
                if (player2.isAi)
                {
                    AiTurn(player2, player1);
                }
                else
                {
                    UserTurn(player2, player1);
                }
                break;
        }
    }

    private void UserTurn(Player _nowPlayer, Player _anotherPlayer)
    {
        // 1~9숫자 이외의 입력 예외처리
        int num = ExceptAtReadline([1, 2, 3, 4, 5, 6, 7, 8, 9]);
        if (num != -1)
        {
            // 입력한 숫자가 상대편이 현재 위치하거나, 이미 고른자리인지 자리인지 검토
            if (_nowPlayer.AddNumber(num, _anotherPlayer))
            {
                // 만약 승리조건에 부합하였다면 게임을 종료
                if (_nowPlayer.WonTheGame())
                {
                    endGame = true;
                    return;
                }
                // 플레이어 변경
                nowPlayer = (nowPlayer == NowPlayer.Player1) ? NowPlayer.Player2 : NowPlayer.Player1;
            }
            else
            {
                Console.WriteLine("\n잘못된 입력입니다!( 상대편 or 본인이 이미 위치한 자리 입니다. )");
                Thread.Sleep(1000);
            }
        }
        else
        {
            Console.WriteLine("\n잘못된 입력입니다!( 1~9 사이의 숫자를 입력해주세요. )");
            Thread.Sleep(1000);
        }
    }
    
    private void AiTurn(Player _nowPlayer, Player _anotherPlayer)
    {
        // 입력한 숫자가 상대편이 현재 위치하거나, 이미 고른자리인지 자리인지 검토
        if (_nowPlayer.AddNumber(-1, _anotherPlayer))
        {
            // 만약 승리조건에 부합하였다면 게임을 종료
            if (_nowPlayer.WonTheGame())
            {
                endGame = true;
                return;
            }
            // 플레이어 변경
            nowPlayer = (nowPlayer == NowPlayer.Player1) ? NowPlayer.Player2 : NowPlayer.Player1;
        }
        
    }
    
    private int ExceptAtReadline(int[] useInt)
    {
        Console.Write("숫자 입력 >> ");
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

    private void ConsoleDisplay()
    {
        Console.Clear();
        Console.WriteLine("플레이어 1: X 와 플레이어 2: O\n");
        string msg = (nowPlayer== NowPlayer.Player1) ? "플레이어 1" : "플레이어 2";
        Console.WriteLine(msg + " 의 차례\n");
        
        string[] dp = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        foreach (int num in player1.choseNum)
        {
            dp[num - 1] = "X";
        }
        foreach (int num in player2.choseNum)
        {
            dp[num - 1] = "O";
        }

        Console.WriteLine("       |       |       ");
        Console.WriteLine("   {0}   |   {1}   |   {2}   ", dp[0], dp[1], dp[2]);
        Console.WriteLine("       |       |       ");
        Console.WriteLine("-------|-------|-------");
        Console.WriteLine("       |       |       ");
        Console.WriteLine("   {0}   |   {1}   |   {2}   ", dp[3], dp[4], dp[5]);
        Console.WriteLine("       |       |       ");
        Console.WriteLine("-------|-------|-------");
        Console.WriteLine("       |       |       ");
        Console.WriteLine("   {0}   |   {1}   |   {2}   ", dp[6], dp[7], dp[8]);
        Console.WriteLine("       |       |       ");
    }
}