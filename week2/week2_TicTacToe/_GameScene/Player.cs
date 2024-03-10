namespace week2_TicTacToe._GameScene;

public class Player
{
    public List<int> choseNum = new List<int>(); // 선택한 숫자를 저장할 list
    public bool isAi = false;

    private int[,] winCombination = new int[,] // 승리 숫자 조합
    {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 },
        { 1, 4, 7 },
        { 2, 5, 8 },
        { 3, 6, 9 },
        { 1, 5, 9 },
        { 3, 5, 7 },
    };

    /// <summary>
    ///  입력받은 숫자를 추가, 상대 플레이어와 겹치는 숫자가 아니라면 true반환
    /// </summary>
    public virtual bool AddNumber(int addNum, Player anotherPlayer)
    {
        // 만약 추가하고 싶은 숫자가 내가 이미 지정한 숫자이거나, 상대편 플레이어가 가지고 있는 수라면 false반환
        foreach (int otherPlayerNum in anotherPlayer.choseNum)
        {
            foreach (var selfNum in this.choseNum)
            {
                if (addNum == otherPlayerNum || addNum == selfNum)
                {
                    return false;
                }
            }
        }
        choseNum.Add(addNum);
        return true;
    }

    // 게임의 승패를 판단
    public bool WonTheGame()
    {
        // '승리 숫자 조합'의 모든 숫자와 해당 인스턴스가 선택한 숫자를 비교하여 승패를 판단
        for (int i = 0; i < 8; i++)
        {
            int count = 0;
            for (int j = 0; j < 3; j++)
            {
                foreach (int num in choseNum)
                {
                    if (winCombination[i, j] == num)
                    {
                        count++;
                    }
                }
            }

            // Console.WriteLine($"count : {count}");
            if (count >= 3)
            {
                return true;
            }
        }
        return false;
    }
}