using TextRPG._Common;
using TextRPG._LoadingScene;

namespace TextRPG._MainScene;

public class MainSceneManager
{
    private DataManager dataManager;
    private SceneState returnSceneState;
    private User user;
    
    private bool endMainScene = false;
    private MainSceneState mainSceneState;
    
    public MainSceneManager(DataManager dataManager)
    {
        this.dataManager = dataManager;
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== MainSceneManager 시작 ====");
        // User 정보 할당
        user = dataManager.GetUserData();
        mainSceneState = MainSceneState.Idle;
    }

    public SceneState Start()
    {
        while (!endMainScene)
        {
            Update();
        }
        
        return returnSceneState;
    }

    private void Update()
    {
        switch (mainSceneState)
        {
            case MainSceneState.Idle:
                IdleDisplay();
                break;
            case MainSceneState.상태_보기:
                CharactorInfoDisplay();
                break;
            case MainSceneState.전투_시작:
                endMainScene = true; // 메인씬을 종료하고
                returnSceneState = SceneState.GameScene; // 게임씬으로 이동
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// MainSceneManager 기본 화면 출력
    /// </summary>
    private void IdleDisplay()
    {
        // 콘솔 출력
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");

        // 메뉴 출력
        for (int i = 1; i <= 2; i++)
        {
            MainSceneState menu = (MainSceneState)i;
            string strMenu = menu.ToString();
            strMenu = strMenu.Replace("_", " ");
            Console.WriteLine($"{i}. {strMenu}");
        }
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        // 입력 예외처리
        int num = ExceptAtReadline([1, 2]);
        if (num != -1)
        {
            mainSceneState = (MainSceneState)num;
        }
    }

    /// <summary>
    /// '상태 보기' 메뉴화면 출력
    /// </summary>
    private void CharactorInfoDisplay()
    {
        // 콘솔 출력
        Console.Clear();
        Console.WriteLine("상태 보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

        user.DisplayUserInfo();
        
        Console.WriteLine("\n0. 나가기\n");
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        
        // 입력 예외처리
        int num = ExceptAtReadline([0]);
        if (num != -1)
        {
            mainSceneState = (MainSceneState)num;
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
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
        return -1;
    }
}