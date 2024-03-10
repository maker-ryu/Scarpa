using TextRPG._Common;

namespace TextRPG._LoadingScene;

public class LoadingSceneManager(DataManager dataManager)
{
    private User user = dataManager.GetUserData();
    
    public SceneState Start()
    {
        if (dataManager.IsNewbie)
        {
            string name = CreateUserName();
            string job = CreateUserJob();
            
            // 새로운 유저 데이터 생성
            user.CreateNewbieUserData(name, job);
            dataManager.SaveUserData2JsonFile(user);
        }
        
        // 로딩씬이 끝나고 메인씬 시작
        return SceneState.MainScene;
    }

    private string CreateUserName()
    {
        // 콘솔 출력
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("원하시는 이름을 설정해주세요.");
        Console.Write(">> ");
        return Console.ReadLine();
    }
    
    private string CreateUserJob()
    {
        // 콘솔 출력
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

        // 메뉴 출력
        Console.WriteLine("1. 전사");
        Console.WriteLine("2. 마법사");
        Console.WriteLine("3. 성직자");
        
        Console.WriteLine("\n원하시는 직업을 선택해주세요.");
        Console.Write(">> ");
        
        // 입력 예외처리
        int num = ExceptAtReadline([1, 2, 3]);
        if (num != -1)
        {
            switch (num)
            {
                case 1:
                    return "전사";
                case 2:
                    return "마법사";
                case 3:
                    return "성직자";
            }
        }
        else
        {
            return CreateUserJob();
        }

        return CreateUserJob();
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
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
        return -1;
    }
}