namespace week2_TicTacToe._GameScene;

public class AIPlayer : Player
{
    private Random random = new Random();

    public AIPlayer()
    {
        isAi = true;
    }
    
    public override bool AddNumber(int num, Player anotherPlayer)
    {
        while (true)
        {
            int addNum = random.Next(1, 10);
            bool isSame = false;

            // 고른 숫자가 이미 이전에 고른 숫자이거나, 상대편이 선택한 숫자이면 숫자 다시 선택
            foreach (int anotherPlayerNum in anotherPlayer.choseNum)
            {
                foreach (int selfNum in this.choseNum)
                {
                    if (addNum == anotherPlayerNum || addNum == selfNum)
                    {
                        isSame = true;
                    }
                }
            }

            if (!isSame)
            {
                choseNum.Add(addNum);
                return true;
            }
        }
    }
}