using TextRPG._Common;
using TextRPG._LoadingScene;

namespace TextRPG._MainScene;

public class MainSceneManager : SceneManager
{
    private DataManager dataManager;
    private bool endMainScene = false;
    private SceneState returnSceneState;
    private User user;
    private MainSceneMenu mainSceneMenu;
    
    public MainSceneManager(DataManager _dataManager)
    {
        dataManager = _dataManager;
        Awake();
    }
    
    private void Awake()
    {
        Console.WriteLine("==== MainSceneManager 시작 ====");
        // User 정보 할당
        user = dataManager.GetUserData();
        mainSceneMenu = MainSceneMenu.Idle;
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
        switch (mainSceneMenu)
        {
            case MainSceneMenu.Idle:
                IdleDisplay();
                break;
            case MainSceneMenu.상태_보기:
                CharactorInfoDisplay();
                break;
            case MainSceneMenu.전투_시작:
                endMainScene = true; // 메인씬을 종료하고
                returnSceneState = SceneState.GameScene; // 게임씬으로 이동
                break;
            default:
                break;
        }
    }
    
    private void WriteLog(string _action, string _message)
    {
        Console.WriteLine($"(MSM log) {_action} : {_message}");
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

        for (int i = 1; i <= 2; i++)
        {
            MainSceneMenu menu = (MainSceneMenu)i;
            string strMenu = menu.ToString();
            strMenu = strMenu.Replace("_", " ");
            Console.WriteLine($"{i}. {strMenu}");
        }
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        string input = Console.ReadLine();

        // 입력 예외처리
        int num;
        if (int.TryParse(input, out num))
        {
            if (num == 1 || num == 2) // 1 ~ 2 사이의 숫자를 입력했다면 
            {
                mainSceneMenu = (MainSceneMenu)num;
                return;
            }
        }
        
        // 1 ~ 2 이외 입력시 - 잘못된 입력입니다 출력
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
    }

    /// <summary>
    /// '상태 보기' 메뉴화면 출력
    /// </summary>
    private void CharactorInfoDisplay()
    {
        // 콘솔 출력
        Console.Clear();
        Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

        user.DisplayUserInfo();
        
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">>");
        string input = Console.ReadLine();

        // 입력 예외처리
        int num;
        if (int.TryParse(input, out num))
        {
            if (num == 0) 
            {
                mainSceneMenu = (MainSceneMenu)num;
                return;
            }
        }
        
        // 조건 이외의 값 입력시 - 잘못된 입력입니다 출력
        Console.WriteLine("\n잘못된 입력입니다!");
        Thread.Sleep(1000);
    }
}